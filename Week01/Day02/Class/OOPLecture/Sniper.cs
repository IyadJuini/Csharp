public class Sniper : Soldier
{
    public double Precision {get; set;}
    public double EagleEye {get; set;}
    public int MaxRange {get; set;}
    public string Weapon { get; set; }
    public bool IsFire { get;set; }
    public int NumberOfBullets { get;set; }
    // Constructors
    public Sniper(string name, int age,int maxRange ):base(name, age)
    {
        Precision = 0.8;
        EagleEye = 0.75;
        MaxRange = maxRange;
        Weapon = "Sniper";
        IsFire = true;
        NumberOfBullets = 30;
    }

    // Methods
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Precision: {Precision} Pts\n EagleEye : {EagleEye} Pts\n Maw Range : {MaxRange} M");
    }
    public void UseWeapon()
    {
        Console.WriteLine($"[SHOOT] {Name} use his {Weapon} .")
    }
}