namespace GameEngine
{
    public class Equipment
    {
        internal Eq.Armor Armor { get; set; }
        internal Eq.Weapon Weapon { get; set; }
        // Konstruktor przypisuje obiekt no armor dziedziczący z armor
        // Z postaci wywolam metode zmieniajaca ekwipunek, ale logika jest w metodzie ekwipunku.
        // Czyli dwie metody - humanoid wywoluje metode ktora wywoluje metode z ekwipunku
        internal Equipment()
        {
            Armor = new Eq.NoArmor();
            Weapon = new Eq.NoWeapon();
        }
    }
}