using CursoDeIngles.Infra.Context;
using CursoDeIngles.Infra.Repository;
using CursoDeIngles.Infra.Repository.Interfaces;
using CursoDeIngles.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cursos de ingles",
        Version = "v1",
        Description = "API construída baseado no teste da empresa Marlin.",

        Contact = new OpenApiContact
        {
            Name = "Juliano Dibai",
            Email = "dibaijuliano@gmail.com",
            Url = new Uri("https://github.com/julianodibai")
        },

    });
			

});

#region Configuração

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<CursoContext>(
    options => options.UseSqlServer(connectionString, 
                            assembly => assembly.MigrationsAssembly(
                                                    typeof(CursoContext)
                                                            .Assembly
                                                            .FullName
                            )
    )
);

builder.Services.AddControllers()
                .AddNewtonsoftJson(
                    options => {
                        options.SerializerSettings
                                .ReferenceLoopHandling 
                                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();

builder.Services.AddAutoMapper(typeof(CursoProfile));

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x => x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
app.MapControllers();

app.Run();
