using System.Formats.Asn1;
using System.Xml.Schema;

namespace c__scratchpad
{
  class Program
  {
    static void Main(string[] args)
    {
      #nullable disable
      PrintWelcomeMessage();
      
      while (true)
      {
        if (GetMode(0) == 1)
        {
          NumbersCalculator.NumbersMode();
        } else {
          DatesCalculator.DatesMode();
        }
      }
    }

    private static void PrintWelcomeMessage()
    {
      Console.WriteLine("");
      Console.WriteLine("Welcome to the calculator!");
      Console.WriteLine("==========================");
    }

    private static int GetMode(int num)
    {
      bool display = true;
      string userInput = "";

      while (display)
      {
        Console.WriteLine("");
        Console.WriteLine("Please choose a calculator mode?");
        Console.WriteLine("1 = Numbers");
        Console.WriteLine("2 = Dates");
        userInput = Console.ReadLine();
        CheckExitProgram(userInput);
        if (CheckNumber(0, userInput) > 0 & CheckNumber(0, userInput) < 3) display = false;
      }
      return int.Parse(userInput);
    }

    public static void CheckExitProgram(string operation)
    {
      if (operation == "E")
      {
        Environment.Exit(0);
      }
    }

    public static int CheckNumber(int num, string userInput)
    {
      bool success = int.TryParse(userInput, out num);
      return num;
    }
  }

  class NumbersCalculator
  {
    public string Operation { get; set; }
    public int Counter { get; set; }
    public int[] Numbers { get; set; }
    public double Result(){
      double total = 0;
      if (Operation == "*") total = 1;

      for (int i = 0; i < Numbers.Length; i++){
        if(Operation == "+"){
          total += Numbers[i];
        } else if(Operation == "-"){
            if (i == 0){
              total = Numbers[i];
            } else {
              total -= Numbers[i];
            }
        } else if(Operation == "*"){
          total *= Numbers[i];} 
        else if (Operation == "/"){
          if (i == 0){
            total = Numbers[i];
          } else {
            total /= Numbers[i];
          }
        }
      }
      return total;
    }

    public string DisplayResult(){
      return String.Format("The answer is {0}", Result());
    }

    public static void NumbersMode()
    {
      NumbersCalculator newNumbersCalc = new NumbersCalculator();
      //newNumbersCalc.Operation = GetOperation();
      GetOperation(newNumbersCalc);
      newNumbersCalc.Counter = int.Parse(GetCounter(newNumbersCalc.Operation));
      newNumbersCalc.Numbers = new int[newNumbersCalc.Counter];
      GetNumbers(newNumbersCalc.Numbers); 
      Console.WriteLine(newNumbersCalc.DisplayResult());
    }

    private static void GetOperation(NumbersCalculator newNumbersCalc)
    {
      bool display = true;
      string operation = "";
      while (display)
      {
        Console.Write("Please enter a valid operator: ");
        operation = Console.ReadLine();
        Program.CheckExitProgram(operation);
        if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
        {
          newNumbersCalc.Operation = operation; 
          display = false;
        }
        Console.Clear();
      }
      //return operation;
    }

    private static string GetCounter(string operation)
    {
      bool display = true;
      string userInput = "";

      while (display)
      {
        Console.Write("How many numbers do you want to {0}? ", operation);
        userInput = Console.ReadLine();
        if (Program.CheckNumber(0, userInput) > 0) display = false;
        Program.CheckExitProgram(userInput);
        Console.Clear();
      }
      return userInput;
    }

    private static int[] GetNumbers(int[] numbersArray)
    {
      string userInput = "";

      for (int i = 0; i < numbersArray.Length; i++)
      {
        bool display = true;
        while (display)
        {
          Console.Write("Please enter number {0}? ", i + 1);
          userInput = Console.ReadLine();
          if (Program.CheckNumber(0, userInput) > 0) display = false;
        }
        numbersArray[i] = int.Parse(userInput);
      }
      return numbersArray;
    }

    private static double PerformCalculations(double result, int[] numbersArray, string operation)
    {
      if (operation == "*")
      {
        result = 1;
      }

      for (int i = 0; i < numbersArray.Length; i++)
      {
        if (operation == "+")
        {
          result += numbersArray[i];
        }
        else if (operation == "-")
        {
          if (i == 0)
          {
            result = numbersArray[i];
          }
          else
          {
            result -= numbersArray[i];
          }
        }
        else if (operation == "*")
        {
          result *= numbersArray[i];
        }
        else if (operation == "/")
        {
          if (i == 0)
          {
            result = numbersArray[i];
          }
          else
          {
            result /= numbersArray[i];
          }
        }
      }
      return result;
    }

    private static void DisplayNumbersResult(double result)
    {
      Console.WriteLine("The answer is {0}", result);
      Console.WriteLine();
    }
  }

  class DatesCalculator
  {
    public DateTime UserDate { get; set; }
    public int DaysToAdd { get; set; }
    public DateTime CalculateDate(){
      return UserDate.AddDays(DaysToAdd);
    }
    public string DisplayDate(){
      return String.Format("The answer is {0}", CalculateDate());
    }

    public static void DatesMode()
    {
      DateTime date;
      DateTime endDate;
      int daysToAdd;

      //date = GetDate();
      date = GetDate();
      daysToAdd = GetDaysToAdd();
      endDate = CalculateDate(date, daysToAdd);
      DisplayDate(endDate);
    }

    private static DateTime GetDate()
    {
      DateTime date = DateTime.Today;
      string userInput;
      bool displayMessage = true;

      Console.WriteLine("Please enter a date: ");
      while (displayMessage)
      {
        userInput = Console.ReadLine();
        Program.CheckExitProgram(userInput);
        if (DateTime.TryParse(userInput, out date)) displayMessage = false;
      }
      return date;
    }

    private static int GetDaysToAdd()
    {
      bool display = true;
      string userInput = "";

      while (display)
      {
        Console.WriteLine("Plese enter the number of days to add: ");
        userInput = Console.ReadLine();
        Program.CheckExitProgram(userInput);
        if (Program.CheckNumber(0, userInput) > 0) display = false;
      }
      return int.Parse(userInput);
    }

    private static DateTime CalculateDate(DateTime date, int daysToAdd)
    {
      return date.AddDays(daysToAdd);
    }

    private static void DisplayDate(DateTime date)
    {
      Console.WriteLine("The answer is {0}", date.ToShortDateString());
      Console.WriteLine();
    }
  }

}