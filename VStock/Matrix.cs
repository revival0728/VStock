namespace VStock
{
    public class Matrix
    {
        int[,] mat;

        public int Row { get; }
        public int Col { get; }

        public Matrix(int row, int col)
        {
            Row = row;
            Col = col;
            mat = new int[row, col];
        }
        public int this[int row, int col]
        {
            get { return mat[row, col]; }
            set { mat[row, col] = value; }
        }
        static int Mod(int n, int M)
        {
            if (M == 0) return n;
            if (n < M && n >= 0) return n;
            n %= M;
            if (n < 0) n += M;
            return n;
        }
        public static Matrix FromList(List<int> list, int M = 0)
        {
            if(list.Count == 1)
            {
                Matrix mone = new(1, 1);
                mone[0, 0] = list.First();
                return mone;
            }
            int n = list.Count / 2;
            Matrix matrix = new(n, n);
            for(int i = 0; i < n; ++i)
            {
                for(int j = 0; j < n; ++j)
                {
                    matrix[i, j] = Mod(Mod(list[i], M) * Mod(list[n + j], M), M);
                }
            }
            return matrix;
        }
        public Matrix mul(Matrix other, int M = 0)
        {
            if (Col != other.Row)
            {
                throw new ArgumentException("Matrix dimensions do not match for multiplication.");
            }
            Matrix result = new(Row, other.Col);
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < other.Col; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < Col; k++)
                    {
                        result[i, j] += Mod(Mod(this[i, k], M) * Mod(other[k, j], M), M);
                    }
                    result[i, j] = Mod(result[i, j], M);
                }
            }
            return result;
        }
    }
}
