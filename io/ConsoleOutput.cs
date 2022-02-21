using comp_math_1.matrix;

namespace comp_math_1.io;

public static class ConsoleOutput
{

    public static void WriteMatrix(DoubleMatrix matrix)
    {
        int maxLength = 0;
        for (int i = 0; i < matrix.getN(); i++)
        {
            for (int j = 0; j < matrix.getM(); j++)
            {
                if (maxLength < matrix.GetElement(i, j).ToString().Length)
                {
                    maxLength = matrix.GetElement(i, j).ToString().Length;
                }
            }
            
        }
        for (int i = 0; i < matrix.getN(); i++)
        {
            for (int j = 0; j < matrix.getM(); j++)
            {
                Console.Write(matrix.GetElement(i, j));
                for (int k = 0; k < maxLength - matrix.GetElement(i, j).ToString().Length + 1; k++)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }

    public static void WriteEquation(DoubleMatrix a, DoubleMatrix b)
    {
        int maxLength = 0;
        for (int i = 0; i < a.getN(); i++)
        {
            for (int j = 0; j < a.getM(); j++)
            {
                if (maxLength < a.GetElement(i, j).ToString().Length)
                {
                    maxLength = a.GetElement(i, j).ToString().Length;
                }
            }
            if (maxLength < b.GetElement(i, 0).ToString().Length)
            {
                maxLength = b.GetElement(i, 0).ToString().Length;
            }
        }
        for (int i = 0; i < a.getN(); i++)
        {
            for (int j = 0; j < a.getM(); j++)
            {
                Console.Write(a.GetElement(i, j));
                for (int k = 0; k < maxLength - a.GetElement(i, j).ToString().Length + 1; k++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write("| ");
            Console.WriteLine(b.GetElement(i, 0));
        }
    }
}