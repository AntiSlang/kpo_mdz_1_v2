using Xunit;
namespace zoopark;
public class UnitTest1
{
    private readonly VeterinaryClinic _clinic;
    private readonly Zoo _zoo;

    public UnitTest1()
    {
        _clinic = new VeterinaryClinic();
        _zoo = new Zoo(_clinic);
    }

    [Fact]
    public void AddAnimal_HealthAbove5_AnimalAdded()
    {
        var animal = new Monkey(5, 6, 1, 6);
        var result = _zoo.AddAnimal(animal);
        
        Assert.True(result);
        Assert.Contains(animal, _zoo.Animals);
    }

    [Fact]
    public void AddAnimal_HealthBelow5_AnimalNotAdded()
    {
        var animal = new Rabbit(5, 4, 2, 6);
        var result = _zoo.AddAnimal(animal);
        
        Assert.False(result);
        Assert.DoesNotContain(animal, _zoo.Animals);
    }

    [Fact]
    public void Report_CorrectData_ReturnsCorrectReport()
    {
        var monkey = new Monkey(5, 6, 1, 6);
        var tiger = new Tiger(7, 6, 2);

        _zoo.AddAnimal(monkey);
        _zoo.AddAnimal(tiger);
        
        var report = _zoo.Report();
        
        Assert.Contains("Потребляется 12 еды в день", report);
        Assert.Contains("всего 2 животных", report);
        Assert.Contains("1 хищников", report);
        Assert.Contains("1 травоядных", report);
    }

    [Fact]
    public void ContactList_KindnessAbove5_ReturnsCorrectAnimals()
    {
        var monkey1 = new Monkey(5, 6, 1, 6);
        var monkey2 = new Monkey(5, 6, 2, 4);
        _zoo.AddAnimal(monkey1);
        _zoo.AddAnimal(monkey2);

        var contactList = _zoo.ContactList();

        Assert.Contains(monkey1, contactList);
        Assert.DoesNotContain(monkey2, contactList);
    }
    
    [Fact]
    public void CheckHealth_HealthAbove5_ReturnsTrue()
    {
        var animal = new Monkey(5, 6, 1, 6);
        var clinic = new VeterinaryClinic();
        var result = clinic.CheckHealth(animal);

        Assert.True(result);
    }

    [Fact]
    public void CheckHealth_HealthBelow5_ReturnsFalse()
    {
        var animal = new Monkey(5, 4, 1, 6);
        var clinic = new VeterinaryClinic();
        var result = clinic.CheckHealth(animal);

        Assert.False(result);
    }
}