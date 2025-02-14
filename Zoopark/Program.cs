namespace zoopark;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<VeterinaryClinic>();
        services.AddSingleton<Zoo>();
        var provider = services.BuildServiceProvider();
        var zoo = provider.GetRequiredService<Zoo>();
        Random random = new Random();
        int number = 1;
        for (int i = 0; i <= 5; i++)
        {
            number += zoo.AddAnimal(new Monkey(random.Next(10) + 4, random.Next(10) + 1, number, random.Next(10) + 1)) ? 1 : 0;
            number += zoo.AddAnimal(new Rabbit(random.Next(10) + 3, random.Next(10) + 1, number, random.Next(10) + 1)) ? 1 : 0;
            number += zoo.AddAnimal(new Tiger(random.Next(10) + 5, random.Next(10) + 1, number)) ? 1 : 0;
            number += zoo.AddAnimal(new Wolf(random.Next(10) + 6, random.Next(10) + 1, number)) ? 1 : 0;
            
            zoo.AddThing(new Table(i * 2 + 1));
            zoo.AddThing(new Computer(i * 2 + 2));
        }

        Console.WriteLine(zoo.Report());
        Console.WriteLine("\nКонтактный зоопарк:");
        foreach (Herbo herbo in zoo.ContactList())
        {
            Console.WriteLine(herbo);
        }
        Console.WriteLine("\nВсе животные:");
        foreach (Animal animal in zoo.Animals)
        {
            Console.WriteLine(animal);
        }
        Console.WriteLine("\nВсе вещи:");
        foreach (Thing thing in zoo.Things)
        {
            Console.WriteLine(thing);
        }
        Console.WriteLine("\nТесты:");
        Test.RunTest();
    }
}