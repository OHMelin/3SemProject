using FlyBooking.DAL;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<FlyBooking.APIClient.IFlightAPIClient>(s => new FlyBooking.APIClient.FlightAPIClient("https://localhost:7241/api/Flights"));
builder.Services.AddScoped<FlyBooking.APIClient.IDestinationAPIClient>(s => new FlyBooking.APIClient.DestinationAPIClient("https://localhost:7241/api/Destinations"));
builder.Services.AddScoped<FlyBooking.APIClient.ISeatAPIClient>(s => new FlyBooking.APIClient.SeatAPIClient("https://localhost:7241/api/Seats"));
builder.Services.AddScoped<FlyBooking.APIClient.IPlaneAPIClient>(s => new FlyBooking.APIClient.PlaneAPIClient("https://localhost:7241/api/Planes"));

builder.Services.AddScoped<FlyBooking.APIClient.IAccountAPIClient>(s => new FlyBooking.APIClient.AccountAPIClient("https://localhost:7241/api/Accounts"));
builder.Services.AddScoped<FlyBooking.APIClient.IBookingAPIClient>(s => new FlyBooking.APIClient.BookingAPIClient("https://localhost:7241/api/Bookings"));
builder.Services.AddScoped<FlyBooking.APIClient.ITicketAPIClient>(t => new FlyBooking.APIClient.TicketAPIClient("https://localhost:7241/api/Tickets"));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
	options => { options.LoginPath = "/Account/Login"; options.LogoutPath = "/Account/Logout"; options.AccessDeniedPath = "/Account/AccessDenied";});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
