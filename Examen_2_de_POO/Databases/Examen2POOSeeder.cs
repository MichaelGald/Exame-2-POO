using Examen_2_de_POO.Databases.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Examen_2_de_POO.Databases
{
    public class Examen2POOSeeder
    {
        public static async Task LoadDataAsync(
           ContextClientes context,
           ILoggerFactory loggerFactory
           )
        {
            try
            {
                await LoadClienteAsync(loggerFactory, context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Examen2POOSeeder>();
                logger.LogError(e, "Error inicializando la data del API");
            }
        }
        // Todo: seed de usuraios
        public static async Task LoadClienteAsync(ILoggerFactory loggerFactory, ContextClientes _context)
        {
            try
            {
                var jsonfilePath = "SeedData/libros.json";
                var jsonnContent = await File.ReadAllTextAsync(jsonfilePath);
                var libros = JsonConvert.DeserializeObject<List<ClienteEntity>>(jsonnContent);
                if (!await _context.Clientes.AnyAsync())
                {
                    _context.Clientes.AddRange(libros);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ContextClientes>();
                logger.LogError(e, "Error al ejecutar el Seed de libros.");
            }
        }
       
    }
}
