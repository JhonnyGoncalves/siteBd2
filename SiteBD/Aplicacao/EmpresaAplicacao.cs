using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteBD.Repositorio;
using SiteBD.Areas.Painel.Models;
using System.Data.SqlClient;
namespace SiteBD.Aplicacao
{
    public class EmpresaAplicacao
    {
        private readonly Contexto contextoEmpresa;
        public EmpresaAplicacao()
        {
            contextoEmpresa =new Contexto();
        }
        private List<Empresa> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var listaDeEmpresa = new List<Empresa>();


            while (reader.Read())
            {
                var tempEmpresa = new Empresa();
                tempEmpresa.idEmpresa = int.Parse(reader["idEmpresa"].ToString());
                tempEmpresa.Descricao = reader["Descricao"].ToString();
                tempEmpresa.Telefone = reader["Telefone"].ToString();
                tempEmpresa.Endereco = reader["Endereco"].ToString();
                tempEmpresa.idArea = int.Parse(reader["idArea"].ToString());

                listaDeEmpresa.Add(tempEmpresa);
            }
            reader.Close();
            return listaDeEmpresa;


        }
        private List<Empresa> TransformaReaderEmListaDeObjetoDaindex(SqlDataReader reader)
        {
            var listaDeEmpresa = new List<Empresa>();


            while (reader.Read())
            {
                var tempEmpresa = new Empresa();
                tempEmpresa.idEmpresa = int.Parse(reader["idEmpresa"].ToString());
                tempEmpresa.Descricao = reader["Descricao"].ToString();
                tempEmpresa.Telefone = reader["Telefone"].ToString();
                tempEmpresa.Endereco = reader["Endereco"].ToString();
                tempEmpresa.idArea = int.Parse(reader["idArea"].ToString());
                tempEmpresa.Area = reader["Area"].ToString();

                listaDeEmpresa.Add(tempEmpresa);
            }
            reader.Close();
            return listaDeEmpresa;


        }
        public List<Empresa> Listar()
        {
            var strQuery = "select e.idEmpresa, e.descricao , e.telefone ,e.endereco ,e.idarea,a.Area from Empresa e ,Area a where e.idArea = a.idArea";
            var retorno = contextoEmpresa.Executacomandocomretorno(strQuery);

            var ListaDeEmpresas = TransformaReaderEmListaDeObjetoDaindex(retorno);
            return ListaDeEmpresas;
        }
        public Empresa ListarporId(int id)
        {
            var strQuery = string.Format("SELECT * FROM empresa WHERE idEmpresa = {0}", id);
            var retorno = contextoEmpresa.Executacomandocomretorno(strQuery);

            var listaDeEmpresas = TransformaReaderEmListaDeObjeto(retorno);

            return listaDeEmpresas.FirstOrDefault();
        }
        public void Excluir(int id)
        {
            var strQuery = string.Format("DELETE FROM empresa WHERE idEmpresa = {0}", id);
            contextoEmpresa.ExecutaComando(strQuery);
        }
        public void Inserir(Empresa empresa)
        {
            var strQuery = string.Format("INSERT INTO EMPRESA (Descricao,Telefone,Endereco,idArea) VALUES('{0}','{1}','{2}','{3}')", empresa.Descricao, empresa.Telefone, empresa.Endereco, empresa.idArea);
            contextoEmpresa.ExecutaComando(strQuery);
        }
        public void Alterar(Empresa empresa)
        {
            var strQuery = string.Format("UPDATE EMPRESA SET Descricao = '{0}',Telefone = '{1}', Endereco = '{2}',idArea ='{3}'  WHERE IDEMPRESA ='{4}'", empresa.Descricao, empresa.Telefone, empresa.Endereco, empresa.idArea, empresa.idEmpresa);
            contextoEmpresa.ExecutaComando(strQuery);
        }
        public void Salvar(Empresa empresa)
        {
            if (empresa.idEmpresa>0)
            {
                Alterar(empresa);
            }
            Inserir(empresa);

        }



       
    }
}