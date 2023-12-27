/*
Import namespace called system that has many classes
and useful functions (Without it we'd have to type
System.Console.Write)
*/
using System;
using System.Globalization;
using System.Text;

// Change interface size : Tools -> Options ->
// Environment -> Fonts and Colors -> Environment

// Defines our namespace is HelloWorld
namespace HelloWorld {
    // Our class name is Program
    public class Program
    {

        // ------ FUNCTIONS ------

        static void PrintArray(int[] intArray, string mess)
        {
            foreach (int k in intArray)
            {
                Console.WriteLine("{0} : {1} ", mess, k);
            }
        }

        private static bool GT10(int val)
        {
            return val > 10;
        }

        static double DoDivision(double x, double y)
        {
            if (y == 0)
            {
                // We are throwing an exception because
                // you can't divide by zero
                throw new System.DivideByZeroException();
            }
            return x / y;
        }

        private static void SayHello()
        {
            // Defines a variable that will store a string
            // of characters
            string name = "";

            Console.Write("What is your name : ");

            // Save the input the user provides
            name = Console.ReadLine();

            Console.WriteLine("Hello {0}", name);
        }

        // If you assign a value then it is optional to
        // pass
        static double GetSum(double x = 1, double y = 1)
        {
            double temp = x;
            x = y;
            y = temp;
            return x + y;
        }

        // ----- OUT PARAMETER -----
        // A parameter marked with out must be assigned
        // a value in the method
        static void DoubleIt(int x, out int solution)
        {
            solution = x * 2;
        }

        // ----- PASS BY REFERENCE -----
        // If a variable is passed by reference changes
        // to its value in the method effect it outside
        // of the method
        public static void Swap(ref int num3, ref int num4)
        {
            int temp = num3;
            num3 = num4;
            num4 = temp;
        }

        // ----- PARAMS -----
        // The params array must be the last parameter
        // in the list
        static double GetSumMore(params double[] nums)
        {
            double sum = 0;
            foreach (int i in nums)
            {
                sum += i;
            }
            return sum;
        }

        // ----- NAMED PARAMETERS -----
        static void PrintInfo(string name, int zipCode)
        {
            Console.WriteLine("{0} lives in the zip code {1}", name, zipCode);
        }

        // ----- METHOD OVERLOADING -----
        static double GetSum2(double x = 1, double y = 1)
        {
            return x + y;
        }

        static double GetSum2(string x = "1", string y = "1")
        {
            double dblX = Convert.ToDouble(x);
            double dblY = Convert.ToDouble(y);
            return dblX + dblY;
        }

        static void PaintCar(CarColor cc)
        {
            Console.WriteLine("The car was painted {0} with the code {1}",
                cc, (int)cc);
        }

        // ------ END OF FUNCTIONS ------

        // ------ ENUMS ------
        // An enum is a custom data type with
        // key value pairs. They allow you to
        // use symbolic names to represent data
        // The first number is 0 by default unless
        // you change it
        // You can define the underlying type
        // or leave it as int as default

        enum CarColor : byte
        {
            Orange = 1,
            Blue,
            Green,
            Red,
            Yellow
        }

