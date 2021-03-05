using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaOriontec.Helpers
{
    public interface IEmpresaCommandText
    {
        string GetEmpresas { get; }
        string GetEmpresaById { get; }
        string AddEmpresa { get; }
        string UpdateEmpresa { get; }
        string RemoveEmpresa { get; }
    }
    public class EmpresaCommandText : IEmpresaCommandText
    {
        public string GetEmpresas => "Select * From Empresas";
        public string GetEmpresaById => "Select * From Empresas Where Id= @Id";
        public string AddEmpresa => "Insert Into  Empresas Values (@RazonSocial)";
        public string UpdateEmpresa => "Update Empresas set RazonSocial = @RazonSocial Where Id =@Id";
        public string RemoveEmpresa => "Delete From Empresas Where Id= @Id";
    }
}

