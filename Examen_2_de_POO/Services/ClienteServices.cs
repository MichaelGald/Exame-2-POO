using AutoMapper;
using Examen_2_de_POO.API.Helpers;
using Examen_2_de_POO.Databases;
using Examen_2_de_POO.Databases.Entities;
using Examen_2_de_POO.Dtos.Clientes;
using Examen_2_de_POO.Dtos.common;
using Examen_2_de_POO.Dtos.Planamortiguacion;
using Examen_2_de_POO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_2_de_POO.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly ContextClientes _context;
        private readonly IMapper _autoMapper;

        public ClienteServices(ContextClientes context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public async Task<ResponseDto<List<ClienteDto>>> GetClienteListAsync()
        {
            var clientes = await _context.Clientes.Include(c => c.PlanamortizacionEntity).ToListAsync();
            var clientesDto = _autoMapper.Map<List<ClienteDto>>(clientes);

            return new ResponseDto<List<ClienteDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de clientes obtenida correctamente",
                Data = clientesDto
            };
        }

        public async Task<ResponseDto<ClienteDto>> GetClienteByIdAsync(Guid Id)
        {
            var clienteEntity = await _context.Clientes.Include(c => c.PlanamortizacionEntity).FirstOrDefaultAsync(j => j.IdCliente == Id);
            if (clienteEntity == null)
            {
                return new ResponseDto<ClienteDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
                };
            }
            var clienteDto = _autoMapper.Map<ClienteDto>(clienteEntity);

            return new ResponseDto<ClienteDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado",
                Data = clienteDto
            };
        }

        public async Task<ResponseDto<ClienteDto>> CreateClienteAsync(CreateClienteDto dto)
        {
            var clienteEntity = _autoMapper.Map<ClienteEntity>(dto);

            _context.Clientes.Add(clienteEntity);
            await _context.SaveChangesAsync();

            //Agregar planes de amortizacion al contexto inserta cada plan de amortizacion en la base de datos
            var planesAmortiguacion = Generarcuadroamortizacion(clienteEntity);
            foreach (var plan in planesAmortiguacion)
            {
                _context.PlanamortizacionEntities.Add(new PlanamortizacionEntity
                {
                    Numeroinstalacion = plan.Numeroinstalacion,
                    Fechapago = plan.Fechapago,
                    Days = plan.Days,
                    Interes = plan.Interes,
                    Principal = plan.Principal,
                    PagoNivelSinSVSD = plan.PagoNivelSinSVSD,
                    PagoNivelSconSVSD = plan.PagoNivelSconSVSD,
                    Balanceprincipal = plan.Balanceprincipal,
                    Cliente = clienteEntity
                });
            }
            await _context.SaveChangesAsync();

            var clienteDto = _autoMapper.Map<ClienteDto>(clienteEntity);
            return new ResponseDto<ClienteDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro creado",
                Data = clienteDto
            };
        }

        // Metodo para calcular el pago mensual
        private decimal CalcularPagomensual(decimal principal, decimal tasaDeInteresAnual, int meses)
        {
            var tasaDeInteresMensual = tasaDeInteresAnual / 12 / 100;
            var potencia = (decimal)Math.Pow((double)(1 + tasaDeInteresMensual), meses);
            return principal * (tasaDeInteresMensual * potencia) / (potencia - 1);
        }
        // Metodo para generar el cuadro de amortizacion
        private List<PlanAmortiguacionDto> Generarcuadroamortizacion(ClienteEntity cliente)
        {
            var plan = new List<PlanAmortiguacionDto>();
            decimal principalRestante = cliente.Montoprestamo;
            decimal mensualidad = CalcularPagomensual(cliente.Montoprestamo, cliente.Tasainteres, cliente.Termino);
            decimal tasaDeInteresMensual = cliente.Tasainteres / 12 / 100;

            for (int i = 1; i <= cliente.Termino; i++)
            {
                var interes = Math.Round(principalRestante * tasaDeInteresMensual, 2);
                var amortizacion = Math.Round(mensualidad - interes, 2);
                var saldoPrincipal = Math.Round(principalRestante - amortizacion, 2);

                plan.Add(new PlanAmortiguacionDto
                {
                    Numeroinstalacion = i,
                    Fechapago = cliente.Fechaprimerpago.AddMonths(i - 1),
                    Days = (i == cliente.Termino) ? (DateTime.Now - cliente.Fechaprimerpago).Days : 30,
                    Interes = interes,
                    Principal = amortizacion,
                    PagoNivelSinSVSD = mensualidad,
                    PagoNivelSconSVSD = mensualidad + 2,
                    Balanceprincipal = saldoPrincipal
                });

                principalRestante = saldoPrincipal;
            }

            return plan;
        }
    }
}
