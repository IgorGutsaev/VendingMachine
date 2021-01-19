using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core
{
    public class MockUvsAdapter : IUvsAdapter
    {
        public event EventHandler<UvsIncomeEventArgs> OnUvsPayment;
        public event EventHandler<UvsOrderCancelEventArgs> OnUvsOrderCancelled;

        public bool CancelOrder(string orderNumber)
        {
            _cancelTokenSource.Cancel();
            return true;
        }

        public bool ConfirmPayment(string orderNumber) => _orderPayed == orderNumber;

        public bool CreateOrder(string orderNumber, string dsId, string dsName, decimal totaldue, IEnumerable<OrderLine> orderLines)
        {
            _cancelTokenSource = new CancellationTokenSource();

            Task.Run(async delegate
            {
                int i = 0;
                bool isCancelled = false;

                while (i < 3)
                {
                    Thread.Sleep(100);
                    i++;

                    if (_cancelTokenSource.Token.IsCancellationRequested)
                    {
                        isCancelled = true;
                        break;
                    }
                }

                if (!isCancelled)
                {
                    _orderPayed = orderNumber.Trim();
                    OnUvsPayment?.Invoke(this, UvsIncomeEventArgs.Create(12345, PaymentMethod.Card.GetCode(), totaldue));
                }
                else _orderPayed = string.Empty;

            }, _cancelTokenSource.Token);

            return true;
        }

        public bool IsOrderCanceled(string orderNumber)
        {
            throw new NotImplementedException();
        }

        public void SetDepMode(UvsDepMode mode)
        {
            throw new NotImplementedException();
        }

        private CancellationTokenSource _cancelTokenSource;
        private string _orderPayed = string.Empty;
    }
}
