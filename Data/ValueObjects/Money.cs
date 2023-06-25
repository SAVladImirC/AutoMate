using Data.Enumerations;
using System.Text.Json.Serialization;

namespace Data.ValueObjects
{
    public readonly struct Money
    {
        public float Value { get; }
        public CURRENCIES Currency { get; }


        [JsonConstructor]
        public Money(float value, CURRENCIES currency)
        {
            Value = value;
            Currency = currency;
        }

        public override string ToString()
        {
            return Currency switch
            {
                CURRENCIES.MKD => $"{Value}ден.",
                CURRENCIES.EUR => $"{Value}€",
                CURRENCIES.USD => $"{Value}$",
                CURRENCIES.CHF => $"{Value}CHF",
                _ => "",
            };
        }
    }
}
