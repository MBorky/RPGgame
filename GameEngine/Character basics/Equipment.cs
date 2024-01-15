namespace GameEngine
{
    public class Equipment
    {
        Armor Armor { get; set; }
        Weapon Weapon { get; set; }
        // Konstruktor przypisuje obiekt no armor dziedziczący z armor
        // Z postaci wywolam metode zmieniajaca ekwipunek, ale logika jest w metodzie ekwipunku.
        // Czyli dwie metody - humanoid wywoluje metode ktora wywoluje metode z ekwipunku
    }
}