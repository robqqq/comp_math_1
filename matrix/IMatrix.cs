namespace comp_math_1.matrix;

public interface IMatrix<T>
{

    int getN();

    int getM();
    
    T GetElement(int i, int j);

    void SetElement(T el, int i, int j);

    void SwapRaws(int i1, int i2);

    void SwapColumns(int j1, int j2);

    T GetDeterminant();
}