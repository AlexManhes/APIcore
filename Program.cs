using APIcore.Contexto;
using APIcore.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Contexto>
    (options => options.UseSqlServer
    (@"Data Source=NOTE-ALEXSANDER;Initial Catalog=FTI;Integrated Security=True"));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("Adicionar", async (sosEditar sos, Contexto Contexto) =>
{
    Contexto.SOS.Add(sos);
    await Contexto.SaveChangesAsync();  
}
); app.MapDelete("Excluir aluno/{matricula}", async (int matricula, Contexto Contexto) =>
{
    var sosExcluir= await Contexto.SOS.FirstOrDefaultAsync(p => p.matricula == matricula);
    if(sosExcluir!=null){
        Contexto.SOS.Remove(sosExcluir);
        await Contexto.SaveChangesAsync();

    }
}
 );

app.MapGet("Alunos", async ( Contexto Contexto) =>
{
  return  await Contexto.SOS.ToListAsync();
}
);
app.MapGet("Mostar aluno/{matricula}", async (int matricula, Contexto Contexto) =>
{
   return await Contexto.SOS.FirstOrDefaultAsync(p => p.matricula == matricula);
    
}
 );
 app.MapPut("Editar/{matricula}", async (int matricula, sosEditar nome, Contexto Contexto) =>
{
    if (matricula == nome.matricula)
    {
        Contexto.Entry<sosEditar>(nome).State = EntityState.Modified;
        await Contexto.SaveChangesAsync();
    }


});


app.UseSwaggerUI();

app.Run();
