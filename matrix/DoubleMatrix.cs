using comp_math_1.exceptions;

namespace comp_math_1.matrix;

public class DoubleMatrix : IMatrix<double>, ICloneable
{
    private readonly double[,] _matrix;

    private double[,] Matrix
    {
        get => _matrix;
        set
        {
            if (value.GetLength(0) != _matrix.GetLength(0) ||
                value.GetLength(1) != _matrix.GetLength(1))
            {
                throw new IndexOutOfRangeException();
            }
            for (var i = 0; i < value.GetLength(0); i++)
            {
                for (var j = 0; j < value.GetLength(1); j++)
                {
                    _matrix[i, j] = value[i, j];
                }
            }
        }
    }

    public DoubleMatrix(int n, int m)
    {
        if (n < 1 || m < 1)
        {
            throw new IndexOutOfRangeException();
        }
        _matrix = new double[n, m];
    }

    public DoubleMatrix(double[,] matrix)
    {
        _matrix = matrix;
    }

    public int getN()
    {
        return _matrix.GetLength(0);
    }

    public int getM()
    {
        return _matrix.GetLength(1);
    }
    
    public double GetElement(int i, int j)
    {
        if (i >= _matrix.GetLength(0) || j >= _matrix.GetLength(1))
        {
            throw new IndexOutOfRangeException();
        }
        return _matrix[i, j];
    }

    public void SetElement(double el, int i, int j)
    {
        if (i >= _matrix.GetLength(0) || j >= _matrix.GetLength(1))
        {
            throw new IndexOutOfRangeException();
        }
        _matrix[i, j] = el;
    }

    public void SwapRaws(int i1, int i2)
    {
        if (i1 >= _matrix.GetLength(0) || i2 >= _matrix.GetLength(0))
        {
            throw new IndexOutOfRangeException();
        }
        for (var j = 0; j < _matrix.GetLength(1); j++)
        {
            (_matrix[i1, j], _matrix[i2, j]) = (_matrix[i2, j], _matrix[i1, j]);
        }
    }

    public void SwapColumns(int j1, int j2)
    {
        if (j1 >= _matrix.GetLength(1) || j2 >= _matrix.GetLength(1))
        {
            throw new IndexOutOfRangeException();
        }
        for (var i = 0; i < _matrix.GetLength(0); i++)
        {
            (_matrix[i, j1], _matrix[i, j2]) = (_matrix[i, j2], _matrix[i, j1]);
        }
    }

    public double GetDeterminant()
    {
        if (_matrix.GetLength(0) != _matrix.GetLength(1))
        {
            throw new NotSquareMatrixException();
        }
        switch (_matrix.GetLength(0))
        {
            case 1:
                return _matrix[0, 0];
            case 2:
                return _matrix[0, 0] * _matrix[1, 1] - _matrix[0, 1] * _matrix[1, 0];
        }
        double result = 0;
        for (var j = 0; j < _matrix.GetLength(1); j++)
        {
            result += _matrix[0, j] * GetAlgAddition(0, j);
        }
        return result;
    }

    private double GetAlgAddition(int i, int j)
    {
        return Math.Pow(-1, i + j) * GetMinor(i, j).GetDeterminant();
    }

    private DoubleMatrix GetMinor(int i, int j)
    {
        var resultData = new double[_matrix.GetLength(0) - 1, _matrix.GetLength(1) - 1];
        for (var i1 = 0; i1 < _matrix.GetLength(0); i1++)
        {
            for (var j1 = 0; j1 < _matrix.GetLength(1); j1++)
            {
                if (i1 < i && j1 < j)
                {
                    resultData[i1, j1] = _matrix[i1, j1];
                } 
                else if (i1 < i && j1 > j)
                {
                    resultData[i1, j1 - 1] = _matrix[i1, j1];
                }
                else if (i1 > i && j1 < j)
                {
                    resultData[i1 - 1, j1] = _matrix[i1, j1];
                }
                else if (i1 > i && j1 > j)
                {
                    resultData[i1 - 1, j1 - 1] = _matrix[i1, j1];
                }
            }
        }
        return new DoubleMatrix(resultData);
    }

    public object Clone()
    {
        return new DoubleMatrix((double[,]) _matrix.Clone());
    }
}