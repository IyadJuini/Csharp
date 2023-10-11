// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World to C# !");


// ************Primitive Types*************

// ! Numbers
// int age = 35;
// float rate = 1.32f;
// double grade = 3.25;
// Console.WriteLine(age);
// Console.WriteLine(rate);
// Console.WriteLine(grade);

// ! Char String 
// char tag = 'A';
// Console.WriteLine($"My Programming Level is {tag} .");

// !Boolean 
// bool isValid = true ; 
// bool hasCovid = false ;

// ! Bytes 
// byte cOne = 0;
// byte cTow = 255;

// **********Complex types **********

// ! String 
// string FirstName = "John";
// System.Console.WriteLine($"My First Name is {FirstName} I am {age} years old .");

// ! Arrays
// int[] numbers = new int[5];
// numbers[0] = 1;
// numbers[1] = 2;
// numbers[2] = 3;
// numbers[3] = 4;
// numbers[4] = 5;


int[] numbers = new int[5] {1,2,3,4,5};

// Console.WriteLine(numbers);
// Console.WriteLine(numbers.Length);

// ! Lists 
List<int> gradeList = new List<int>();
gradeList.Add(22);
gradeList.Add(2);

List<string> NamesList = new List<string>() {"James","Alice","John","Sarah"};
// Console.WriteLine($"Length of the List :{NamesList.Count()}");
// NamesList.Add("Max");
// Console.WriteLine($"Length of the List after adding Max :{NamesList.Count()}");
// NamesList.Remove("John");
// Console.WriteLine($"Length of the LIst after Deleting John : {NamesList.Count()}");
// Console.WriteLine($"NamesList.Count()");
// Console.WriteLine(NamesList.IndexOf("Alice"));
// Console.WriteLine(NamesList.Contains("John"));

// ! Dictionary 
Dictionary<int, String> MyDict = new Dictionary<int, string>(){
    {1,"John"}, {2,"James"} 
};

// ! Enums 

Console.WriteLine(OrderStatus.Canceled);
var MyOrder = OrderStatus.Pending;
Console.WriteLine($"My order Status is {MyOrder}");
public enum OrderStatus{
    Pending=1 ,
    Canceled = 0,
    Delivered = 2,
}

