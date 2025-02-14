namespace zoopark;

public interface IAlive
{
    int Food { get; set; }
    int Health { get; set; }
}

public interface IInventory
{
    int Number { get; set; }
}