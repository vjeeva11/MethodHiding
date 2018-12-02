using System;

namespace OOPS_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodHidingExample();
            AbstractMethodExample();
        }

        private static void AbstractMethodExample()
        {
            // Abstract - Override
            // instance for derived class
            // creation of derived class instance will invoke the base class constructor
            // followed by derived class constructor will be invoked
            DerivedClass d = new DerivedClass();
            // it will invoke the Base class method
            d.Write();
            // it will invoke the derived class method
            d.VirtualWrite();
            // it will invoke the base class method
            d.VirtualWriteBase();
            Console.ReadLine();
        }

        private static void MethodHidingExample()
        {
            // Method hiding
            // Instance for the Child Class
            Child c1 = new Child();
            // It will invoke the child class method
            c1.Write();
            // To call the Parent class method
            ((Parent)c1).Write();
            Console.ReadLine();
        }
    }

    public class Parent
    {
        // Declare the same method in the Parent class
        public void Write()
        {
            Console.WriteLine("Parent Class Write Method");
        }
    }

    public class Child : Parent
    {
        // Declare the same method in child class 
        // using a new keyword
        public new void Write()
        {
            Console.WriteLine("Child Class Write Method");
        }
    }

    // Base Class Defined with Abstract keyword
    // abstract class cannot be instantiated
    public abstract class BaseClass
    {
        // Base Class Default Constructor
        public BaseClass()
        {
            Console.WriteLine("Base Class Constructor");
        }
        
        // Base class method 
        // It can be accessed using child class instance or
        // base.Write()
        public void Write()
        {
            Console.WriteLine("Base Class Write Method");
        }

        // this method must be implement in derived class
        // it is just an declarations
        public abstract void NewWrite();

        // it is an virtual method , it can be accessed using base.
        // if derived class uses this method name then it must be override 
        // in derived class
        public virtual void VirtualWrite()
        {
            Console.WriteLine("Base Class Virtual Write");
        }

        // method not overidden at derived class
        public virtual void VirtualWriteBase()
        {
            Console.WriteLine("Base Class Virtual Write Base");
        }
    }

    // Derived class when it is declared as sealed
    // it cannot be derived , instance can be created
    public sealed class DerivedClass : BaseClass
    {
        // Derived class Constructor
        public DerivedClass()
        {
            Console.WriteLine("Derived Class Constructor");
        }

        // implemneted the abstract method
        public override void NewWrite()
        {
            Console.WriteLine("Derived Class New Write Method Overridden");            
        }

        // overridden the base class method
        public override void VirtualWrite()
        {
            base.VirtualWrite();
            Console.WriteLine("Derived Class Virtual Write");
        }
    }
}
