namespace zoopark;

public abstract class Animal : IAlive, IInventory
{
    public int Food { get; set; }
    public int Health { get; set; }
    public int Number { get; set; }
    
    protected Animal(int food, int health, int number)
    {
        Food = food;
        if (health >= 1 && health <= 10)
        {
            Health = health;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(health), "1 <= health <= 10");
        }
        Number = number;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: Food = {Food}, Health = {Health}, Number = {Number}";
    }
}
public abstract class Herbo : Animal
{
    public int Kindness { get; set; }
    
    protected Herbo(int food, int health, int number, int kindness) : base(food, health, number)
    {
        if (kindness >= 1 && kindness <= 10)
        {
            Kindness = kindness;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(kindness), "1 <= kindness <= 10");
        }
    }
    
    public override string ToString()
    {
        return $"{base.ToString()}, Kindness = {Kindness}";
    }
}

public abstract class Predator(int food, int health, int number) : Animal(food, health, number);

public class Monkey(int food, int health, int number, int kindness) : Herbo(food, health, number, kindness);

public class Rabbit(int food, int health, int number, int kindness) : Herbo(food, health, number, kindness);

public class Tiger(int food, int health, int number) : Predator(food, health, number);

public class Wolf(int food, int health, int number) : Predator(food, health, number);

public abstract class Thing : IInventory
{
    public int Number { get; set; }
    protected Thing(int number) { Number = number; }

    public override string ToString()
    {
        return $"{GetType().Name}: Number = {Number}";
    }
}

public class Table(int number) : Thing(number);

public class Computer(int number) : Thing(number);

public class VeterinaryClinic
{
    public bool CheckHealth(Animal animal)
    {
        return animal.Health >= 5;
    }
}

public class Zoo
{
    private readonly VeterinaryClinic _clinic;
    public readonly List<Animal> Animals = new();
    public readonly List<Thing> Things = new();
    
    public Zoo(VeterinaryClinic clinic)
    {
        _clinic = clinic;
    }
    
    public bool AddAnimal(Animal animal)
    {
        if (_clinic.CheckHealth(animal))
        {
            Animals.Add(animal);
            Console.WriteLine($"Животное {animal.GetType().Name} №{animal.Number} добавлено в зоопарк");
            return true;
        }
        Console.WriteLine($"Животное {animal.GetType().Name} недостаточно здоровое и не добавлено в зоопарк");
        return false;
    }
    
    public void AddThing(Thing thing)
    {
        Things.Add(thing);
        Console.WriteLine($"Предмет {thing.GetType().Name} №{thing.Number} добавлен в зоопарк");
    }

    public string Report()
    {
        return $"Потребляется {Animals.Sum(animal => animal.Food)} еды в день, всего {Animals.Count} животных, из них {Animals.Count(animal => animal is Predator)} хищников и {Animals.Count(animal => animal is Herbo)} травоядных";
    }

    public List<Herbo> ContactList()
    {
        return Animals.OfType<Herbo>().Where(herbo => herbo.Kindness >= 5).ToList();
    }
}