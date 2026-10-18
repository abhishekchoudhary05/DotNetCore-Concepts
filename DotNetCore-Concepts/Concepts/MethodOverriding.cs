namespace InterviewPrepration.Concepts
{
    internal class Parent
    {
        public virtual void Display()
        {
            Console.WriteLine("Parent class Display method");
        }
    }

    internal class Derived : Parent
    {
        public override void Display()
        {
            Console.WriteLine("Derived class Display method");
        }
    }
}
