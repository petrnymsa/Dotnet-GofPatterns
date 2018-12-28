using System;
using System.Collections.Generic;
using System.Text;
using GofPatterns.Creational.Common;

namespace GofPatterns.Creational.FactoryMethod
{
    abstract class Cretor
    {
        public abstract AbstractProductA Create();

        protected void SomeOperation()
        {

        }
    }

    class ConcreteCreator : Cretor
    {
        public override AbstractProductA Create()
        {
            return new ProductATypeOne();
        }
    }
}
