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
                await LoadPlanAmortizacionAsync(loggerFactory, context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Examen2POOSeeder>();
                logger.LogError(e, "Error inicializando la data del API");
            }
        }
        public static async Task LoadClienteAsync(ILoggerFactory loggerFactory, ContextClientes _context)
        {
            try
            {
                var jsonfilePath = "SeedData/cliente.json";
                var jsonContent = await File.ReadAllTextAsync(jsonfilePath);
                var clientes = JsonConvert.DeserializeObject<List<ClienteEntity>>(jsonContent);

                if (!await _context.Clientes.AnyAsync())
                {
                    _context.Clientes.AddRange(clientes);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Examen2POOSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed de clientes.");
            }
        }

        public static async Task LoadPlanAmortizacionAsync(ILoggerFactory loggerFactory, ContextClientes _context)
        {
            try
            {
                var jsonfilePath = "SeedData/respuesta.json";
                var jsonContent = await File.ReadAllTextAsync(jsonfilePath);
                var amortizacionData = JsonConvert.DeserializeObject<List<PlanamortizacionEntity>>(jsonContent);

                //Este codigo se encarga de actualizar la informacion de los clientes en la base de datos con los datos de amortizacion proporcionados
                if (amortizacionData != null && amortizacionData.Any())
                {
                    var clienteIds = amortizacionData.Select(a => a.ClienteId).Distinct().ToList();
                    var clientes = await _context.Clientes
                        .Where(c => clienteIds.Contains(c.IdCliente))
                        .Include(c => c.PlanamortizacionEntity)
                        .ToListAsync();

                    foreach (var cliente in clientes)
                    {
                        var planAmortizacion = amortizacionData
                            .Where(a => a.ClienteId == cliente.IdCliente)
                            .ToList();

                        if (planAmortizacion.Any())
                        {
                            cliente.PlanamortizacionEntity = planAmortizacion;
                        }
                    }

                    _context.Clientes.UpdateRange(clientes);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Examen2POOSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed del plan de amortización.");
            }
        }
    }
}