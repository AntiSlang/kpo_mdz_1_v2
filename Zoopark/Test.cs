using System.Diagnostics;

namespace zoopark;
static class Test
{
    public static void RunTest()
    {
        TestAnimalHealthBounds();
        TestZooAnimalAddition();
        TestContactZoo();
        TestFoodConsumption();
        Console.WriteLine("Все тесты пройдены успешно!");
    }

    static void TestAnimalHealthBounds()
    {
        try
        {
            new Monkey(5, 0, 1, 5);
            Debug.Fail("Ожидалось ArgumentOutOfRangeException из-за того что health не в пределе");
        }
        catch (ArgumentOutOfRangeException) { }

        try
        {
            new Monkey(5, 11, 1, 5);
            Debug.Fail("Ожидалось ArgumentOutOfRangeException из-за того что health не в пределе");
        }
        catch (ArgumentOutOfRangeException) { }
    }

    static void TestZooAnimalAddition()
    {
        var zoo = new Zoo(new VeterinaryClinic());
        var monkey = new Monkey(5, 6, 1, 5);
        bool added = zoo.AddAnimal(monkey);
        Debug.Assert(added, "Обезьяна должна быть добавлена");
        Debug.Assert(zoo.Animals.Contains(monkey), "В зоопарке должна быть обезьяна");
    }

    static void TestContactZoo()
    {
        var zoo = new Zoo(new VeterinaryClinic());
        var kindMonkey = new Monkey(5, 7, 2, 6);
        var unkindMonkey = new Monkey(5, 7, 3, 4);
        zoo.AddAnimal(kindMonkey);
        zoo.AddAnimal(unkindMonkey);

        var contactAnimals = zoo.ContactList();
        Debug.Assert(contactAnimals.Contains(kindMonkey), "Обезьяна с добротой должна быть в списке");
        Debug.Assert(!contactAnimals.Contains(unkindMonkey), "Обезьяна без доброты не должна быть в списке");
    }

    static void TestFoodConsumption()
    {
        var zoo = new Zoo(new VeterinaryClinic());
        zoo.AddAnimal(new Monkey(5, 7, 4, 6));
        zoo.AddAnimal(new Rabbit(3, 8, 5, 7));
        zoo.AddAnimal(new Tiger(10, 9, 6));
        int totalFood = zoo.Animals.Sum(a => a.Food);
        Debug.Assert(totalFood == 18, "Потребление еды должно быть 18");
    }
}
