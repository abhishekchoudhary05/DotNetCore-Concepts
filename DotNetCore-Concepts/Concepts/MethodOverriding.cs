namespace InterviewPrepration.Concepts
{
    /// <summary>Base type whose display behavior can be overridden polymorphically.</summary>
    internal class Parent
    {
        /// <summary>Displays the base implementation's message.</summary>
        public virtual void Display()
        {
            Console.WriteLine("Parent class Display method");
        }
    }

    /// <summary>Overrides the base display behavior for derived instances.</summary>
    internal class Derived : Parent
    {
        /// <summary>Displays the derived implementation's message.</summary>
        public override void Display()
        {
            Console.WriteLine("Derived class Display method");
        }
    }
}
