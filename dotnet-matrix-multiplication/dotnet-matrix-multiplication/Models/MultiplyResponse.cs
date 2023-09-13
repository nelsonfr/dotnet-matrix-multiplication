namespace dotnet_matrix_multiplication.Models
{
	public class MultiplyResponse
	{
		public Matrix MatrixA { get; set; }
		public Matrix MatrixB { get; set; }	
		public Matrix Result { get; set; }

        public MultiplyResponse(Matrix matrixA, Matrix matrixB, Matrix result)
        {
            MatrixA = matrixA;
			MatrixB = matrixB;
			Result = result;
        }
    }
}
