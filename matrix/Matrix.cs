using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    public class Matrix<T> : IEnumerable<T> where T : struct
    {
        private T[,] matrix;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public T this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public Matrix(int rows, int cols)
        {
            matrix = new T[rows, cols];
            Rows = rows;
            Cols = cols;
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != b.Rows && a.Cols != b.Cols)
                throw new InvalidOperationException("Cannot perform operation on matrices of different length");

            Matrix<T> c = new Matrix<T>(a.Rows, a.Cols);

            for (int i = 0; i < a.matrix.GetLength(0); i++)
                for (int j = 0; j < a.matrix.GetLength(1); j++)
                    c[i, j] = (dynamic)a.matrix[i, j] + (dynamic)b.matrix[i, j];

            return c;
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != b.Cols && a.Cols != b.Cols)
                throw new InvalidOperationException("Cannot perform operation on matrices of different length");

            Matrix<T> c = new Matrix<T>(a.matrix.GetLength(0), a.matrix.GetLength(1));

            for (int i = 0; i < a.matrix.GetLength(0); i++)
                for (int j = 0; j < a.matrix.GetLength(1); j++)
                    c[i, j] = (dynamic)a.matrix[i, j] - (dynamic)b.matrix[i, j];

            return c;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Cols != b.Rows)
                throw new InvalidOperationException("Cannot perform operation on matrices of different length");

            Matrix<T> c = new Matrix<T>(a.Rows, b.Cols);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Cols; j++)
                    for (int k = 0; k < a.Cols; k++)
                        c[i, j] += (dynamic)a.matrix[i, k] * (dynamic)b.matrix[k, j];

            return c;
        }

        public static bool operator true(Matrix<T> M)
        {
            for (int i = 0; i < M.Rows; i++)
                for (int j = 0; j < M.Cols; j++)
                    if (M[i, j] == (dynamic)0)
                        return false;

            return true;
        }

        public static bool operator false(Matrix<T> M)
        {
            for (int i = 0; i < M.Rows; i++)
                for (int j = 0; j < M.Cols; j++)
                    if (M[i, j] == (dynamic)0)
                        return true;

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    sb.Append($"{this[i, j]} ");

                sb.Append("\n");
            }

            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    yield return this[i, j];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
