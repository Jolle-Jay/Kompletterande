using System.IO;
using System.Runtime.CompilerServices;


// l0gga in med uppgifter som ligger sparade i en fil
// se en lista av alla rum som har gäster just nu
// se en lista av alla lediga rum
// boka in en gäst i ett ledigt rum
// checka ut en gäst från ett upptaget rum
//markera att ett rum, temporärt inte är tillgängligt

using app;

List<User> users = new List<User>();
List<Room> rooms = new List<Room>();
{

    {
        new Room { roomNumber = 1, Status = RoomStatus.Occupied, guestName = "Hercules" };
        new Room { roomNumber = 2, Status = RoomStatus.Occupied, guestName = "Odin" };
        new Room { roomNumber = 3, Status = RoomStatus.Occupied, guestName = "Zora" };
        new Room { roomNumber = 4, Status = RoomStatus.Occupied, guestName = "Son-Goku" };
        new Room { roomNumber = 5, Status = RoomStatus.Available, };
        new Room { roomNumber = 6, Status = RoomStatus.Available, };
        new Room { roomNumber = 7, Status = RoomStatus.Available, };
        new Room { roomNumber = 8, Status = RoomStatus.Available, };
        new Room { roomNumber = 9, Status = RoomStatus.Available, };
        new Room { roomNumber = 10, Status = RoomStatus.Available, };
    }
    List<string> lines = new List<string>();
    foreach (Room room in rooms)
    {
        lines.Add($"{room.roomNumber},{room.Status},{room.guestName}");
    }
    File.WriteAllLines("Rooms.txt", lines);
}




if (File.Exists("loginNames.txt"))
{
    string[] lines = File.ReadAllLines("loginNames.txt"); // Reading all the lines in the loginNames txt
    foreach (string line in lines) // Loop through every line in lines
    {
        string[] data = line.Split(","); // read it in and divide / split it when there is a ,
        users.Add(new(data[0], data[1])); // add the User when the data from line 0 and line 1 is read in.
    }
}

if (File.Exists("Rooms.txt"))
{
    string[] lines = File.ReadAllLines("Rooms.txt");
    foreach (string line in lines)
    {
        string[] details = line.Split(",");

    }
}



User? active_user = null;
bool running = true;
while (running)


{
    if (active_user == null)

    {

        System.Console.WriteLine("1 Login");
        string menu = Console.ReadLine();

        switch (menu)
        {

            case "1": // Om du skriver 2 så vill du logga in
                Console.Clear();
                Console.WriteLine("Enter your email to login");
                string login_name = Console.ReadLine(); // Programmet sparar login namnet i lappen login_name
                Console.Clear();
                Console.WriteLine("Enter you password to login");
                string login_password = Console.ReadLine(); // programmet sparar login namnet i lappen login_password
                foreach (User user in users) // Programmet tar fram varje användar lapp (user) ur "users"-lådan en i taget
                {
                    if (user.TryLogin(login_name, login_password)) //Programmet frågar användar lappen "matchar e-posten och lösenordet du fick?
                    {
                        active_user = user; //""OM DET STÄMMER -----> lägg den matchande användar lappen på den tomma platsen "active_user"
                        break;
                    }
                }
                break;
        }
    }


    if (active_user != null)
    {

        Console.Clear();
        System.Console.WriteLine("Hello " + active_user.Email);
        System.Console.WriteLine("2 to show a list of all occupied rooms");
        System.Console.WriteLine("3 to see a list of all free rooms");
        System.Console.WriteLine("4 book in a guest in a free room");
        System.Console.WriteLine("5 check out a guest from a occupied room");
        System.Console.WriteLine("6 mark a room unavailable temporarly");

        string menu2 = Console.ReadLine();

        switch (menu2)
        {
            case "2":
                Console.Clear();
                foreach (var Room in rooms)
                {
                    if (Room.Status == RoomStatus.Occupied)
                    {
                        Console.WriteLine($"Room {Room.roomNumber} - Guest: {Room.guestName}");

                    }
                }

                Console.ReadLine();
                break;

            case "3":
                Console.Clear();
                System.Console.WriteLine("These are all the free rooms");

                foreach (var Room in rooms)
                {
                    if (Room.Status == RoomStatus.Available)
                    {
                        Console.WriteLine($"Room {Room.roomNumber} is available!");
                    }
                }
                break;

            case "4":
                {
                    Console.Clear();

                    foreach (var Room in rooms)
                    {
                        if (Room.Status == RoomStatus.Available)
                            System.Console.WriteLine($"These are the rooms available {Room.roomNumber}");

                    }

                    Console.Write("Enter which room you want to book");
                    int chosenRoomNumber;
                    int.TryParse(Console.ReadLine(), out chosenRoomNumber);
                    foreach (var Room in rooms)
                    {
                        if (Room.roomNumber == chosenRoomNumber)
                        {
                            Room.Status = RoomStatus.Occupied;
                            //Room.guestName = Console.ReadLine();
                        }
                    }
                    break;
                }

            case "5":
                break;

            case "6":
                break;

            case "7":
                break;
        }
    }
}