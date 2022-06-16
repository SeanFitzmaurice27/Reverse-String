using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string");
            string input = Console.ReadLine();
            Console.WriteLine("How far to shift?");
            int shift = 0;
            bool valid = false;
            string newstring = "";
            string input2 = "";
            while(!valid){
                input2 = Console.ReadLine();
                if(input2 == "quit"){
                    valid = true;
                }
                else if(Int32.TryParse(input2, out shift)){
                    newstring = shiftstring(input, shift);
                    Console.WriteLine(newstring);
                    valid = true;
                }
                else{
                    Console.WriteLine("Not Valid! Please enter an integer!");
                }
            }
            

        }

        public static string shiftstring(string original, int shift){
            int negativeshift = original.Length - shift;
            string front = original.Substring(0, negativeshift);
            string tail = original.Substring(negativeshift, shift );
            return tail+front;

        } 
    }
}
