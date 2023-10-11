public class Centaur : Monster
{
    public double Speed { get; set; }
    public double Strength { get; set; }
    public double Armor { get; set; }


    public Centaur(string name, double power, bool isImmortal, string powerType) : base(name, power, isImmortal, powerType)
    {
        Speed = 1.0;
        Strength = 0.9;
        Armor = 0.85;
    }
}
