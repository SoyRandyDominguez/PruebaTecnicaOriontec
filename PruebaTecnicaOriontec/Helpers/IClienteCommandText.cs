using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaOriontec.Helpers
{
    public interface IClienteCommandText
    {
        string GetClientes { get; }
        string GetClienteById { get; }
        string AddCliente { get; }
        string UpdateCliente { get; }
        string RemoveCliente { get; }
    }
    public class ClienteCommandText : IClienteCommandText
    {
        public string GetClientes => "Select c.*, e.razonsocial Empresa From Clientes c join empresas e on e.id = c.EmpresaId";
        public string GetClienteById => "Select * From Clientes Where Id= @Id";
        public string AddCliente => "Insert Into  Clientes Values (@Nombre,@EmpresaId)";
        public string UpdateCliente => "Update Clientes set Nombre = @Nombre, EmpresaId = @EmpresaId Where Id =@Id";
        public string RemoveCliente => "Delete From Clientes Where Id= @Id";
    }
}

