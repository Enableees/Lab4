using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Drinks
    {
        public class Beverage
        {
            public static Random rnd = new Random();
            public int Volume = 0;

            public virtual String GetInfo()
            {
                var str = String.Format("\nОбъем: {0} мл", this.Volume);
                return str;
            }
        }

        public class Juice : Beverage
        {
            public string FruitUsed = "";
            public bool HasPulp = false;

            public override String GetInfo()
            {
                var str = "Я сок";
                str += base.GetInfo();
                str += String.Format("\nИспользуемый фрукт: {0}", this.FruitUsed);
                str += String.Format("\nНаличие мякоти: {0}", this.HasPulp ? "есть" : "нет");
                return str;
            }
            public static Juice Generate()
            {
                string[] fruits = { "апельсин", "яблоко", "виноград", "гранат", "манго" };
                return new Juice
                {
                    Volume = 200 + rnd.Next() % 300,
                    FruitUsed = fruits[rnd.Next(fruits.Length)],
                    HasPulp = rnd.Next() % 2 == 0
                };
            }
        }

        public enum SodaType { cola, lemonade, orange, tonic };
        public class Soda : Beverage
        {
            public SodaType Type = SodaType.cola;
            public int BubblesCount = 0;

            public override String GetInfo()
            {
                var str = "Я газировка";
                str += base.GetInfo();
                str += String.Format("\nВид: {0}", this.Type);
                str += String.Format("\nКоличество пузыриков: {0}", this.BubblesCount);
                return str;
            }
            public static Soda Generate()
            {
                return new Soda
                {
                    Volume = 250 + rnd.Next() % 250,
                    Type = (SodaType)rnd.Next(4),
                    BubblesCount = 500 + rnd.Next() % 1500
                };
            }
        }

        public enum AlcoholType { beer, wine, vodka, whiskey, cocktail };
        public class Alcohol : Beverage
        {
            public double Strength = 0;
            public AlcoholType Type = AlcoholType.beer;

            public override String GetInfo()
            {
                var str = "Я алкогольный напиток";
                str += base.GetInfo();
                str += String.Format("\nКрепость: {0}%", this.Strength);
                str += String.Format("\nТип: {0}", this.Type);
                return str;
            }
            public static Alcohol Generate()
            {
                return new Alcohol
                {
                    Volume = 100 + rnd.Next() % 400,
                    Strength = 5 + rnd.NextDouble() * 40,
                    Type = (AlcoholType)rnd.Next(5)
                };
            }
        }
    }
}