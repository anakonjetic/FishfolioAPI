using FishfolioAPI.DAL;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FishfolioDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FishfolioAPIDbContext"),
            opt => opt.MigrationsAssembly("FishfolioAPI.DAL")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseHttpsRedirection();

app.UseAuthorization();*/

app.MapControllers();

//Setup local IP\
string localIP = LocalIPAddress();

app.Urls.Add("http://" + localIP + ":5072");
app.Urls.Add("https://" + localIP + ":7072");

app.Run();


static string LocalIPAddress()
{
    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
    {
        socket.Connect("8.8.8.8", 65530);
        IPEndPoint? endPoint = socket.LocalEndPoint as IPEndPoint;
        if (endPoint != null)
        {
            return endPoint.Address.ToString();
        }
        else
        {
            return "127.0.0.1";
        }
    }
}
