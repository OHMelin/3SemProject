using FlyBooking.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Olivers Database p� hildur
builder.Services.AddScoped<IFlightDataAccess>(f => new FlightDataAccess(@"CONNECTIONSTRING"));
builder.Services.AddScoped<IDestinationDataAccess>(d => new DestinationDataAccess(@"CONNECTIONSTRING"));
builder.Services.AddScoped<ISeatDataAccess>(s => new SeatDataAccess(@"CONNECTIONSTRING"));
builder.Services.AddScoped<IPlaneDataAccess>(p => new PlaneDataAccess(@"CONNECTIONSTRING"));
builder.Services.AddScoped<IPlaneModelDataAccess>(pm => new PlaneModelDataAccess(@"CONNECTIONSTRING"));
builder.Services.AddScoped<IAccountDataAccess>(a => new AccountDataAccess(@"CONNECTIONSTRING"));
builder.Services.AddScoped<IBookingDataAccess>(b => new BookingDataAccess(@"CONNECTIONSTRING"));
builder.Services.AddScoped<ITicketDataAccess>(t => new TicketDataAccess(@"CONNECTIONSTRING"));

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
