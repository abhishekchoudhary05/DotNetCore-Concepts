namespace InterviewPrepration.Concepts
{
    internal class BaseClass
    {
        public void Display()
        {
            Console.WriteLine("Base class Display method");
        }
    }

    internal class DerivedClass : BaseClass
    {
        public new void Display()
        {
            Console.WriteLine("Derived class Display method");
        }
    }
}
