public class Monster
{
    public string Name { get; set; }
    public double Power { get; set; }
    public bool IsImmortal { get; set; }
    public string PowerType { get; set; }
    public Monster(string name, double power, bool isImmortal, string powerType)
    {
        Name = name;
        Power = power;
        IsImmortal = isImmortal;
        PowerType = powerType;
    }

    public void Transform()
    {
        Power += Power*2;
        System.Console.WriteLine(
            $"[TRANSFORM] {Name} has activated Monster Mode.\nPlease run ad never look behind."
            );
    }
}