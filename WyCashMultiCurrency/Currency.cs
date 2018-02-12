using System;

namespace WyCash
{
    public abstract class Money
    {
        protected int amount;
        protected string currencyName;

        public bool equals(Object obj)
        {
            Money curr = (Money)obj;
            return amount == curr.amount && GetType().Equals(curr.GetType());
        }

        public static Money dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money francs(int amount)
        {
            return new Francs(amount, "CHF");
        }

        public abstract Money times(int exchangeValue);

        public abstract String currency();
    }

    public class Dollar : Money
    {
        public Dollar(int amount, string curr)
        {
            this.amount = amount;
            currencyName = curr;
        }

        public override Money times(int exchangeValue) => Money.dollar(amount * exchangeValue);

        public override String currency()
        {
            return currencyName;
        }
    }

    public class Francs : Money
    {
        public Francs(int amount, string curr)
        {
            this.amount = amount;
            currencyName = curr;
        }

        public override Money times(int exchangeValue) => Money.francs(amount * exchangeValue);

        public override string currency()
        {
            return currencyName;
        }
    }
}
