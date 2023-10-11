// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var john = new Soldier ("John", 35, 1.0,1.0);
Soldier james = new Soldier("James", 25);
// Console.WriteLine(john.Name);
// john.Name ="James";
// john.Age=99;
// Console.WriteLine (john.Age );
// john.ShowInfo();
// james.Attack(john, 0.5);
// james.ShowInfo();

Sniper sam = new Sniper("Sam", 41, 200);
sam.ShowInfo();

List<Soldier> Army = new List<Soldier>() 
{
    john,james
};
foreach (Soldier soldier in Army)
{
    soldier.ShowInfo();
}

Mermaid alice = new Mermaid("Alice", 0.65, true, "Magic Voice");
Console.WriteLine($"Alice Power Before : {alice.Power} Pts");
alice.Transform();
Console.WriteLine($"Alice Power After : {alice.Power} Pts");

//! NPC Non Playable Character 
var test = new Monster("Test" ,100, true, "Test");