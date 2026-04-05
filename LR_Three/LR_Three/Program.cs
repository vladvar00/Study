using System;
using System.IO;

namespace LR_Three
{
    class Program
    {
        static void Main(string[] args)
        {

            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);


            int t = 0, N = 1;
            double X = 0, Y = 0, Z = 1;

            t = Convert.ToInt32(Console.ReadLine());
            N = Convert.ToInt32(Console.ReadLine());
            X = Convert.ToDouble(Console.ReadLine());
            Y = Convert.ToDouble(Console.ReadLine());

            int i;
            double member;


            if (t == 0)
            {
                for (i = 1; i <= N; i++)
                {
                    if (i % 2 == 1)
                        member = -(Math.Sin(Math.Pow(X, i + 1)) + Y) / (i + 1);
                    else
                        member = (Math.Cos(Math.Pow(Y, i + 1)) + X) / (i + 1);

                    Z += member;
                }
            }
            else if (t == 1)
            {
                i = 1;
                while (i <= N)
                {
                    if (i % 2 == 1)
                        member = -(Math.Sin(Math.Pow(X, i + 1)) + Y) / (i + 1);
                    else
                        member = (Math.Cos(Math.Pow(Y, i + 1)) + X) / (i + 1);

                    Z += member;
                    i++;
                }
            }
            else if (t == 2)
            {
                i = 1;
                do
                {
                    if (i % 2 == 1)
                        member = -(Math.Sin(Math.Pow(X, i + 1)) + Y) / (i + 1);
                    else
                        member = (Math.Cos(Math.Pow(Y, i + 1)) + X) / (i + 1);

                    Z += member;
                    i++;
                } while (i <= N);
            }


            Console.WriteLine(String.Format("{0:0.000000}", Z));


            Console.SetOut(save_out);
            new_out.Close();
            Console.SetIn(save_in);
            new_in.Close();
        }
    }
}