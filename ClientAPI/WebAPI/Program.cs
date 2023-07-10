using Application.UseCases;
using Domain.Interfaces.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGetAllClientsUseCase, GetAllClientsUseCase>();
builder.Services.AddScoped<IGetByPhoneNumberUseCase, GetByPhoneNumberUseCase>();
builder.Services.AddScoped<IAddClientUseCase, AddClientUseCase>();
builder.Services.AddScoped<IUpdateClientEmailUseCase, UpdateClientEmailUseCase>();
builder.Services.AddScoped<IUpdateClientPhoneUseCase, UpdateClientPhoneUseCase>();
builder.Services.AddScoped<IDeleteClientUseCase, DeleteClientUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
