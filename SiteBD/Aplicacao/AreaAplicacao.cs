using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteBD.Repositorio;
using SiteBD.Areas.Painel.Models;
using System.Data.SqlClient;

namespace SiteBD.Aplicacao
{
    public class AreaAplicacao
    {
        private readonly Contexto contextoArea;
        public AreaAplicacao()
        {
            contextoArea = new Contexto();
        }
        private List<Area> TransformaReaderEmListaArea(SqlDataReader reader)
        {
            var listaDeArea = new List<Area>();

            while (reader.Read())
            {
                var tempArea = new Area();
                tempArea.Id = int.Parse(reader["idArea"].ToString());
                tempArea.Nome = reader["Area"].ToString();
                listaDeArea.Add(tempArea);
            }
            reader.Close();
            return listaDeArea;


        }
        public List<Area> Listar()
        {
            var strQuery = "select * from Area";
            var retorno = contextoArea.Executacomandocomretorno(strQuery);

            var ListaDeArea = TransformaReaderEmListaArea(retorno);
            return ListaDeArea;
        }
        public Area ListarporId(int id)
        {
            var strQuery = string.Format("SELECT * FROM Area WHERE idArea = {0}", id);
            var retorno = contextoArea.Executacomandocomretorno(strQuery);

            var listaDeAreas = TransformaReaderEmListaArea(retorno);

            return listaDeAreas.FirstOrDefault();
        }
        public void Excluir(int id)
        {
            var strQuery = string.Format("DELETE FROM Area WHERE idArea = {0}", id);
            contextoArea.ExecutaComando(strQuery);
        }
        public void Inserir(Area area)
        {
            var strQuery = string.Format("INSERT INTO AREA (Area) VALUES('{0}')",area.Nome);
            contextoArea.ExecutaComando(strQuery);
        }
        public void Alterar(Area area)
        {
            var strQuery = string.Format("UPDATE Area SET Area = '{0}'  WHERE idArea ='{1}'", area.Nome,area.Id);
            contextoArea.ExecutaComando(strQuery);
        }
        public void Salvar(Area area)
        {
            if (area.Id > 0)
            {
                Alterar(area);
            }
            Inserir(area);

        }
    }
}