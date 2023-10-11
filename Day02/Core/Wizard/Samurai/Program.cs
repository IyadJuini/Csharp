

Wizard Veigar = new Wizard("Veigr",10,20);
Human Jinx = new Human("Jinx",10,10,10,15);
Samurai Yasuo = new Samurai("Yasuo",10,10,10);
Ninja Zed= new Ninja("Zed",10,10,10);

Console.WriteLine($"Before{Yasuo.Health}");
Zed.Attack(Yasuo);
Console.WriteLine($"After Attack{Yasuo.Health}");
Yasuo.Meditate();
Console.WriteLine($"After{Yasuo.Health}");
