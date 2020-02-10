using System;
using System.Text.RegularExpressions;

namespace PigLatinLab
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Hello friend, welcome to the Pig Latin Translator");
            do
            {
                Console.Write($"\nPlease enter a word to translate: ");
                string input = Console.ReadLine().ToLower();

                Console.WriteLine($"\n{PigLatin(input)}");

            } while (UserContinue());
        }

        static string PigLatin(string input)
        {
            string pigLatinWord = null;

            if (Regex.IsMatch(input, @"^[a-zA-Z']+$"))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string c = input[i].ToString();

                    if ("aeiouAEIOU".Contains(c))
                    {
                        if (input.IndexOf(c) == 0)
                        {
                            pigLatinWord = input + "way";
                            break;
                        }
                        else
                        {
                            pigLatinWord = input.Substring(input.IndexOf(c)) + input.Substring(0, input.IndexOf(c)) + "ay";
                            break;
                        }
                    }
                    else
                    {
                        pigLatinWord = input;
                    }
                }
            }
            else
            {
                int specialCharIndex;
                string specialcharacterend = @"\|!#$%&/()=?»«@£§€{}.-;<>_,";
                foreach (var item in specialcharacterend)
                {
                    if (input.Contains(item) && (input.IndexOf(item) == (input.Length - 1)))
                    {
                        specialCharIndex = input.IndexOf(item);
                        specialcharacterend = input.Substring(0, specialCharIndex);

                        pigLatinWord = PigLatin(pigLatinWord) + input.Substring(specialCharIndex);
                    }

                    else if (input.Contains(item))
                    {
                        pigLatinWord = input;
                    }
                }

            }
            return pigLatinWord;
        }
        static bool UserContinue()
        {
            char key;
            do
            {
                Console.Write("\nWould you like to order anything else? Please enter (y/n) ");
                key = Console.ReadKey().KeyChar;
                key = char.ToLower(key);
                if (key == 'n')
                {
                    return false;
                }
                Console.WriteLine();

            } while (key != 'y');
            return true;
        }

    }
}
