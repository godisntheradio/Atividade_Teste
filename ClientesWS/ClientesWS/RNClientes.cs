using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientesWS
{
    public class RNClientes
    {
        public string NomeCliente(int idCliente)
        {
            Models.DBOCliente o = new Models.DBOCliente();
            return o.Clientes.ToList().Where(x => x.Id == idCliente).FirstOrDefault().Name;
        }
        public List<Models.Clientes> ListaDeClientes()
        {
            Models.DBOCliente o = new Models.DBOCliente();
            return o.Clientes.ToList();
        }
        public bool SalvarCliente(Models.Clientes ocliente)
        {
            Models.DBOCliente o = new Models.DBOCliente();

            try
            {
                if(ocliente.Id == 0)
                {
                    o.Clientes.Add(ocliente);
                }
                else
                {
                    o.Entry(ocliente).State = System.Data.Entity.EntityState.Modified;
                }
            }
            catch (Exception)
            {
                return false;
            }
            o.SaveChanges();
            return true;

        }
    }
}