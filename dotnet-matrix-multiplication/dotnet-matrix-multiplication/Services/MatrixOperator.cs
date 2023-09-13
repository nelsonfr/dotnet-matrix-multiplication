using dotnet_matrix_multiplication.Models;

namespace dotnet_matrix_multiplication.Services
{
	public class MatrixOperator : IMatrixOperator
	{
		public Matrix Multiply(Matrix matrixA, Matrix matrixB)
		{
			if(matrixA.Data == null || matrixB.Data == null)
			{
				throw new ArgumentNullException("Matrix A nor Matrix B can be null");
			}

			var matrixAWidth = matrixA.Data[0].Length;
			var matrixAHeight = matrixA.Data.Length;
			var matrixBWidth = matrixB.Data[0].Length;
			var matrixBHeight = matrixB.Data.Length;

			if(matrixAWidth != matrixBHeight)
			{
				throw new ArgumentException("The product is not possible since the number of columns in matrix A is different than the number of rows in matrix B");
			}

			//var newMatrixData = new int[matrixA.Height, matrixB.Width];
			var newMatrixData = new int[matrixAHeight][];

			for (int i = 0; i < matrixAHeight; i++) 
			{
				newMatrixData[i] = new int[matrixBWidth];
				for (int j = 0; j < matrixBWidth; j++)
				{					
					var cell = 0;

					for(int k = 0; k < matrixAWidth; k++)
					{
						cell += matrixA.Data[i][ k] * matrixB.Data[k][j];
					}

					newMatrixData[i][j] = cell;
				}
			}

			return new Matrix(newMatrixData);
		}
	}
}
