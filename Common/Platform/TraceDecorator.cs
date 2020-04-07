using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.Utils.Abstractions.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

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
            try
            {
                object result = null;
                
                s = Stopwatch.StartNew();
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
                string message = $"Invoke {targetMethod.Name}({(args != null && args.Length > 0 ? JsonConvert.SerializeObject(args) : string.Empty)}) in {s.Elapsed}";
                OnEvent?.Invoke(_decorated, success ? EventItem.Info(message) : EventItem.Error(message));
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
            {
                throw new ArgumentNullException(nameof(decorated));
            }
            _decorated = decorated;
        }

        public event EventHandler<EventItem> OnEvent;
    }
}
