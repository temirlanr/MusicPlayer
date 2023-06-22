using Microsoft.EntityFrameworkCore;
using MusicPlayer.DataLayer.Data;
using MusicPlayer.ServiceLayer.Services.Interfaces;
using MusicPlayer.ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MusicPlayerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAlbumsService, AlbumsService>();
builder.Services.AddScoped<IArtistsService, ArtistsService>();
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IPlaylistsService, PlaylistsService>();
builder.Services.AddScoped<ISongsService, SongsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
