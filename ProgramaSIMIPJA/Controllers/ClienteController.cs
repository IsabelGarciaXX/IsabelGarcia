using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgramaSIMIPJA.Models;


namespace ProgramaSIMIPJA.Controllers
{
    [ApiController]
    [Route("cliente")]

    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("Listar")]

        public dynamic ListarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
           {
               new Cliente
               {
                   ID="1",
                   correo="mariaespo@gmail.com",
                   edad="19",
                   nombre="Maria Morales",
               },

               new Cliente
               {
                   ID="2",
                    correo="JuliaMoneda@gmail.com",
                   edad="24",
                   nombre="Julia Espichan",
               }
           };
            return clientes;
        }
        [HttpGet]
        [Route("Listarxid")]

        public dynamic ListarClienteID(string _ID)
        {
            return new Cliente
            {
                ID = "1",
                correo = "mariaespo@gmail.com",
                edad = "19",
                nombre = "Maria Morales"
            };
        }

        [HttpPost]
        [Route("guardar")]

        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.ID = "3";
            return new
            {
                success = true,
                message = "cliente registrado",
                result = cliente,
            };
        }

        [HttpPost]
        [Route("eliminar")]


        public dynamic eliminarCliente(Cliente cliente)
        {

            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            // eliminas en la db

            if (token != "marco123.")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = cliente,
                };
            }
                return new
                {
                    success = true,
                    message = "cliente eliminado",
                    result = cliente,
                };
            }
        }
    }



