using CursoDeIngles.Infra.Context;
using CursoDeIngles.Infra.Repository;
using CursoDeIngles.Infra.Repository.Interfaces;
using CursoDeIngles.Services.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x => x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
app.MapControllers();

app.Run();
