using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public static class FundamentalFunctions
    {
        private static int ReadIntFromConsole() => Convert.ToInt32(Console.ReadLine());

        //private static int[] ConvertAllToInt(strArr as string[], separator as char) => Array.ConvertAll(strArr.Split(separator), int.Parse);
        public static void ValidateNumber()
        {
            Console.Write("Enter a number between 1 and 10: ");
            int num = ReadIntFromConsole();
            string msg = num >= 1 && num <= 10 ? "Valid" : "Invalid";
            Console.WriteLine("\n" + msg);
        }

        public static void BiggerNumber()
        {
            Console.WriteLine("Calculating the bigger number.");
            Console.Write("Num 1: ");
            int num1 = ReadIntFromConsole();
            Console.Write("\nNum 2: ");
            int num2 = ReadIntFromConsole();
            Console.WriteLine("\nBigger number is: " + (num1 > num2 ? num1 : num2));
        }

        public static void PortraitOrLandscape()
        {
            Console.WriteLine("Portrait or Landscape?");
            Console.Write("Width: ");
            int width = ReadIntFromConsole();
            Console.Write("\nHeight: ");
            int height = ReadIntFromConsole();
            Console.WriteLine("Picture is: " + (width > height ? "Landscape" : "Portrait"));
        }

        public static void SpeedingCamera()
        {
            Console.Write("Speed limit: ");
            int speedLimit = ReadIntFromConsole();
            Console.Write("\nSpeed of car: ");
            int carSpeed = ReadIntFromConsole();
            
            int diff = carSpeed - speedLimit;
            
            if (diff <= 0)
                Console.WriteLine("Ok");
            else if (diff <= 12)
                Console.WriteLine("Demerit points: " + diff * 5);
            else
                Console.WriteLine("License suspended.");
        }

        public static void DivisibleBy3()
        {
            int counter = 0;

            for(int i = 3; i < 100; i+=3)
            {
                counter++;
            }

            Console.WriteLine("Numbers divisible by 3 from 1 to 100: " + counter);
        }

        public static void AddNumbers()
        {
            Console.WriteLine("Adding numbers. Enter a number or \"ok\" to exit.");

            int sum = 0;
            string val = "";
            
            while(val != "ok")
            {
                Console.Write("\nEnter your value: ");
                val = Console.ReadLine();
                if (val != "ok")
                    sum += Convert.ToInt32(val);
            }

            Console.WriteLine("\n\nYour sum is: " + sum);
        }

        public static void FactorialPrint()
        {
            Console.Write("Enter the number you want the factorial of: ");
            int num = ReadIntFromConsole();
            Console.WriteLine("\nFactorial is: " + Factorial(num));
        }

        private static int Factorial(int num)
        {
            if (num == 1)
                return 1;

            return num * Factorial(num - 1);
        }

        public static void GuessTheNumber()
        {
            Random r = new Random();
            int numToBeGuessed = r.Next(1, 10);
            int guess;
            bool flag = false;

            Console.WriteLine("Guess the number!");
            
            for(int i = 1; i < 4; i++)
            {
                Console.Write("Guess " + i + ": ");
                guess = ReadIntFromConsole();

                if(guess == numToBeGuessed)
                {
                    flag = true;
                    Console.WriteLine("You won!");
                    break;
                }
            }

            if(!flag)
                Console.WriteLine("You lost!");
        }

        public static void Maximum()
        {
            Console.Write("Maximum calculator. Enter numbers separated by a comma: ");
            
            string[] nums = Console.ReadLine().Split(',');
            int max = Convert.ToInt32(nums[0]);
            int tempNum = 0;
            
            foreach (string num in nums)
            {
                tempNum = Convert.ToInt32(num);
                if (tempNum > max)
                    max = tempNum;
            }

            Console.WriteLine("Max is: " + max);
        }

        public static void FacebookLikes()
        {
            Console.WriteLine("Enter names of who likes your post. Press enter to exit.");
            string name = "";
            bool flag = false;
            List<string> names = new List<string>();

            while (!flag)
            {
                Console.Write("\nName: ");
                name = Console.ReadLine();

                if (name != "")
                    names.Add(name);
                else
                    flag = true;
            }

            Console.WriteLine("Your likes:");

            switch (names.Count)
            {
                case 1:
                    Console.WriteLine(names[0] + "likes your post.");
                    break;
                case 2:
                    Console.WriteLine(names[0] + " and " + names[1] + " like your post.");
                    break;
                case int _ when (names.Count > 2):
                    Console.WriteLine(names[0] + ", " + names[1] + " and " + (names.Count - 2) + " others like your post.");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
        }

        public static void NameReverser()
        {
            Console.WriteLine("Reverse name. Please enter your name:");
            string name = Console.ReadLine();
            char[] tempCharArr = name.ToCharArray();
            Array.Reverse(tempCharArr);
            string reversedName = new string(tempCharArr);
            Console.WriteLine("Your reversed name: " + reversedName);
        }

        public static void SortingUniques()
        {
            Console.WriteLine("Please enter 5 unique numbers.");
            List<int> uniqueNums = new List<int>();
            int userNum;

            while (uniqueNums.Count != 5)
            {
                Console.Write("\nEnter a number: ");
                userNum = ReadIntFromConsole();
                
                if(uniqueNums.Contains(userNum))
                    Console.WriteLine("Your number is already in the list!");
                else
                    uniqueNums.Add(userNum);
            }

            uniqueNums.Sort();
            Console.WriteLine("Sorted numbers: ");

            foreach(int num in uniqueNums)
                Console.Write(num + " ");
        }

        public static void DisplayUniques()
        {
            Console.WriteLine("\nEnter numbers. You can enter duplicates as well. Type Quit when you are done.");
            string val;
            int number;
            List<int> numbers = new List<int>();

            do
            {
                Console.Write("\nEnter a number: ");
                val = Console.ReadLine();

                if (Int32.TryParse(val, out number))
                    numbers.Add(number);

            } while (val != "Quit");

            var g = numbers.GroupBy(i => i);

            foreach (var grp in g)
                if(grp.Count() == 1)
                    Console.Write(grp.Key + " ");
        }

        public static void Print3Smallest()
        {
            Console.WriteLine("\nEnter numbers (at least 5) separated by a comma.");
            string val;
            bool flag = false;

            do
            {
                Console.Write("Enter the numbers here: ");
                val = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(val))
                    Console.WriteLine("\nYou didn't enter anything.");
                else
                {
                    if (val.Split(',').Count() < 5)
                        Console.WriteLine("\nYou didn't enter enough numbers");
                    else
                        flag = true;
                }

            } while (!flag);

            string[] numList = val.Split(',');
            int[] convertedNumList = new int[numList.Count()];

            for (int i = 0; i < numList.Length; i++)
                convertedNumList[i] = Convert.ToInt32(numList[i]);

            Array.Sort(convertedNumList);
            Console.WriteLine(String.Format("Smallest numbers: {0} {1} {2}", convertedNumList[0], convertedNumList[1], convertedNumList[2]));
        }

        public static void ConsecutiveCalculator()
        {
            Console.WriteLine("\nConsecutive calculator. Enter numbers separated by a hyphen.");
            Console.Write("Enter your numbers here: ");
            
            string val = Console.ReadLine();
            int[] nums = Array.ConvertAll(val.Split('-'), int.Parse);
            bool flag = false;
            bool isAscending = (nums[0] + 1) == nums[1]; 

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if(isAscending)
                {
                    if (nums[i+1] != (nums[i] + 1))
                    {
                        flag = true;
                        break;
                    }
                }
                else
                {
                    if(nums[i+1] != (nums[i] - 1))
                    {
                        flag = true;
                        break;
                    }
                }
            }

            if (!flag)
                Console.WriteLine("Consecutive");
            else
                Console.WriteLine("Not Consecutive");
        }

        public static void CheckForDuplicates()
        {
            Console.WriteLine("\nDuplicate checker. Enter numbers separated by a hyphen.");
            Console.Write("Enter your numbers here: ");
            
            string val = Console.ReadLine();

            if(!String.IsNullOrWhiteSpace(val))
            {
                int[] nums = Array.ConvertAll(val.Split('-'), int.Parse);
                int count = nums.GroupBy(i => i).Where(j => j.Count() > 1).Count();
                
                if(count > 0)
                    Console.WriteLine("Duplicate");
            }
        }

        public static void CheckValidTime()
        {
            Console.WriteLine("\nPlease enter a time value. Time should be between 00:00 and 23:59.");
            Console.Write("Enter you time here: ");
            
            string val = Console.ReadLine();

            if(!String.IsNullOrWhiteSpace(val))
            {
                try
                {
                    TimeSpan t = TimeSpan.Parse(val);
                    Console.WriteLine("Ok");
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Invalid Time");
                }
            }
            else
            {
                Console.WriteLine("Invalid Time");
            }

        }

        public static void ToPascalCase()
        {
            Console.WriteLine("\nConverting to pascal case. Please enter the string with words separated by spaces.");
            Console.Write("Enter you string here: ");

            string val = Console.ReadLine();
            string[] words = val.Split(' ');

            for (int i = 0; i < words.Length; i++)
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();

            Console.WriteLine("Pascal Case:");
            Console.WriteLine(String.Join("", words));
        }

        public static void VowelCounter()
        {
            Console.WriteLine("\nCounting vowels in a word.");
            Console.Write("Enter your word here: ");

            string val = Console.ReadLine();
            char[] vowels = new char[] { 'a', 'e', 'o', 'u', 'i' };
            int counter = 0;

            foreach (char c in val)
                if (vowels.Contains(c))
                    counter++;

            Console.Write("Number of vowels: " + counter + "\n");
        }

        private static string[] ReadingTxt(string filePath, char separator)
        {
            string text = System.IO.File.ReadAllText(filePath);
            text.Replace(",", "");
            string[] words = text.Split(separator);
            return words;
        }

        public static void WordCounter(string filePath)
        {
            Console.WriteLine("\nWords counter function.");
            string[] words = ReadingTxt(filePath, ' ');
            Console.WriteLine("The number of words in the file passed: " + words.Count());
        }

        public static void LongestWord(string filePath)
        {
            Console.WriteLine("\nLongest word searcher function.");
            
            string[] words = ReadingTxt(filePath, ' ');
            int maxLength = words[0].Length;
            int maxIndex = 0;

            for (int i = 0; i < words.Count(); i++)
                if(words[i].Length > maxLength)
                {
                    maxLength = words[i].Length;
                    maxIndex = i;
                }

            Console.WriteLine("The longest word in the file passed: " + words[maxIndex]);
        }
    }
}
