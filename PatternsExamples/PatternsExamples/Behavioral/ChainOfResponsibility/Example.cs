using System;

namespace PatternsExamples.Behavioral.ChainOfResponsibility
{
    class Receiver
    {
        public bool BankTransfer { get; set; }

        public bool MoneyTransfer { get; set; }

        public bool PayPalTransfer { get; set; }

        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }

    abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }

        public abstract void Handle(Receiver receiver);
    }

    class BankPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.BankTransfer == true)
                Console.WriteLine("Выполняем банковский перевод");
            else
            {
                Successor?.Handle(receiver);
            }
        }
    }

    class PayPalPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.PayPalTransfer == true)
                Console.WriteLine("Выполняем перевод через PayPal");
            else
            {
                Successor?.Handle(receiver);
            }
        }
    }

    class MoneyPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.MoneyTransfer == true)
                Console.WriteLine("Выполняем перевод через системы денежных переводов");
            else
            {
                Successor?.Handle(receiver);
            }
        }
    }

    class Usage
    {
        public void Run()
        {
            Receiver receiver = new Receiver(false, true, true);

            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHnadler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymentHnadler;

            bankPaymentHandler.Handle(receiver);

            Console.Read();
        }
    }
}
