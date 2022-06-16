using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retry = true;
            while(retry){
                Console.WriteLine("Welcome to String Shift!\n-----------------------------------");
                
                Console.WriteLine("Input a string:");
                string input = Console.ReadLine();
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
                        newstring = shiftstring(input, shift);
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

        public static string shiftstring(string original, int shift){
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
                string end = original.Substring(modshift, (original.Length-modshift));
                return end+lead;
            }

        } 
    }
}
