using dotnet_matrix_multiplication.Middleware;
using dotnet_matrix_multiplication.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var policy = "AllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: policy,
					  policy =>
					  {
						  policy.WithOrigins("http://localhost:4200");
						  policy.AllowAnyHeader();
						  policy.AllowAnyMethod();
					  });

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	options.IncludeXmlComments(xmlPath);
	});
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddSingleton<IMatrixOperator, MatrixOperator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(policy);

app.UseAuthorization();

app.MapControllers();

app.Run();
