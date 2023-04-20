/*
                                                   Задача #3:

                                        Прокомментировать следующий код

 */


namespace Task_3
{
    class Foo
    {
        public virtual void Quux(int a)
        {
            Console.WriteLine("Foo.Quux(int)");
        }
    }
    class Bar : Foo
    {
        public override void Quux(int a)
        {
            Console.WriteLine("Bar.Quux(int)");
        }
        public void Quux(object a) // вызов
        {
            Console.WriteLine("Bar.Quux(object)");
        }
    }
    class Baz : Bar
    {
        public override void Quux(int a)
        {
            Console.WriteLine("Baz.Quux(int)");
        }
        public void Quux<T>(params T[] a) // вызов
        {
            Console.WriteLine("Baz.Quux(params T[])");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            new Bar().Quux(42); // Bar.Quux(object)
            new Baz().Quux(42); // Baz.Quux(params T[])

            // если при вызове некоторого метода в "текущем" классе находится подходящая сигнатура,
            //      то компилятор не будет даже смотреть на родительские классы. В данной задаче классы Bar и Baz
            //          имеют собственные версии метода Quux. Их сигнатуры подходят под передаваемый набор параметров,
            //              а значит они и буду вызваны, а перегруженный Quux базового класса будет проигнорирован.

            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }
    }
}