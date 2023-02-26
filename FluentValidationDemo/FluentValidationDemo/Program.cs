using FluentValidation.AspNetCore;
using FluentValidationDemo.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers().AddFluentValidation(fv =>
//{
//    fv.AutomaticValidationEnabled = false;
//    fv.RegisterValidatorsFromAssemblyContaining<TaskItemValidator>();
//});

//builder.Services.AddFluentValidation(conf =>
//{
//    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
//    conf.AutomaticValidationEnabled = false;
//});

builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<TaskItemValidator>();

    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

    // Automatic registration of validators in assembly
    //options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
