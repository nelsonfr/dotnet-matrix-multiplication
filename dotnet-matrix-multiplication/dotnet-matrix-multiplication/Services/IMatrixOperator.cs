using dotnet_matrix_multiplication.Models;

namespace dotnet_matrix_multiplication.Services
{
	public interface IMatrixOperator
	{
		public Matrix Multiply(Matrix matrixA, Matrix matrixB);
	}
}
