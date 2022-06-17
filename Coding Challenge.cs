using System;
using System.Collections.Generic;
namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!\n-------------------------------\nWould you like to:\n1.Above Below\n2.Rotate String\n3.Quit");
            string input = Console.ReadLine();
            input = input.Trim(' ');
            if(input ==  "1" || input.ToLower().StartsWith("above") ){
                AboveBelowConsole();
            }else if(input == "2" || input.ToLower().StartsWith("rotate") ){
                StringRoationConsole();
            }else if(input == "3" || input.ToLower().StartsWith("quit")){

            }else{
                Console.WriteLine("Not a valid input!");
            }
                        

        }
        public static void AboveBelowConsole(){
            bool retry = true;
            while(retry){
                bool valid = false;
                Console.WriteLine("Welcome to AboveBelow!\n-----------------------------------");
                while(!valid){

                    Console.WriteLine("Input a list of integers seperated by commas:\n");
                    string liststring = Console.ReadLine();
                    liststring = liststring.Trim(' ');
                    liststring = liststring.Trim('[');
                    liststring = liststring.Trim(']');
                    string[] nums = liststring.Split(',');
                    List<int> numlist = new List<int>();
                    valid = true;
                    int tempint = 0;
                    foreach(var num in nums){
                        if(Int32.TryParse(num,out tempint)){
                            numlist.Add(tempint);                        
                        }else{
                            valid = false;
                            Console.WriteLine("Not a valid list of numbers");
                        }
                    }
                    valid = false;
                    int watermark = 0;
                    while(!valid){
                        Console.WriteLine("Enter the watermark:\n");
                        string numstring = Console.ReadLine();
                        numstring = numstring.Trim(' ');
                        if(Int32.TryParse(numstring,out watermark)){
                            valid = true;
                        }else{
                            Console.WriteLine("Not a valid integer");
                        }
                    }
                     Dictionary<string,int> aboveBelowDict = AboveBelow(numlist, watermark);

                     Console.Write("above: ");
                     Console.WriteLine(aboveBelowDict["above"]);
                     Console.Write("below: ");
                     Console.WriteLine(aboveBelowDict["below"]);
                }
                Console.WriteLine("\nGo Again(Enter no to quit, anything else to continue)?");
                string cont = Console.ReadLine();
                if(cont.ToLower() == "no"){
                    retry = false;
                }


            }
        }

        public static Dictionary<string,int> AboveBelow(List<int> numlist, int watermark){
            int above = 0;
            int below = 0;
            Dictionary<string,int> aboveBelowDict = new Dictionary<string,int>();
            foreach(int i in numlist){
                if(i > watermark){
                    above++;
                }else if( i < watermark){
                    below++;
                }
            }

            aboveBelowDict.Add("above",above);
            aboveBelowDict.Add("below",below);
            return aboveBelowDict;

        }

        public static void StringRoationConsole(){
            bool retry = true;
            while(retry){
                Console.WriteLine("Welcome to String Roation!\n-----------------------------------");
                
                Console.WriteLine("Input a string:");
                string input = Console.ReadLine();
                input = input.Trim(' ');
                Console.WriteLine("\nHow far to shift?");
                int shift = 0;
                bool valid = false;
                string newstring = "";
                string input2 = "";
                while(!valid){
                    input2 = Console.ReadLine();
                    if(input2 == "quit"){
                        valid = true;
                        retry = false;
                    }
                    else if(Int32.TryParse(input2, out shift)){
                        Console.WriteLine("\nShifted String:");
                        newstring = StringRotation(input, shift);
                        Console.WriteLine(newstring);
                        valid = true;
                    }
                    else{
                        Console.WriteLine("Not Valid! Please enter an integer!");
                    }
                }
                Console.WriteLine("\nShift another string(Enter no to quit, anything else to continue)?");
                string cont = Console.ReadLine();
                if(cont.ToLower() == "no"){
                    retry = false;
                }

            }
        }

        public static string StringRotation(string original, int shift){
            if(original.Length == 0){
                return original;
            }
            int modshift = Math.Abs(shift%original.Length);
            int negativeshift = original.Length - modshift;
            if(shift >= 0){

                string front = original.Substring(0, negativeshift);
                string tail = original.Substring(negativeshift, modshift);
                return tail+front;
            }
            else{
                string lead = original.Substring(0, modshift);
                string end = original.Substring(modshift, (negativeshift));
                return end+lead;
            }

        } 
    }
}
