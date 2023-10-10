class Ninja : Human
{
    public Ninja(string ninjaName, int str, int intelli, int hp) :
    base(ninjaName, str, intelli, 75, hp)
    { }
    public override int Attack(Human target)
    {
        int dmg = Dexterity;
        Random rand = new Random();
        int additionalDamagePercentage = 20;
        int randValueBetween0And99 = rand.Next(100);
        if (randValueBetween0And99 < additionalDamagePercentage)
        {
            dmg += 10;
        }
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}