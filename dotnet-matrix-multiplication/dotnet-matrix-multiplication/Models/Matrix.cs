namespace dotnet_matrix_multiplication.Models
{
	public class Matrix
	{
		public int[][] Data { get; set; }

		public Matrix() { }

        public Matrix( int[][] data)
        {           
			Data = data;
        }
    }
}
