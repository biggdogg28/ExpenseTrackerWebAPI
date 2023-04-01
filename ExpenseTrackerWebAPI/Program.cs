using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.Repositories;
using ExpenseTrackerWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExpenseTrackerDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddTransient<ILocationsRepository, LocationsRepository>();
builder.Services.AddTransient<ILocationsService, LocationsService>();
builder.Services.AddTransient<IExpenseCategoriesRepository, ExpenseCategoriesRepository>();
builder.Services.AddTransient<IExpenseCategoriesService, ExpenseCategoriesService>();
builder.Services.AddTransient<IExpensesRepository, ExpensesRepository>();
builder.Services.AddTransient<IExpensesService, ExpensesService>();
builder.Services.AddTransient<IIncomesRepository, IncomesRepository>();
builder.Services.AddTransient<IIncomesService, IncomesService>();
builder.Services.AddTransient<IIncomeTypesRepository, IncomeTypesRepository>();
builder.Services.AddTransient<IIncomeTypesService, IncomeTypesService>();
//builder.Services.AddTransient<ITotalsRepository, TotalsRepository>();
//builder.Services.AddTransient<ITotalsSerivce, TotalsSerivce>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
