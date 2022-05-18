using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP_Lab_15
{
    internal class Program
    {
        static bool isSafe(int[,] mat, int row, int col,int n)
        {
            int i, j;

            // перевіревірка рядка зліва 
            for (i = 0; i < col; i++)
                if (mat[row, i] == 1)
                    return false;

            // перевірка верхньої діагоналі з лівого боку
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (mat[i, j] == 1)
                    return false;

            // перевірка нижньої діагоналі з лівого боку
            for (i = row, j = col; j >= 0 && i < n; i++, j--)
                if (mat[i, j] == 1)
                    return false;

            return true;
        }
        static bool Backtracking(int[,] mat, int col, int n)
        {           
            
            if (col >= n)
                return true;
            
            for (int i = 0; i < n; i++)
            {
               
                if (isSafe(mat, i, col,n))
                {                    
                    mat[i, col] = 1;                 

                    if (Backtracking(mat, col + 1,n) == true)
                        return true;
                   
                    mat[i, col] = 0;
                }
            }
         
            return false;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int n = 0;
            Console.Write("Введіть кількість ферзів = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int [,] mat = new int[n,n];
            for (int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
                    mat[i, j] = 0;

            if (Backtracking(mat, 0, n) != false)
            {
                Console.WriteLine(" Рішення:\n");
                Print(mat, n);
            }
            else
            {
                Console.WriteLine("Рішення не існує!");
            }

            Console.WriteLine();
        }

        private static void Print(int[,] mat, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format(" {0} ", mat[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
