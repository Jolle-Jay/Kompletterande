namespace app;

public class Room
{
    public int Number;
    public bool Occupied = false;

    public Room(int number, bool occupied)
    {
        Number = number;
        Occupied = occupied;

    }
}