        // Execution begins in the main function
        // static means this function can run without
        // creating an object
        // void means that this function doesn't return a value
        // args represent data that can be passed to our program
        // from the command line as an array of strings
        static void Main(string[] args)
        {
            // Prints Hello World on the console
            Console.WriteLine("Hello World!");

            // ------ CONSOLE METHODS -----
            // Change the text color in the console
            // Console.ForegroundColor = ConsoleColor.Black;

            // Change background color
            // Console.BackgroundColor = ConsoleColor.White;

            // Set background for whole console
            // Console.Clear();

            // Outputs text without a newline
            Console.Write("What is your name? ");

            // Stores data entered by user in name
            string name = Console.ReadLine();

            // Outputs Hello + value stored in name
            Console.WriteLine($"Hello {name}");

            // ------ VARIABLES ------
            // Used to store different types of data

            // Bools store true or false
            bool canIVote = true;

            // INTEGERS
            // Integers are 32-bit signed integers
            Console.WriteLine("Biggest Integer : {0}", int.MaxValue);
            Console.WriteLine("Smallest Integer : {0}", int.MinValue);

            // LONGS
            // Longs are 64-bit signed integers
            Console.WriteLine("Biggest Long : {0}", long.MaxValue);
            Console.WriteLine("Smallest Long : {0}", long.MinValue);

            // DECIMALS
            // Decimals store 128-bit precise decimal values
            // It is accurate to 28 digits
            decimal decPiVal = 3.1415926535897932384626433832M;
            decimal decBigNum = 3.00000000000000000000000000011M;
            Console.WriteLine("DEC : PI + bigNum = {0}", decPiVal + decBigNum);

            Console.WriteLine("Biggest Decimal : {0}", Decimal.MaxValue);

            // DOUBLES
            // Doubles are 64-bit float types
            Console.WriteLine("Biggest Double : {0}", Double.MaxValue);

            // It is precise to 14 digits
            double dblPiVal = 3.14159265358979;
            double dblBigNum = 3.00000000000002;
            Console.WriteLine("DBL : PI + bigNum = {0}", dblPiVal + dblBigNum);

            // FLOATS
            // Floats are 32-bit float types
            Console.WriteLine("Biggest Float : {0}", float.MaxValue.ToString("#"));

            // It is precise to 6 digits
            float fltPiVal = 3.141592F;
            float fltBigNum = 3.000002F;
            Console.WriteLine("FLT : PI + bigNum = {0}", fltPiVal + fltBigNum);

            // Other Data Types
            // byte : 8-bit unsigned int 0 to 255
            // char : 16-bit unicode character
            // sbyte : 8-bit signed int 128 to 127
            // short : 16-bit signed int -32,768 to 32,767
            // uint : 32-bit unsigned int 0 to 4,294,967,295
            // ulong : 64-bit unsigned int 0 to 18,446,744,073,709,551,615
            // ushort : 16-bit unsigned int 0 to 65,535

            // ---------- DATA TYPE CONVERSION ----------

            // You can convert from string to other types with Parse
            bool boolFromStr = bool.Parse("True");
            int intFromStr = int.Parse("100");
            double dblFromStr = double.Parse("1.234");

            // Convert double into a string
            string strVal = dblFromStr.ToString();

            // Get the new data type
            Console.WriteLine($"Data type : {strVal.GetType()}");

            // Cast double into integer (Explicit Conversion)
            // Put the data type to convert into between ()
            double dblNum = 12.345;
            Console.WriteLine($"Integer : {(int)dblNum}");

            // Cast integer into long (Implicit Conversion)
            // smaller size type to a larger size
            int intNum = 10;
            long longNum = intNum;

            // ---------- FORMATTING OUTPUT ----------

            // Format output for currency
            Console.WriteLine("Currency : {0:c}", 23.455);

            // Pad with zeroes
            Console.WriteLine("Pad with 0s : {0:d4}", 23);

            // Define decimals
            Console.WriteLine("3 Decimals : {0:f3}", 23.4555);

            // Add commas and decimals
            Console.WriteLine("Commas : {0:n4}", 2300);

            // ---------- STRINGS ----------
            // Strings store a series of characters
            string randString = "This is a string";

            // Get number of characters in string
            Console.WriteLine("String Length : {0}", randString.Length);

            // Check if string contains other string
            Console.WriteLine("String Contains is : {0}",
                randString.Contains("is"));

            // Index of string match
            Console.WriteLine("Index of is : {0}",
                randString.IndexOf("is"));

            // Remove number of characters starting at an index
            Console.WriteLine("Remove string : {0}",
                randString.Remove(10, 6));

            // Add a string starting at an index
            Console.WriteLine("Insert String : {0}",
                randString.Insert(10, "short "));

            // Replace a string with another
            Console.WriteLine("Replace String : {0}",
                randString.Replace("string", "sentence"));

            // Compare strings and ignore case
            // < 0 : str1 preceeds str2
            // = : Zero
            // > 0 : str2 preceeds str1
            Console.WriteLine("Compare A to B : {0}",
                String.Compare("A", "B", StringComparison.OrdinalIgnoreCase));

            // Check if strings are equal
            Console.WriteLine("A = a : {0}",
                String.Equals("A", "a", StringComparison.OrdinalIgnoreCase));

            // Add padding left
            Console.WriteLine("Pad Left : {0}",
                randString.PadLeft(20, '.'));

            // Add padding right
            Console.WriteLine("Pad Right : {0} Stuff",
                randString.PadRight(20, '.'));

            // Trim whitespace
            Console.WriteLine("Trim : {0}",
                randString.Trim());

            // Make uppercase
            Console.WriteLine("Uppercase : {0}",
                randString.ToUpper());

            // Make lowercase
            Console.WriteLine("Lowercase : {0}",
                randString.ToLower());

            // Use Format to create strings
            string newString = String.Format("{0} saw a {1} {2} in the {3}",
                "Paul", "rabbit", "eating", "field");

            // You can add newlines with \n and join strings with +
            Console.Write(newString + "\n");

            // Other escape characters
            // \' \" \\ \t \a

            // Verbatim strings ignore escape characters
            Console.WriteLine(@"Exactly What I Typed\n");

            // ------ ARRAYS ------
            // Arrays are just boxes inside of a bigger box
            // that can contain many values of the same
            // data type
            // Each item is assigned a key starting at 0
            // and incrementing up from there

            // Define an array which holds 3 values
            // Arrays have fixed sizes
            int[] favNums = new int[3];

            // Add a value to the array
            favNums[0] = 23;

            // Retrieve a value
            Console.WriteLine("favNum 0 : {0}", favNums[0]);

            // Create and fill array
            string[] customers = { "Bob", "Sally", "Sue" };

            // You can use var to create arrays, but the
            // values must be of the same type
            var employees = new[] { "Mike", "Paul", "Rick" };

            // Create an array of base objects which is the
            // base type of all other types
            object[] randomArray = { "Paul", 45, 1.234 };

            // GetType knows its true type
            Console.WriteLine("randomArray 0 : {0}",
                randomArray[0].GetType());

            // Get number of items in array
            Console.WriteLine("Array Size : {0}",
                randomArray.Length);

            // Use for loop to cycle through the array
            for (int j = 0; j < randomArray.Length; j++)
            {
                Console.WriteLine("Array {0} : Value : {1}",
                j, randomArray[j]);
            }

            // Multidimensional arrays
            // When you define an array like arrName[5] you
            // are saying you want to create boxes stacked
            // vertically

            // If you define arrName[2,2] you are saying
            // you want to have 2 rows high and 2 across
            string[,] custNames = new string[2, 2] { { "Bob", "Smith" },
                { "Sally", "Smith" } };

            // Get value in MD array
            Console.WriteLine("MD Value : {0}",
                custNames.GetValue(1, 1));

            // Cycle through the multidimensional array
            // Get length of multidimensional array column
            for (int j = 0; j < custNames.GetLength(0); j++)
            {
                // Get length of multidimensional array row
                for (int k = 0; k < custNames.GetLength(1); k++)
                {
                    Console.Write("{0} ", custNames[j, k]);
                }
                Console.WriteLine();
            }

            // An array like arrName[2,2,3] would be like a
            // stack of 3 spread sheets with 2 rows and 2
            // columns worth of data on each page

            // foreach can be used to cycle through an array
            int[] randNums = { 1, 4, 9, 2 };

            // You can pass an array to a function
            PrintArray(randNums, "ForEach");

            // Sort array
            Array.Sort(randNums);

            // Reverse array
            Array.Reverse(randNums);

            // Get index of match or return -1
            Console.WriteLine("1 at index : {0} ",
                Array.IndexOf(randNums, 1));

            // Change value at index 1 to 0
            randNums.SetValue(0, 1);

            // Copy part of an array to another
            int[] srcArray = { 1, 2, 3 };
            int[] destArray = new int[2];
            int startInd = 0;
            int length = 2;

            Array.Copy(srcArray, startInd, destArray,
                startInd, length);

            PrintArray(destArray, "Copy");

            // Create an array with CreateInstance
            Array anotherArray = Array.CreateInstance(typeof(int), 10);

            // Copy values in srcArray to destArray starting
            // at index 5 in destination
            srcArray.CopyTo(anotherArray, 5);

            foreach (int m in anotherArray)
            {
                Console.WriteLine("CopyTo : {0} ", m);
            }

            // ----- IF / ELSE / -----
            // Relational Operators : > < >= <= == !=
            // Logical Operators : && || !

            int age = 17;

            if ((age >= 5) && (age <= 7))
            {
                Console.WriteLine("Go to elementary school");
            }
            else if ((age > 7) && (age < 13))
            {
                Console.WriteLine("Go to middle school");
            }
            else if ((age > 13) && (age < 19))
            {
                Console.WriteLine("Go to high school");
            }
            else
            {
                Console.WriteLine("Go to college");
            }

            if ((age < 14) || (age > 67))
            {
                Console.WriteLine("You shouldn't work");
            }

            Console.WriteLine("! true = " + (!true));

            // Ternary Operator
            // Assigns the 1st value if true and otherwise
            // the 2nd
            bool canDrive = age >= 16 ? true : false;

            // Switch is used when you have limited options
            // The only way to use ranges is to stack
            // the possible values
            switch (age)
            {
                case 1:
                case 2:
                    Console.WriteLine("Go to Day Care");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("Go to Preschool");
                    break;
                case 5:
                    Console.WriteLine("Go to Kindergarten");
                    break;
                default:
                    Console.WriteLine("Go to another school");
                    // You can also jump out of a switch
                    // with goto
                    goto OtherSchool;
            }

        OtherSchool:
            Console.WriteLine("Elementary, Middle, High School");

            // To compare strings use Equals
            string name2 = "Derek";
            string name3 = "Derek";

            if (name2.Equals(name3, StringComparison.Ordinal))
            {
                Console.WriteLine("Names are Equal");
            }

            // ----- WHILE LOOP -----
            // You use the while loop when you want to execute
            // as long as a condition is true

            // This while loop will print odd numbers between
            // 1 and 10
            int i = 1;
            while (i <= 10)
            {
                // % (Modulus) returns the remainder of a
                // division. If it returns 0 that means the
                // value is even
                if (i % 2 == 0)
                {
                    i++;

                    // Continue skips the rest of the code and
                    // starts execution back at the top of the
                    // while
                    continue;
                }

                // Break jumps completely out of the loop
                if (i == 9) break;

                Console.WriteLine(i);
                i++;
            }

            // ----- DO WHILE LOOP -----
            // Use do while when you must execute the code
            // at least once

            // Generate a random number
            Random rnd = new Random();
            int secretNumber = rnd.Next(1, 11);
            int numberGuessed = 0;
            Console.WriteLine("Random Num : ", secretNumber);

            do
            {
                Console.Write("Enter a number between 1 & 10 : ");

                // Use Convert to switch the string into an int
                // Other Convert options : ToBoolean, ToByte,
                // ToChar, ToDecimal, ToDouble, ToInt64,
                // ToString, and they can convert from any
                // type to any other type
                numberGuessed = Convert.ToInt32(Console.ReadLine());

            } while (secretNumber != numberGuessed);

            Console.WriteLine("You guessed it is was {0}",
                secretNumber);


            // ----- EXCEPTION HANDLING -----
            // We use exception handling to catch errors
            // that could crash our program
            double num1 = 5;
            double num2 = 0;

            // Code that could cause an error is surrounded
            // by a try block
            try
            {
                Console.WriteLine("5 / 0 = {0}",
                    DoDivision(num1, num2));
            }

            // We catch the error and warn the user
            // rather then crash the program
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("You can't Divide by Zero");

                // Get additonal info on the exception
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);

            }

