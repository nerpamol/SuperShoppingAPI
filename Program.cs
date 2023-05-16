var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(WebApiApplication.Models.EF.BankingContext));

builder.Services.AddCors(cors =>
{
    cors.AddDefaultPolicy(defaultPolicy =>
    {
        defaultPolicy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
    //cors.AddPolicy("vendorA", vendorAPolicy =>
    //{
    //    vendorAPolicy.WithOrigins(new string[] { "https://www.transportmanagement.com", "https://www.cognizantHRManagement.com" }).WithMethods(new string[] { "GET" });
    //});
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
