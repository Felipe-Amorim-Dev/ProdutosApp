var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Criando a política de CORS doe projeto
builder.Services.AddCors(
    config => config.AddPolicy("DefaultPolicy", builder =>
    {
        builder.AllowAnyOrigin() //Qualquer dominio poderá acessar a API.
               .AllowAnyMethod() //Permitir POST, PUT, DELETE, GET.
               .AllowAnyHeader();//Aceitar parametros de cabeçalho.
    })
    );

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

//Utilizando a política de CORS
app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
