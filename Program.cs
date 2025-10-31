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
;

if (File.Exists("loginNames"))
{
    string[] lines = File.ReadAllLines("users.save");
    foreach (string line in lines)
}
User? active_user = null;
bool running = true;
while (running)


{
    if (active_user == null)

    {
        System.Console.WriteLine("1 Create Account");
        System.Console.WriteLine("2 Login");
        string menu = Console.ReadLine();

        switch (menu)
        {
            case "1": // Om jag skriver 1 så följer den instruktioner för att skapa konto
                Console.Clear(); // gör det rent o fint i consolen
                Console.WriteLine("Enter you email as username");
                string new_name = Console.ReadLine(); //Programmet sparar användarnamnet i lappen "new_name"
                Console.WriteLine("Enter your password for your account");
                string new_password = Console.ReadLine(); //Programmet sparar lösenordetr i lappen "new_password"
                users.Add(new User(new_name, new_password)); // Programmet skapar EN NY användar LAPP med min epost och lösen och lägger det i lådan USERS.
                Console.WriteLine("Congratz to your account!");
                File.AppendAllText("./loginNames.txt", new_name + "\n"); //Programmet skriver NER min nya epost adress i en textfil som heter Account_names.txt så att den finns kvar även om programmet stängs av.
                break; // slut

            case "2": // Om du skriver 2 så vill du logga in
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