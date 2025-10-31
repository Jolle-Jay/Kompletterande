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