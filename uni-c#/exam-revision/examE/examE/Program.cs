namespace examE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var s1 = new Student("IiE");

            s1.AddGrade();
            s1.AddGrade();

            Console.WriteLine(s1);

            MixedFieldGroup g1 = new MixedFieldGroup("test test");
            g1.AddStudent("Z");
            Console.WriteLine(g1);
        }
    }
}
