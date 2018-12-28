using System;
using System.Collections.Generic;
using System.Text;
using GofPatterns.Creational.Common;

namespace GofPatterns.Creational.AbstractFactory
{
    interface IFactory
    {
        AbstractProductA CreateProductA();
        AbstractProductB CreateProductB();
    }

    class ConcreteFactoryOne : IFactory
    {
        public AbstractProductA CreateProductA()
        {
            return new ProductATypeOne();
        }

        public AbstractProductB CreateProductB()
        {
            return new ProductBTypeOne();
        }
    }

    class ConcreteFactoryTwo : IFactory
    {
        public AbstractProductA CreateProductA()
        {
            return new ProductATypeTwo();
        }

        public AbstractProductB CreateProductB()
        {
            return new ProductBTypeTwo();
        }
    }
}
