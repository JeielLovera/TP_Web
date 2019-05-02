﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementation;

namespace Business.Implementation
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository clienteRepository = new ClienteRepository();
        private IDireccionRepository direccionRepository = new DireccionRepository();
        public bool Delete(int id)
        {
            return clienteRepository.Delete(id);
        }

        public List<Cliente> FindAll()
        {
            return clienteRepository.FindAll();
        }

        public Cliente FindById(int? id)
        {
            return clienteRepository.FindById(id);
        }

        public bool Insert(Cliente t)
        {
            Direccion direccion = direccionRepository.FindById(t.CDireccion.CDireccion);
            t.CDireccion = direccion;
            return clienteRepository.Insert(t);
        }

        public bool Update(Cliente t)
        {
            Direccion direccion = direccionRepository.FindById(t.CDireccion.CDireccion);
            t.CDireccion = direccion;
            return clienteRepository.Update(t);
        }
    }
}
