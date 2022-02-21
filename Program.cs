using comp_math_1.exceptions;
using comp_math_1.io;
using comp_math_1.lineq;
using comp_math_1.matrix;
using comp_math_1.util;

string? fok = null;

while (fok is null or not "f" and not "k")
{
    Console.WriteLine("Data from file (F) or from keyboard (K)?");
    fok = Console.ReadLine();
    if (fok is not null)
    {
        fok = fok.Trim();
        fok = fok.ToLower();
        if (fok is not "f" and not "k")
        {
            Console.Error.WriteLine("You have to write 'F' or 'K'");
        }
    }
    else
    {
        Console.Error.WriteLine("No input");
        return;
    }
}
StreamInput input;
if (fok == "f")
{
    Console.Write("Input file path: ");
    string? filepath = Console.ReadLine();
    if (filepath is null)
    {
        Console.Error.WriteLine("No input");
        return;
    }

    try
    {
        input = new StreamInput(new StreamReader(filepath));
    }
    catch (FileNotFoundException e)
    {
        Console.Error.WriteLine("File not found.");
        return;
    }
}
else
{
    input = new StreamInput(new StreamReader(Console.OpenStandardInput()));
    Console.Write("n = ");
}

Pair<DoubleMatrix> eq;
try
{
    eq = input.ReadEquation();
}
catch (Exception e) when (e is FormatException or IndexOutOfRangeException)
{
    Console.Error.WriteLine("Bad input");
    return;
}
try
{
    Pair<DoubleMatrix> res = GaussianMethod.SolveEquation(eq.First, eq.Second);
    Console.WriteLine("Vector of unknowns (X):");
    ConsoleOutput.WriteMatrix(res.First);
    Console.WriteLine("Vector of incompatibilities (R):");
    ConsoleOutput.WriteMatrix(res.Second);
}
catch (ZeroDeterminantException e)
{
    Console.Error.WriteLine("Determinant is zero => no resolves or infinity resolves");
}
