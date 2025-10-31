using System.IO;

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
    new Room(1, false);
    new Room(2, true);
    new Room(3, false);
    new Room(4, false);
    new Room(5, false);
    new Room(6, false);
    new Room(7, false);
    new Room(8, false);
    new Room(9, false);
    new Room(10, false);

}
User? active_user = null;
bool running = true;
while (running)


{
    if (active_user == null)

    {
        System.Console.WriteLine("1 For login");
        string menu = Console.ReadLine();

        switch (menu)
        {
            case "1":
                foreach (User user in users)
                    active_user = user;
                break;
                // case "1":
                //     {
                //         Console.Clear();
                //         string filePath = "loginNames.txt";
                //         Console.WriteLine("Enter Login details");
                //         string Email = Console.ReadLine();
                //         Console.Clear();
                //         System.Console.WriteLine("Enter password");
                //         string password = Console.ReadLine();
                //         string[] lines = File.ReadAllLines(filePath);

                //         foreach (string line in lines)
                //         {
                //             string[] parts = line.Split(',');

                //             if (parts.Length == 2)
                //             {
                //                 string email = parts[0].Trim();
                //                 string Password = parts[1].Trim();



                //                 foreach (User user in users)
                //                     if (email == Email && Password == password)
                //                         active_user = user;
                //             }
                //         }
                //     }
                //     break;
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
                break;

            case "3":
                break;

            case "4":
                break;

            case "5":
                break;

            case "6":
                break;

            case "7":
                break;
        }
    }
}