namespace InterviewPrepration.Concepts
{
    /// <summary>Base type used to demonstrate method hiding.</summary>
    internal class BaseClass
    {
        /// <summary>Displays the base implementation's message.</summary>
        public void Display()
        {
            Console.WriteLine("Base class Display method");
        }
    }

    /// <summary>Declares a same-named method that hides the base method.</summary>
    internal class DerivedClass : BaseClass
    {
        /// <summary>Displays the derived message when called through the derived type.</summary>
        public new void Display()
        {
            Console.WriteLine("Derived class Display method");
        }
    }
}
