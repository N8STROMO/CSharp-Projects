using System;
namespace CSharpRevelExercises
{
    public class Exercise05_16
    {
        unsafe public static void Main(String[] args)
        {
            int i = 10;
            Console.WriteLine(i);

            TypedReference tr = __makeref(i);

            int* ptr = &i;
            IntPtr addr = (IntPtr)ptr;

            Console.WriteLine("I original pointer: " + addr);


            TestNoOut(i);
            Console.WriteLine("No out i: " + i);

            TestOut(out i);
            Console.WriteLine("Out i: " + i);

            Console.ReadKey();
        }

        unsafe public static void TestNoOut(int i)
        {
            int* ptr = &i;
            IntPtr addr = (IntPtr)ptr;

            Console.WriteLine("I pointer in no out: " + addr);
            i = 44;
        }

        unsafe public static void TestOut(out int i)
        {
            i = 50;
            fixed (int* ptr = &i){
                IntPtr addr = (IntPtr)ptr;

                Console.WriteLine("I pointer in out: " + addr);
            }
            
         
        }
        
    }
}
