namespace app;

public enum RoomStatus

{
    Available,
    Occupied,
    Maintenance,
}
public class Room
{


    public int roomNumber;
    public RoomStatus Status;
    public string guestName;

    public Room(int RoomNumber, RoomStatus status, string GuestName)
    {
        roomNumber = RoomNumber;
        Status = status;
        guestName = GuestName;
    }



}