using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiMedicines.Models;

namespace Services.Implementations
{
    public class CustomerService: ICustomerService
    {
        //inyeccion de dependencia que nos va a ser util despues de crear la base de datos
        private readonly MedicinesAPIContext _context;
        public CustomerService(MedicinesAPIContext _context)
        {
            this._context = _context;
        }

        public List<CustomerDTO> GetCustomerList()
        {
            var usuario = _context.Empleado.ToList();
            var usuarioResponse = new List<CustomerDTO>();

            foreach (var usu in usuario)
            {
                usuarioResponse.Add(new CustomerDTO()
                {
                    Id = usu.Id,
                    Name = usu.Nombre
                });
            }

            return usuarioResponse;
        }


    }
}
