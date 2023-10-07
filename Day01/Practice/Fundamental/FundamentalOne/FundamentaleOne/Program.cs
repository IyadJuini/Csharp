

int i = 1;
while(i <=255)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        System.Console.WriteLine($"FizzBuzz");
    }
    else if (i % 5 == 0)
    {
        System.Console.WriteLine($"Buzz");
    }
    else if (i % 3 == 0)
    {
        System.Console.WriteLine($"Fizz");
    }
    i++;
}
