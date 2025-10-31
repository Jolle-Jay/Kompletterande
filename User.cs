using System.ComponentModel.DataAnnotations;

namespace app;



public class User
{
    public string Email;

    string _password;

    public User(string username, string password)
    {
        Email = username;
        _password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Email && password == _password;
    }
}
