using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void LearnDelegates(bool didILearn);
    public delegate int intDelegates();
    public delegate void intRefDelegates(ref int refInt);
    class Program
    {
        static void voidFunc1(bool a)
        {
            if (a)
                Console.WriteLine("I learned about delegates");
            else
                Console.WriteLine("What the heck are delegates");
            
        }
        //regular int functions
        static int intFunc1()
        {
            return  1;
        }
        static int intFunc2()
        {
            return  2;
        }
        static int intFunc3()
        {
            return  3;
        }

        //Reference functions
        static void intRefFunc1(ref int x)
        {
            x *= 1;
        }
        static void intRefFunc2(ref int x)
        {
            x *= 2;
        }
        static void intRefFunc3(ref int x)
        {
            x *= 3;
        }

        static void Main(string[] args)
        {
            Program P = new Program();

            //intialize the delegate
            LearnDelegates f = voidFunc1;

            //use the delegate
            f(false);

            //set the delegate to something else
            f = delegate (bool a)
            {

                string strResult = a ? "I'm an anonymous delegate" : "Hey I'm trying to stay anonoymous";
                Console.WriteLine(strResult);
            };
            f(false);

            /*
             * f = intFunc1; 
             * This is not doable because f is LearnDelegate type which requires a void function
             * Therefore we must use a different delegate for intFunc1
             */

            //
           
            intDelegates intDelComp = intFunc1, intDel = intFunc2;

            intDelComp += intDel + intFunc3;

            int result = intDelComp();

            Console.WriteLine("\n\nComposed Delegates\nThe result is {0}", result);
            //The result is 3 because the delegate sends the last value obtained from 
            //The delegate chain

            intDelComp -= intFunc3;

            result = intDelComp();
            Console.WriteLine("Now the composed delegate returns: {0}", result);
            //now it's 2 because the last function is now intFunc2


            /*******************
             * 
             * Now with referencing
             * 
             * **********************/
            Console.WriteLine("\n\n Now we can used Composed Delegates with reference types");
            int startFive = 5;
            intRefDelegates intRefDelComp = intRefFunc1;

            intRefDelComp += intRefFunc2;
            intRefDelComp += intRefFunc3;

            Console.WriteLine("I am {0}", startFive);

            intRefDelComp(ref startFive);
            
            Console.WriteLine("Now after being passed through the all three fucntion I am {0}", startFive);

            Console.ReadLine();

        }
    }
}
