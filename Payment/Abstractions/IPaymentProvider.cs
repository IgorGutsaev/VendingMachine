using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public interface IPaymentProvider
    {
        PaymentMethod Method { get; set; }

        /// <summary>
        /// An amount of inserted money
        /// </summary>
        Money Credit { get; set; }

        /// <summary>
        /// When collection process consists of several deposits
        /// </summary>
        event EventHandler<Money> OnCollect;

        /// <summary>
        /// When requested summ finally collected
        /// </summary>
        event EventHandler<Money> OnCollected;

        /// <summary>
        /// When collection process consists of several deposits
        /// </summary>
        event EventHandler<Money> OnRefund;

        /// <summary>
        /// When refund summ is completely refunded
        /// </summary>
        event EventHandler<Money> OnRefunded;

        event EventHandler<string> OnError;

        /// <summary>
        /// Collect summ
        /// </summary>
        /// <param name="money">Due</param>
        /// <param name="setupAction">To pass some payment payload- timeout, installments etc</param>
        /// <returns></returns>
        bool Collect(Money money, Action<IPaymentProvider> setupAction);
    }
}
