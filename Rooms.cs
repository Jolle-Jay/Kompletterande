namespace app;

public enum RoomStatus

{
    Available,
    Occupied,
    Cleaning,
    Maintenance,
}
public class Room
{


    public int roomNumber;
    public RoomStatus Status;
    public string guestName;



}