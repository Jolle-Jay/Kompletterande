using System.Data.SqlTypes;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;



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
    ;
    {

    }
    // KOD FÖR ATT LÄSA IN FRÅN Rooms.TXT OCH SPARA I LISTAN List<rooms>

    // Läser in alla rader och sparar varje rad i string array read. 
    string[] read = File.ReadAllLines("Rooms.txt"); //tvungen at göra en lista med linjer för att kunna addera det till txt fil

    // För varje rad i string array read så delar vi upp kollumnerna (spilt ',')
    foreach (string line in read)
    {
        string[] parts = line.Split(',');

        // Gör om string "rumnummer" till int roomNum
        int roomNum;
        int.TryParse(parts[0], out roomNum);

        // gör om string status till enum status
        RoomStatus status = (RoomStatus)Enum.Parse(typeof(RoomStatus), parts[1]);

        // sparar den i ett nytt room
        Room room = new Room(roomNum, status, parts[2]);

        // lägger till det skapade room i listan av rooms
        rooms.Add(room);
    }

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

// if (File.Exists("Rooms.txt")) 
// {
//     string[] lines = File.ReadAllLines("Rooms.txt"); // Läser in txt filen och ser statusen på rummen
//     foreach (string line in lines)
//     {
//         string[] details = line.Split(",");

