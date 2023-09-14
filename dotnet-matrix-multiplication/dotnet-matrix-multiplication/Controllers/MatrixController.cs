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

        [HttpPost("multiply")]
		public IActionResult Multiply([FromBody]MultiplyRequest request)
		{
			var multiplyResponse = new MultiplyResponse(request.MatrixA, request.MatrixB, _matrixOperator.Multiply(request.MatrixA, request.MatrixB));
			return Ok(multiplyResponse);
		}
	}
}
