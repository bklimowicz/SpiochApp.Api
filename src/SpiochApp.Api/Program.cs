using Microsoft.AspNetCore.Mvc;
using SpiochApp.Api.model.commands;
using SpiochApp.Api.model.responses;
using SpiochApp.Api.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<ISleepScheduleCalculator, SleepScheduleCalculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "SpiochApp.Api v1");
    });
}

app.UseHttpsRedirection();

app.MapPost("/calculate", (GetSleepSchedule request, [FromServices] ISleepScheduleCalculator sleepScheduleCalculator) =>
{
    
    List<SleepSpanDto> sleepScheduleResult;
    try
    {
        sleepScheduleResult = sleepScheduleCalculator.Calculate(request);
    } catch (Exception e)
    {
        return Results.BadRequest("Sprawdź poprawność danych i spróbuj jeszcze raz");
    }

    return Results.Ok(sleepScheduleResult);
});


app.Run();
