using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class CustomerService
    {
        //inyeccion de dependencia que nos va a ser util despues de crear la base de datos
        //private readonly OrganizacionContext _context;
        //public OrganizacionService(OrganizacionContext _context)
        //{
        //    this._context = _context;
        //}

        //public List<EmpleadoDTO> GetListadoEmpleados()
        //{
        //    var usuario = _context.Empleado.ToList();
        //    var usuarioResponse = new List<EmpleadoDTO>();

        //    foreach (var usu in usuario)
        //    {
        //        usuarioResponse.Add(new EmpleadoDTO()
        //        {
        //            Id = usu.Id,
        //            Nombre = usu.Nombre
        //        });
        //    }

        //    return usuarioResponse;
        //}
    }
}
