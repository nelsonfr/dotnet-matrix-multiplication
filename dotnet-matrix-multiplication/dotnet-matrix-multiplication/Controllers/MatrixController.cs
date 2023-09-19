using dotnet_matrix_multiplication.Models;
using dotnet_matrix_multiplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_matrix_multiplication.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MatrixController : ControllerBase
	{
		private readonly IMatrixOperator _matrixOperator;

		public MatrixController(IMatrixOperator matrixOperator)
        {
            _matrixOperator = matrixOperator;
        }

		///<remarks>
		///Sample request:
		///
		///		Post
		///		{
		///			"matrixA": {
		///			"data": [
		///				[0,1,2],
		///				[3,4,5]
		///				]
		///			},
		///			"matrixB": {
		///			"data": [
		///				[0,1,2],
		///				[3,4,5],
		///				[6,7,8]
		///				]
		///			}
		///		}
		/// </remarks>
		/// <summary>
		/// Multiplies two matrices
		/// </summary>
		[HttpPost("multiply")]
		public IActionResult Multiply([FromBody]MultiplyRequest request)
		{
			var multiplyResponse = new MultiplyResponse(request.MatrixA, request.MatrixB, _matrixOperator.Multiply(request.MatrixA, request.MatrixB));
			return Ok(multiplyResponse);
		}
	}
}
