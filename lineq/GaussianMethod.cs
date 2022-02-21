using comp_math_1.exceptions;
using comp_math_1.io;
using comp_math_1.matrix;
using comp_math_1.util;

namespace comp_math_1.lineq;

public static class GaussianMethod
{
    
    public static  Pair<DoubleMatrix> SolveEquation(DoubleMatrix a, DoubleMatrix b)
    {

        DoubleMatrix a1 = (DoubleMatrix) a.Clone();
        DoubleMatrix b1 = (DoubleMatrix) b.Clone();

        int k = 0;
        
        for ( int i = 0; i < a.getN(); i++)
        {
            if (ChoiceMainElem(a, b, i))
            {
                k++;
            }
            SubAllRows(a, b, i);
        }

        double det = 1;

        for (int i = 0; i < a.getN(); i++)
        {
            det *= a.GetElement(i, i);
        }

        det *= Math.Pow(-1, k);

        if (det == 0)
        {
            throw new ZeroDeterminantException();
        }
        
        Console.WriteLine("Determinant = " + det);
        
        ConsoleOutput.WriteEquation(a, b);
        DoubleMatrix x = new DoubleMatrix(a.getN(), 1);
        for (int i = a.getN() - 1; i >= 0; i--)
        {
            double s = 0;
            for (int j = i + 1; j < a.getM(); j++)
            {
                s += a.GetElement(i, j) * x.GetElement(j, 0);
            }
            x.SetElement((b.GetElement(i, 0) - s) / a.GetElement(i, i), i, 0);
        }

        DoubleMatrix r = new DoubleMatrix(a.getN(), 1);
        for (int i = 0; i < a1.getN(); i++)
        {
            double s = 0;
            for (int j = 0; j < a1.getM(); j++)
            {
                s += a1.GetElement(i, j) * x.GetElement(j, 0);
            }
            r.SetElement(s - b1.GetElement(i, 0), i, 0);
        }
        return new Pair<DoubleMatrix>(x, r);
    }
    
    private static bool ChoiceMainElem(DoubleMatrix a, DoubleMatrix b, int i) 
    {
        double max = Math.Abs(a.GetElement(i, i));
        int maxIndex = i;
        for (int j = i + 1; j < a.getN(); j++)
        {
            if (Math.Abs(a.GetElement(j, i)) > max)
            {
                max = Math.Abs(a.GetElement(j, i));
                maxIndex = j;
            }
        }
        if (maxIndex == i)
        {
            return false;
        }
        a.SwapRaws(i, maxIndex);
        b.SwapRaws(i, maxIndex);
        return true;
    }

    private static void SubRaw(DoubleMatrix a, DoubleMatrix b, int i1, int i2)
    {
        double c = a.GetElement(i2, i1) / a.GetElement(i1, i1);
        a.SetElement(0, i2, i1);
        for (int j = i1 + 1; j < a.getM(); j++)
        {
            a.SetElement(a.GetElement(i2, j) - c * a.GetElement(i1, j), i2, j);
        }
        b.SetElement(b.GetElement(i2, 0) - c * b.GetElement(i1, 0), i2, 0);
    }

    private static void SubAllRows(DoubleMatrix a, DoubleMatrix b, int i)
    {
        for (int j = i + 1; j < a.getN(); j++)
        {
            SubRaw(a, b, i, j);
        }
    }
}