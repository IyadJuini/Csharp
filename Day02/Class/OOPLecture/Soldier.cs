/*
class ? blueprint or templates to create objects
class : 
        Attributes/Fields : what the class cn have Data
        Methods/ : what the class can do or behave 
        Object : instance of the class.s
*/


public class Soldier
{
//    Attributes :Properties
// ! Types -- Attribute name --
        public String Name {get;set;}
        public int Age {get;set;}
        public double Power {get;set;}
        public double Health {get;set;}

// Constructor
        public Soldier(string name, int age)
        {
                Name = name;
                Age = age;
                Power = 0.5;
                Health = 1.0;
        }
        public Soldier(string name, int age, double power , double health)
        {
                Name = name;
                Age = age;
                Power = power;
                Health = health;
        }
// Methods
        public virtual void ShowInfo()
        {
                // Console.WriteLine($"Name:{Name}\n Age:{Age}\n Power : {Power} Pts\n Health : {Health} HP ");
                Console.WriteLine("------------------------ \n");
        }
        public int IncreaseAge()
        {
                Age += 1;
                return Age ;
        }
        public double Train(double amount)
        {
                Power += amount;
                return Power;
        }
        public void Attack(Soldier target, double damageRate)
        {
                target.Health -= Power*damageRate;
                // Console.WriteLine($"[ATTACK] Soldier {Name} attacked {target.Name} by Damage Rate equal to {damageRate} ");
        }
}