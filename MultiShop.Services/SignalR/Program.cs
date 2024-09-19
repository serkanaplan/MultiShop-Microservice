using SignalR.Hubs;
using SignalR.Services.SignalRCommentServices;
using SignalR.Services.SignalRMessageServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", builder => builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials()));

builder.Services.AddSignalR();
builder.Services.AddScoped<ISignalRMessageService, SignalRMessageService>();
builder.Services.AddScoped<ISignalRCommentService, SignalRCommentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
app.Run();

//localhost://1234/category/index