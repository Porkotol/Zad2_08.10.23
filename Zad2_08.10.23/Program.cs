using System.IO.Pipes;

class Parent
{
    protected int Pole1;
    protected int Pole2;

    public Parent()
    {

    }

    public Parent(int pole1, int pole2)
    {
        this.Pole1 = pole1;
        this.Pole2 = pole2;
    }
    public void Print()
    {
        Console.WriteLine($"Номiнал: {Pole1}, Кiлькiсть купюр: {Pole2}");
    }
    public int Metod1()
    {
        return Pole1 * Pole2;
    }
}
class Child : Parent
{
    double Pole3;
    public Child(int pole1, int pole2, double pole3) : base(pole1, pole2)
    {
        this.Pole3 = pole3;
    }

    public double Metod2()
    {
        return base.Metod1() / Pole3;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int sumgrn=0;
        double sumusd=0;
        int trade = 37;

        for (int i = 0; i < 5; i++)
        {
            int nom = new[] { 1, 2, 5, 10, 20, 50, 100, 200, 500 }[random.Next(9)];
            int count = random.Next(1, 11);
            Parent parent = new Parent(nom, count);
            parent.Print();
            int sumu = parent.Metod1();
            sumgrn += sumu;
            Child child = new Child(nom,count,trade);
            double sumd = child.Metod2();
            sumusd += sumd;
        }

        Console.WriteLine($"Загальна сума в гривнях(UAH): {sumgrn}");
        Console.WriteLine($"Загальна сума в доларах(USD): {sumusd:F2}");
    }
}
