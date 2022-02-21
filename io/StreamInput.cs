using comp_math_1.matrix;
using comp_math_1.util;

namespace comp_math_1.io;

public class StreamInput
{
    private readonly StreamReader _reader;

    public StreamInput(StreamReader reader)
    {
        _reader = reader;
    }

    public Pair<DoubleMatrix> ReadEquation()
    {
        int n = Convert.ToInt32(_reader.ReadLine());
        DoubleMatrix a = new DoubleMatrix(n, n);
        DoubleMatrix b = new DoubleMatrix(n, 1);
        for (int i = 0; i < n; i++)
        {
            string? input = _reader.ReadLine();
            if (input is null)
            {
                throw new NullReferenceException();
            }
            int inputIndex = 0;
            string curr = "";
            for (int j = 0; j < n; j++)
            {
                while (Char.IsWhiteSpace(input[inputIndex]))
                {
                    inputIndex++;
                }

                curr = "";
                while (!Char.IsWhiteSpace(input[inputIndex]))
                {
                    curr += input[inputIndex];
                    inputIndex++;
                } 
                a.SetElement(Convert.ToDouble(curr), i, j);
            } 
            while (Char.IsWhiteSpace(input[inputIndex]))
            {
                inputIndex++;
            }

            curr = "";
            while (inputIndex < input.Length && !Char.IsWhiteSpace(input[inputIndex]))
            {
                curr += input[inputIndex];
                inputIndex++;
            } 
            b.SetElement(Convert.ToDouble(curr), i, 0);
        }

        return new Pair<DoubleMatrix>(a, b);
    }
}