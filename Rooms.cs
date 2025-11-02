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


    public int roomNumber { get; set; }
    public RoomStatus Status { get; set; }
    public string guestName { get; set; }



}