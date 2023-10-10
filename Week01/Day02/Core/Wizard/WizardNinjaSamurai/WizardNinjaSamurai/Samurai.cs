class Samurai : Human
{
    public Samurai(string name, int str, int intel, int dex, int hp = 200) :
    base(name, str, intel, dex, hp)
    {
    }
    public override int Attack(Human target)
    {
        int dmg = Strength * 2;
        if (target.Health < 50)
        {
            target.Health = 0;
        }
        else target.Health -= dmg;
        return target.Health;
    }
}