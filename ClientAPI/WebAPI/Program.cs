using Application.UseCases;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("client_api"));

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