//     }
// }



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
                System.Console.WriteLine("Occupied rooms:\n");

                string[] OpRooms = File.ReadAllLines("Rooms.txt");

                foreach (string line in OpRooms)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length >= 2 && parts[1].Trim() == "Occupied")
                    {
                        string roomNumber = parts[0];
                        string guestName;
                        if (parts.Length > 2)
                            guestName = parts[2];
                        else
                            guestName = "(No guest name)";
                        System.Console.WriteLine($"The room {roomNumber} are occupied by guest {guestName}");
                    }
                    else if (parts.Length >= 2 && parts[1].Trim() == "Maintenance")
                    {
                        string roomNumber = parts[0];
                        string guestname;
                        if (parts.Length > 2)
                            guestname = parts[2];
                        System.Console.WriteLine($"The room {roomNumber} is Unavailable right now.");
                    }

                }
                Console.ReadLine();
                break;

            case "3":
                Console.Clear();
                System.Console.WriteLine("These are all the free rooms");

                string[] ARooms = File.ReadAllLines("Rooms.txt");

                foreach (string banana in ARooms)
                {
                    string[] monkey = banana.Split(',');
                    if (monkey.Length >= 1 && monkey[1].Trim() == "Available") // statusen på rummen är [1] i array därför .Length för att den ska läsa hur många rader det finns och att 1 sen ska användas för Available
                    {
                        string roomNumber = monkey[0];
                        System.Console.WriteLine($"The room {roomNumber} is available.");
                    }
                }
                Console.ReadLine();
                break;

            case "4":// boka in en gäst i ett ledigt rum

                {
                    Console.Clear();
                    System.Console.WriteLine("These are the available rooms");

                    string[] BRooms = File.ReadAllLines("Rooms.txt"); // Lägger alla text filer i strängen BRooms
                    foreach (Room room in rooms) // Loopar igenom alla rummen
                    {
                        if (room.Status == RoomStatus.Available) // Om det är tillgängliga
                        {
                            System.Console.WriteLine($"Room {room.roomNumber}"); // Då skrivs roomnummerna ut
                        }
                    }

                    System.Console.WriteLine("What room number to book?");
                    int BBB; // User input i nummer
                    int.TryParse(Console.ReadLine(), out BBB); // Som jag gör om till sträng

                    Room selectedRoom = null; //Måste göra något som kan hålla allt det jag vill skriva i och sätta det som null för att börja lägga in saker

                    {
                        foreach (Room room in rooms)
                        {

                            {
                                if (room.roomNumber == BBB) // Om input är samma som rumnummer som finns
                                {
                                    selectedRoom = room; //Lägger in room i SRoom efter jag har sagt att chosenNumber faktiskt är lika med ett RoomNumber
                                    break;
                                }
                            }
                        }
                        if (selectedRoom != null) // När då selecteROOM inte är null så kan jag göra det occupied och lägga in ett nammn
                        {
                            if (selectedRoom.Status == RoomStatus.Available) // Om det status är available då kan jag 

                            {
                                System.Console.WriteLine("What is the name of the guest?");
                                string guestName = Console.ReadLine(); // skriva in ett gästnamn

                                selectedRoom.Status = RoomStatus.Occupied; // DEt blir occupied


                                selectedRoom.guestName = guestName; // Lägger in variabeln i valda rummets enum

                                System.Console.WriteLine($"Room {selectedRoom.roomNumber} booked!");
                            }
                            else
                            {
                                System.Console.WriteLine("That room not available fool!");
                            }

                            List<string> lines = new List<string>();
                            foreach (Room room in rooms)
                            {
                                lines.Add($"{room.roomNumber}, {room.Status}, {room.guestName}");
                            }
                            File.WriteAllLines("Rooms.txt", lines);
                        }

                    }
                    Console.ReadLine();
                }
                break;

            case "5":
                {
                    Console.Clear();
                    System.Console.WriteLine("You wanna check out a guest eh?");
                    string[] Rbook = File.ReadAllLines("Rooms.txt");

                    foreach (Room room in rooms)
                    {
                        if (room.Status == RoomStatus.Occupied)
                        {

                            System.Console.WriteLine($"These are the Occupied rooms {room.roomNumber} by guest {room.guestName}");
                        }
                    }

                    System.Console.WriteLine("Which room number do you want to check out?");
                    int inputNumber;
                    int.TryParse(Console.ReadLine(), out inputNumber);

                    Room selectedRoom = null;

                    foreach (Room room in rooms)
                    {
                        if (room.roomNumber == inputNumber)
                        {
                            selectedRoom = room;
                            break;
                        }
                    }
                    if (selectedRoom != null && selectedRoom.Status == RoomStatus.Occupied)
                    {


                        selectedRoom.Status = RoomStatus.Available;
                        selectedRoom.guestName = "";
                        System.Console.WriteLine($"The room {selectedRoom.roomNumber} is available! ");

                    }
                    List<string> lines = new List<string>();
                    foreach (Room room in rooms)
                    {
                        lines.Add($"{room.roomNumber}, {room.Status}, {room.guestName}");
                    }
                    File.WriteAllLines("Rooms.txt", lines);


                    Console.ReadLine();




                }
                break;

            case "6":
                {
                    Console.Clear();
                    System.Console.WriteLine("Choose what room for Maintenance");
                    string[] Rbook = File.ReadAllLines("Rooms.txt");

                    foreach (Room room in rooms)
                    {
                        if (room.Status == RoomStatus.Available)
                        {

                            System.Console.WriteLine($"These are the Availabe rooms {room.roomNumber}");
                        }
                    }

                    System.Console.WriteLine("Put the number for the room you want to choose.");
                    int chosenRoomNumber;
                    int.TryParse(Console.ReadLine(), out chosenRoomNumber);

                    Room selectedRoom = null;

                    foreach (Room room in rooms)
                    {

                        if (room.roomNumber == chosenRoomNumber)
                        {
                            selectedRoom = room; //Lägger in room i SRoom efter jag har sagt att chosenNumber faktiskt är lika med ett RoomNumber
                            break;
                        }

                    }
                    if (selectedRoom != null && selectedRoom.Status == RoomStatus.Available) // När då selecteROOM inte är null så kan jag göra det occupied och lägga in ett nammn
                    {

                        selectedRoom.Status = RoomStatus.Maintenance;

                        System.Console.WriteLine($"The Room {selectedRoom.roomNumber} is put for Maintenance!");
                    }


                    else
                    {
                        System.Console.WriteLine("That room not available fool!");
                    }

                    List<string> lines = new List<string>();
                    foreach (Room room in rooms)
                    {
                        lines.Add($"{room.roomNumber}, {room.Status}, {room.guestName}");
                    }
                    File.WriteAllLines("Rooms.txt", lines);
                    Console.ReadLine();

                }

                //markera att ett rum, temporärt inte är tillgängligt

                break;

            case "7":
                break;
        }
    }
}



