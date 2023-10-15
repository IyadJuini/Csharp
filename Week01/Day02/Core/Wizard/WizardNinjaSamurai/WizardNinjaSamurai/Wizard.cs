
class Wizard : Human
{
    public Wizard(string name, int str, int dex) :
    base(name, str, 25, dex, 50)
    {

    }
    public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        Health += dmg;
        System.Console.WriteLine($"{Name} attacked {target.Name} by {dmg} damage");
        System.Console.WriteLine(Name + " Health is " + Health);
        System.Console.WriteLine(target.Name + " Health is " + target.Health);
        return target.Health;

    }
    public void Heal(Human target)
    {
        int heal = Intelligence * 3;
        target.Health += heal;
        System.Console.WriteLine($"{Name} heal {target.Name} by {heal} HP points!");
        System.Console.WriteLine($"{target.Name} health is now {target.Health}");
    }

}