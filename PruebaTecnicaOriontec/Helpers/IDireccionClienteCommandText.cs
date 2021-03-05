using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaOriontec.Helpers
{
    public interface IDireccionClienteCommandText
    {
        string GetDireccionClientes { get; }
        string GetDireccionClienteById { get; }
        string AddDireccionCliente { get; }
        string UpdateDireccionCliente { get; }
        string RemoveDireccionCliente { get; }
    }
    public class DireccionClienteCommandText : IDireccionClienteCommandText
    {
        public string GetDireccionClientes => "Select * From direcciones";
        public string GetDireccionClienteById => "Select * From direcciones Where IdCliente= @Id";
        public string AddDireccionCliente => "Insert Into  direcciones Values (@IdCliente,@Direccion)";
        public string UpdateDireccionCliente => "Update direcciones set Direccion = @Direccion Where Id =@Id";
        public string RemoveDireccionCliente => "Delete From direcciones Where Id= @Id";
    }
}
