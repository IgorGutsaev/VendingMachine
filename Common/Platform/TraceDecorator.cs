using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.Utils.Abstractions.Events;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Platform
{
    public class TraceDecorator<T> : DispatchProxy, IKioskEventProducer
    {
        /// <summary>
        /// Proxy object through which the interaction takes place
        /// </summary>
        private T _decorated;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            bool success = false;
            Stopwatch s = null;
            bool isSubscription = false;
            bool isUnsubscription = false;

            Func<object[], string> serializeArgs = (a) =>
            {
                string flt = JsonSerializer.Serialize(a.Where(x => !(x.GetType().Name.Contains("EventHandler")))); // Except events and delegates
                return (flt != null && flt.Length > 0 ? flt : string.Empty);
            };

            try
            {
                object result = null;

                s = Stopwatch.StartNew();

                isSubscription = targetMethod.Name.StartsWith("add_");
                isUnsubscription = targetMethod.Name.StartsWith("remove_");

                OnEvent?.Invoke(_decorated, EventItem.Info($"{(isSubscription || isUnsubscription ? "Event " + (isUnsubscription ? "un" : string.Empty) + "subscriprion has occured:" : "Invoke")} " +
                    $"{(isSubscription || isUnsubscription ? targetMethod.Name.Replace("add_", "").Replace("remove_", "") : targetMethod.Name)}" +
                    $"{(isSubscription || isUnsubscription ? string.Empty : "(" + serializeArgs(args) + ")")}"));

                result = targetMethod.Invoke(_decorated, args);

                s.Stop();

                success = true;

                return result;
            }
            catch (Exception ex) when (ex is TargetInvocationException)
            {
                s.Stop();
                throw ex.InnerException ?? ex;
            }
            finally
            {
                if ((isSubscription || isUnsubscription) && !success)
                    OnEvent?.Invoke(_decorated, EventItem.Error($"Subscription failed {targetMethod.Name}({serializeArgs(args)})"));

                if (!isSubscription && !isUnsubscription)
                {
                    string message = $"Finished {targetMethod.Name}({serializeArgs(args)}) in {s.Elapsed}";
                    OnEvent?.Invoke(_decorated, success ? EventItem.Info(message) : EventItem.Error(message));
                }
            }
        }

        public static T Create(T decorated)
        {
            object proxy = Create<T, TraceDecorator<T>>();
            ((TraceDecorator<T>)proxy).SetParameters(decorated);

            return (T)proxy;
        }

        private void SetParameters(T decorated)
        {
            if (decorated == null)
                throw new ArgumentNullException(nameof(decorated));

            _decorated = decorated;

            var eventInfoes = decorated.GetType().GetEvents();

            foreach (var eventInfo in eventInfoes)
            {
                MethodInfo miHandler =
                    typeof(TraceDecorator<T>).GetMethod("EventTrace",
                        BindingFlags.NonPublic | BindingFlags.Instance);

                Type tDelegate = eventInfo.EventHandlerType;

                Delegate d = Delegate.CreateDelegate(tDelegate, this, miHandler);
                eventInfo.AddEventHandler(decorated, d);
            }
        }

        private void EventTrace(object sender, EventArgs e)
            => OnEvent?.Invoke(_decorated, EventItem.Info($"An event has raised: {e}"));

        public event EventHandler<EventItem> OnEvent;
    }
}