            // This is the default catch all for exceptions
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }

            // finally always runs and provides for clean up
            finally
            {
                Console.WriteLine("Cleaning Up");
            }

            // ----- STRINGBUILDER -----
            // Each time you change a string you are actually
            // creating a new string which is inefficient
            // when you are working with large blocks of text
            // StringBuilders actually change the text
            // rather then make a copy

            // Create a StringBuilder with a default size
            // of 16 characters, but it grows automatically
            StringBuilder sb = new StringBuilder("Random Text");

            // Create a StringBuilder with a size of 256
            StringBuilder sb2 = new StringBuilder("More Stuff that is very important", 256);

            // Get max size
            Console.WriteLine("Capacity : {0}", sb2.Capacity);

            // Get length
            Console.WriteLine("Length : {0}", sb2.Length);

            // Add text to StringBuilder
            sb2.AppendLine("\nMore important text");

            // Define culture specific formating
            CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");

            // Append a format string
            string bestCust = "Bob Smith";
            sb2.AppendFormat(enUS, "Best Customer : {0}", bestCust);

            // Output StringBuilder
            Console.WriteLine(sb2.ToString());

            // Replace a string
            sb2.Replace("text", "characters");
            Console.WriteLine(sb2.ToString());

            // Clear a string builder
            sb2.Clear();

            sb2.Append("Random Text");

            // Are objects equal
            Console.WriteLine(sb.Equals(sb2));

            // Insert at an index
            sb2.Insert(11, " that's Great");

            Console.WriteLine("Insert : {0}", sb2.ToString());

            // Remove number of characters starting at index
            sb2.Remove(11, 7);

            Console.WriteLine("Remove : {0}", sb2.ToString());

            // ---------- FUNCTIONS / METHODS ----------
            // Functions are used to avoid code duplication, provides
            // organization and allows use to simulate different
            // systems
            // <Access Specifier> <Return Type> <Method Name>(Parameters)
            // { <Body> }

            // Access Specifier determines whether the function can
            // be called from another class
            // public : Can be accessed from another class
            // private : Can't be accessed from another class
            // protected : Can be accessed by class and derived classes

            SayHello();

            // ----- PASSING BY VALUE -----
            // By default values are passed into a method
            // and not a reference to the variable passed
            // Changes made to those values do not effect the
            // variables outside of the method
            double x = 5;
            double y = 4;

            Console.WriteLine("5 + 4 = {0}",
                GetSum(x, y));

            // Even though the value for x changed in
            // method it remains unchanged here
            Console.WriteLine("x = {0}",
                x);

            // ----- OUT PARAMETER -----
            // You can pass a variable as an output
            // variable even without assigning a
            // value to it
            int solution;

            // A parameter passed with out has its
            // value assigned in the method
            DoubleIt(15, out solution);

            Console.WriteLine("15 * 2 = {0}",
                solution);

            // ----- PASS BY REFERENCE -----
            int num3 = 10;
            int num4 = 20;

            Console.WriteLine("Before Swap num1 : {0} num2 : {1}", num3, num4);

            Swap(ref num3, ref num4);

            Console.WriteLine("After Swap num1 : {0} num2 : {1}", num1, num2);

            // ----- PARAMS -----
            // You are able to pass a variable amount
            // of data of the same data type into a
            // method using params. You can also pass
            // in an array.
            Console.WriteLine("1 + 2 + 3 = {0}",
                GetSumMore(1, 2, 3));

            // ----- NAMED PARAMETERS -----
            // You can pass values in any order if
            // you used named parameters
            PrintInfo(zipCode: 15147,
                name: "Derek Banas");

            // ----- METHOD OVERLOADING -----
            // You can define methods with the same
            // name that will be called depending on
            // what data is sent automatically
            Console.WriteLine("5.0 + 4.0 = {0}",
                GetSum2(5.0, 4.5));

            Console.WriteLine("5 + 4 = {0}",
                GetSum2(5, 4));

            Console.WriteLine("5 + 4 = {0}",
                GetSum2("5", "4"));


            // ---------- DATETIME & TIMESPAN ----------

            // Used to define dates
            DateTime awesomeDate = new DateTime(1974, 12, 21);
            Console.WriteLine("Day of Week : {0}", awesomeDate.DayOfWeek);

            // You can change values
            awesomeDate = awesomeDate.AddDays(4);
            awesomeDate = awesomeDate.AddMonths(1);
            awesomeDate = awesomeDate.AddYears(1);
            Console.WriteLine("New Date : {0}", awesomeDate.Date);

            // TimeSpan
            // Used to define a time
            TimeSpan lunchTime = new TimeSpan(12, 30, 0);

            // Change values
            lunchTime = lunchTime.Subtract(new TimeSpan(0, 15, 0));
            lunchTime = lunchTime.Add(new TimeSpan(1, 0, 0));
            Console.WriteLine("New Time : {0}", lunchTime.ToString());

            // ----- ENUM -----
            CarColor car1 = CarColor.Blue;
            PaintCar(car1);

            // Waits for input from the user if you run the
            // ConsoleApp1.exe instead of instantly closing
            // The executable is in bin/Debug/net6.0
            Console.Read();
        }
    }
}
