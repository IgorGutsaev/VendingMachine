using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Tests
{
    public enum TestWorkCard
    {
        StartedPaymentBad,
        FinishedPaymentGood,//StartedPaymentGood
        FinishedPaymentBad,
        StartReturnPaymentBad,
        StopPaymentGood,
        StopPaymentBad

    }

    public class CardDeviceMock : ICardDeviceAdapter
    {
        private TestWorkCard _type;
        public event EventHandler<TestCardEventArgs> OnTest;
        public event EventHandler<StopCardEventArgs> OnStopDevice;
        public event EventHandler<CardEventArgs> OnReturnPayment;
        public event EventHandler<StopCardEventArgs> OnStopPayment;
        public event EventHandler<CardEventArgs> OnPayment;

        public CardDeviceMock(TestWorkCard type)
        {
            _type = type;
        }


        public void StartReturnPayment(Money money)
        {
            EventItem eventItem = new EventItem();
            switch (_type)
            {
                case TestWorkCard.StartedPaymentBad:
                    OnReturnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Started payment started bad") });
                    break;
                case TestWorkCard.FinishedPaymentGood:
                    OnReturnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Info("Return payment finished good") });
                    break;
                case TestWorkCard.FinishedPaymentBad:
                    OnReturnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Return payment finished bad") });
                    break;
                case TestWorkCard.StartReturnPaymentBad:
                    OnReturnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Return payment started bad") });
                    break;
                case TestWorkCard.StopPaymentGood:
                    OnReturnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Stop payment is good") });

                    break;
                case TestWorkCard.StopPaymentBad:
                    OnReturnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Stop payment is bad") });

                    break;
                default:
                    OnReturnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Return payment has error") });

                    break;
            }
        }

        public void StartPayment(Money money)
        {
            EventItem eventItem = new EventItem();
            switch (_type)
            {
                case TestWorkCard.StartedPaymentBad:
                    OnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Payment started bad") });
                    break;
                case TestWorkCard.FinishedPaymentGood:
                    OnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Info("payment finished good") });
                    break;
                case TestWorkCard.FinishedPaymentBad:
                    OnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("payment finished bad") });
                    break;
                case TestWorkCard.StartReturnPaymentBad:
                    OnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("payment started bad") });
                    break;
                case TestWorkCard.StopPaymentGood:
                    OnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Stop payment is good") });

                    break;
                case TestWorkCard.StopPaymentBad:
                    OnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Stop payment is bad") });

                    break;
                default:
                    OnPayment?.Invoke(this, new CardEventArgs() { Money = money, Event = EventItem.Error("Return payment has error") });

                    break;
            }
        }

        public void StopDevice()
        {
            throw new NotImplementedException();
        }

        public void StopPayment()
        {
            EventItem eventItem = new EventItem();
            switch (_type)
            {
                case TestWorkCard.StartedPaymentBad:
                    OnStopPayment?.Invoke(this, new StopCardEventArgs() { Description = "Bad", Event = EventItem.Error("Started payment started bad") });
                    break;
                case TestWorkCard.FinishedPaymentGood:
                    OnStopPayment?.Invoke(this, new StopCardEventArgs() { Description = "Bad", Event = EventItem.Error("Payment finished good") });
                    break;
                case TestWorkCard.FinishedPaymentBad:
                    OnStopPayment?.Invoke(this, new StopCardEventArgs() { Description = "Bad", Event = EventItem.Error("Payment finished bad") });
                    break;
                case TestWorkCard.StartReturnPaymentBad:
                    OnStopPayment?.Invoke(this, new StopCardEventArgs() { Description = "Bad", Event = EventItem.Error("Return payment started bad") });
                    break;
                case TestWorkCard.StopPaymentGood:
                    OnStopPayment?.Invoke(this, new StopCardEventArgs() { Description = "Good", Event = EventItem.Info("Stop payment is good") });

                    break;
                case TestWorkCard.StopPaymentBad:
                    OnStopPayment?.Invoke(this, new StopCardEventArgs() { Description = "", Event = EventItem.Error("Stop payment is bad") });

                    break;
                default:
                    OnStopPayment?.Invoke(this, new StopCardEventArgs() { Description = "", Event = EventItem.Error("Stop payment has error") });

                    break;
            }
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
