using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter your name: ");
            string nameInput = Console.ReadLine();

            Console.WriteLine("Enter your birthdate (MM/dd/yyyy): ");
            string birthdateInput = Console.ReadLine();

            // Validate the birthdate format using regex
            if (!Regex.IsMatch(birthdateInput, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$"))
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }

            DateTime enteredDate = DateTime.Parse(birthdateInput);
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - enteredDate.Year;


            Console.WriteLine($" {nameInput}. You are {age} years old!");

            string userInfo = $"Name: {nameInput}\nBirthdate: {birthdateInput}\nAge: {age}";
            File.WriteAllText("user_info.txt", userInfo);
            Console.WriteLine("User information saved to user_info.txt.");

            string fileContents = File.ReadAllText("user_info.txt");
            Console.WriteLine("Contents of user_info.txt:");
            Console.WriteLine(fileContents);


            Console.WriteLine("Enter a directory path: ");
            string directoryPath = Console.ReadLine();

            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Files in the specified directory:");
                string[] files = Directory.GetFiles(directoryPath);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }

            Console.WriteLine("Enter a string: ");
            string stringInput = Console.ReadLine();
            Console.WriteLine($"{stringInput} in upper-case is {stringInput.ToUpper()}"); 

            GC.Collect();
            Console.WriteLine($"Allocated memory is: {GC.GetTotalMemory(false)}");

            Console.ReadLine();
        }
    }
}
