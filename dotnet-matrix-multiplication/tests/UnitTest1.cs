

using dotnet_matrix_multiplication.Services;
using dotnet_matrix_multiplication.Models;

namespace tests
{
	[TestFixture]
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		public static IEnumerable<TestCaseData> Generator()
		{
			var matrixA = new int[2][];
			matrixA[0] = new int[3] { 1, 2, 3 };
			matrixA[1] = new int[3] { 1, 2, 3 };

			var matrixB = new int[3][];
			matrixB[0] = new int[3] { 1, 2, 3 };
			matrixB[1] = new int[3] { 1, 2, 3 };
			matrixB[2] = new int[3] { 1, 2, 3 };

			var result = new int[2][];
			result[0] = new int[3] { 6, 12, 18 };
			result[1] = new int[3] { 6, 12, 18 };


			yield return new TestCaseData(matrixA, matrixB, result);

			matrixA = new int[1][];
			matrixA[0] = new int[3] { 1, 2, 3 };

			matrixB = new int[3][];
			matrixB[0] = new int[1] { 1 };
			matrixB[1] = new int[1] { 2 };
			matrixB[2] = new int[1] { 3 };

			result = new int[1][];
			result[0] = new int[1] { 14 };

			yield return new TestCaseData(matrixA, matrixB, result);
		}

		[Test]
		[TestCaseSource(nameof(Generator))]
		public void MultiplicationIsCorrect(int[][] matrixA, int[][] matrixB, int[][] result)
		{
			var subject = new MatrixOperator();
			var matrix1 = new Matrix(matrixA);
			var matrix2 = new Matrix(matrixB);

			var resultm = subject.Multiply(matrix1, matrix2);

			Assert.IsTrue(_areMatricesEqual(result, resultm.Data));



		}

		[Test]
		public void MultiplicationThrowsErrorIfMultiplicationIsNotPossible()
		{
			var matrixA = new int[1][];
			matrixA[0] = new int[2] { 1, 2 };

			var matrixB = new int[3][];
			matrixB[0] = new int[3] { 1,2,3 };
			matrixB[1] = new int[3] { 1, 2, 3 };
			matrixB[2] = new int[3] { 1, 2, 3 };

			var matrixAA = new Matrix(matrixA);
			var matrixBB = new Matrix(matrixB);

			var subject = new MatrixOperator();
			var ex = Assert.Throws<ArgumentException>(() => subject.Multiply(matrixAA, matrixBB));

			Assert.AreEqual(ex.Message, "The product is not possible since the number of columns in matrix A is different than the number of rows in matrix B");

		}

		private bool _areMatricesEqual(int[][] sot, int[][] result)
		{
			if (sot.Length != result.Length)
				return false;

			for(int i = 0; i < sot.Length; i++)
			{
				if (sot[i].Length != result[i].Length)
					return false;

				for(int j = 0; j < sot[0].Length; j++)
				{
					if (sot[i][j] != result[i][j])
						return false;
				}

			}

			return true;

		}
	}
}