// See https://aka.ms/new-console-template for more information



using System.Drawing;
using System.Globalization;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        // Crear un entrenador
        Coach coach = new Coach("John", "Doe", 45, "Head Coach", 20);

        // Crear jugadores
        Player player1 = new Player("Alice", "Smith", 25, "Forward");
        Player player2 = new Player("Bob", "Johnson", 28, "Midfielder");

        // Crear un club de fútbol
        FutbolClub club = new FutbolClub("Club XYZ", 1, "A great football club", "XYZ Stadium", coach);

        // Agregar jugadores al club
        club.AddPlayers(player1);
        club.AddPlayers(player2);

        // Mostrar información del club y sus miembros
        club.ShowTeamInformation();
    }
}

class PersonTeam
{
    public string Name { get; set; }
    public string LastName {  get; set; }
    public int Age { get; set; }
    public PersonTeam(string name, string lastName, int age)
    {
        LastName = lastName; 
        Name = name;
        Age = age;
    }

    public virtual void ShowInformation()
    {
        Console.WriteLine($"Name: {Name}" );
        Console.WriteLine($"Last Name: {LastName}");
        Console.WriteLine($"Age: {Age}" );

    }
 
}


class Player : PersonTeam
{
    public string Role { get; set; }

    // Constructor para la clase Player que llama al constructor de la clase base
    public Player(string name, string lastName, int age, string role)
        : base(name, lastName ,age) // Llama al constructor de la clase base
    {
        Role = role;
    }

    public override void ShowInformation()
    {
        base.ShowInformation();
        Console.WriteLine($"Role: {Role}");
    }
}


class Coach : PersonTeam
{
    public int YearsOfExperience { get; set; }
    public string Role { get; set; }

    public Coach(string name, string lastName, int age, string role, int yearsOfExperience) : base(name, lastName, age)
    {
        Role = role;
        YearsOfExperience = yearsOfExperience;
    }

    public override void ShowInformation()
    {
        base.ShowInformation();
        Console.WriteLine($"Role: {Role}");
        Console.WriteLine($"YearsOfExperience: {YearsOfExperience}");
    }

}


class FutbolClub
{
    public string NameOfTheClub { get; set; }
    public int IdOfTheClub { get; set; }
    public string DescriptionOfTheClub { get; set; }
    public string? Stadium { get; set; }
    public int NumberOfTeamsCreated;
    private List<Player> _players { get;  } = new List<Player>();
    private Coach _coach { get; set; }

    public FutbolClub(string nameOfTheClub, int idOfTheClub, string descriptionOfTheClub, string stadium, Coach coach)
    {
        NameOfTheClub = nameOfTheClub;
        IdOfTheClub = idOfTheClub;
        DescriptionOfTheClub = descriptionOfTheClub;
        Stadium = stadium;
        _players = new List<Player>();
        _coach = coach;



    }


    public void ShowTeamInformation()
    {
        Console.WriteLine($"Club Name: {NameOfTheClub}");
        Console.WriteLine($"Club ID: {IdOfTheClub}");
        Console.WriteLine($"Club Description: {DescriptionOfTheClub}");
        Console.WriteLine($"Stadium: {Stadium}");
        foreach(Player player in _players)
        {
            player.ShowInformation();
        }
        _coach.ShowInformation();

        Console.WriteLine();
    }

    public void AddPlayers(Player player)
    {
        _players.Add(player);
    }

    public void DeletePlayer(string name, string lastName)
    {
        Player playerToRemove = _players.FirstOrDefault(p => p.Name == name && p.LastName == lastName);

        if (playerToRemove != null)
        {
            _players.Remove(playerToRemove);
            Console.WriteLine($"El jugador {name} {lastName} ha sido eliminado.");
        }
        else
        {
            Console.WriteLine($"El jugador {name} {lastName} no se encontró en la lista.");
        }
    }


}
