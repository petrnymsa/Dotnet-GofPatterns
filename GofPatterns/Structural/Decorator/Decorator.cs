using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GofPatterns.Structural.Decorator
{
    class Component
    {
        public virtual void Operation()
        {
            Console.WriteLine("Component.Operation");
        }
    }

    abstract class Decorator : Component
    {
        protected Component Component;

        public void SetComponent(Component component)
        {
            Component = component;
        }

        public override void Operation()
        {
            if(Component != null)
                Component.Operation();
        }
    }

    class ConcreteDecorator : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedOperation();
            Console.WriteLine("ConcreteDecorator.Operation");
        }

        private void AddedOperation()
        {
            Console.WriteLine("ConcreteDecorator.AddedOperation");
        }
    }

}
