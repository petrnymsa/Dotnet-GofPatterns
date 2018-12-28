using System.Collections.Generic;

namespace GofPatterns.Creational.Builder
{
    public class ComplexProduct
    {
        public string Name { get; set; }
        public bool IsWorking { get; set; }

        public List<string> Parts { get; private set; } = new List<string>();
    }

    abstract class Builder
    {
        protected ComplexProduct Product = new ComplexProduct();

        public Builder SetName(string name)
        {
            Product.Name = name;
            return this;
        }

        public Builder SetIsWorking(bool isWorking)
        {
            Product.IsWorking = isWorking;
            return this;
        }

        public abstract Builder AddMainPart ();
        public abstract Builder AddPartX ();

        public ComplexProduct Build () => Product;
    }

    class BasicBuilder : Builder
    {
        public override Builder AddMainPart ()
        {
            Product.Parts.Add("BasicPart");
            return this;
        }

        public override Builder AddPartX ()
        {
            Product.Parts.Add("BasicX");
            return this;
        }

        public static void Example()
        {
            new BasicBuilder().SetName("Example").SetIsWorking(false).AddMainPart().AddPartX().Build();
        }
    }

    class BetterBuilder : Builder
    {
        public override Builder AddMainPart ()
        {
            Product.Parts.Add("BetterPart");
            return this;
        }

        public override Builder AddPartX ()
        {
            Product.Parts.Add("BetterX");
            return this;
        }
    }
}
