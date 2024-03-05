using System.ComponentModel.Design;
using System.Text;
using System.Text.Json;

public class Program
{
    private static void Main(string[] args)
    {
        Program program = new();
        Console.WriteLine("Login Systemet");
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Registér");

        var input = Console.ReadLine();



        switch (input)
        {
            case "1":
                Console.WriteLine("Username: ");
                string loginUsername = Console.ReadLine();
                Console.WriteLine("Password: ");
                string loginPassword = Console.ReadLine();
                program.Login(loginUsername, loginPassword);
                Console.ReadKey();
                break;
            case "2":
                Console.WriteLine("Username: ");
                string registerUsername = Console.ReadLine();
                Console.WriteLine("Password: ");
                string registerPassword = Console.ReadLine();
                program.Register(registerUsername, registerPassword);
                break;
        }

        
    }
    public bool Login(string username, string password)
    {
        string jsonFile = File.ReadAllText("C:\\Users\\niels\\source\\repos\\HashingH5\\HashingH5\\Users.json");

        List<User> users = JsonSerializer.Deserialize<List<User>>(jsonFile);

        foreach (User user in users)
        {
            if (user.Username == username)
            {
                string HashedPassword = Hash(password);
                if (HashedPassword == user.Password)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }

    public void Register(string username, string password)
    {
        User user = new User();
        user.Username = username;
        user.Password = password;

        List<User> users = new();
        string? jsonFile = File.ReadAllText("C:\\Users\\niels\\source\\repos\\HashingH5\\HashingH5\\Users.json");
        if (jsonFile != "")
        {
            users = JsonSerializer.Deserialize<List<User>>(jsonFile);
        }
        users.Add(user);
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText("C:\\Users\\niels\\source\\repos\\HashingH5\\HashingH5\\Users.json", json);
    }

    public string Hash(string input)
    {
        byte[] asciiBytes = Encoding.ASCII.GetBytes(input);
        byte sum = 0;
        foreach (byte b in asciiBytes)
        {
            sum += b;
        }

        return Convert.ToString(Convert.ToInt32(sum) % 32);
    }
}

public class User()
{
    public string Username { get; set; }
    public string Password { get; set; }
}