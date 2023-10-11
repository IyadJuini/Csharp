// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// ! 1 --------------------------
static void PrintNumbers ()
{
    for (int i =0; i< 256; i++){
        // Console.Write(i + " ");
    }
}

// PrintNumbers();

// ! -----------------------------

static void PrintOdds()
{
    // Print all of the odd integers from 1 to 255.
        for (int i =0; i< 256; i++){
            if ( i % 2 != 0){
                // Console.Write($"{i},");
            }
    }
}
PrintOdds();

// ! -----------------------------

static void PrintSum()
{
    // Print all of the numbers from 0 to 255, 
    // but this time, also print the sum as you go. 
    // For example, your output should be something like this:
    
    // New number: 0 Sum: 0
    // New number: 1 Sum: 1
    // New number: 2 Sum: 3
    int sum = 0;
    for (int i =0; i< 256; i++)
    {
        sum +=i;
        Console.WriteLine(i + " "+ sum);
    }
}
PrintSum();



