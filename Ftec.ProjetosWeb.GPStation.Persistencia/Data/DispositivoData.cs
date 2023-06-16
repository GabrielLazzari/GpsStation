using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
    public class DispositivoData
    {
        public DispositivoData() { }

        List<Dispositivo> dispositivos = null;
        Dispositivo dispositivo = null;
        DataSet dataSet = new DataSet();
        string comando = "";


        //******* LEMBRAR DE SUBSTITUIR PELA STRING QUE JÁ ESTÁ SALVA NO appsettings.json ********

        string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
        //"Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";


        public List<Dispositivo> Listar()
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = null; 
            comando = "SELECT[Id],[Nome],[Latitude],[Longitude]FROM[dbo].[dispositivo]ORDER BY [Nome]";
            try
            {
                using (con)
                {

                    con.Open();
                 //   sqlTransaction = con.BeginTransaction();


                    //dataadapter executa comando SQL e armazena o resultado
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, con);


                    //dataadapter cria a tabela dispositivo no dataset e transfere as informações que coletou no comando anterior
                    dataAdapter.Fill(dataSet, "dispositivo");


                }


               // sqlTransaction.Commit();
                return dispositivos;
            }


            catch (Exception ex)
            {
               // sqlTransaction.Rollback();
                string Mensagem = ex.Message;
                string Metodo = MethodBase.GetCurrentMethod().Name;
                string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
                DateTime dateTime = DateTime.Now;
                ErroPersistencia erro = new ErroPersistencia();
                erro.Inserir(Mensagem, Metodo, Classe, dateTime);
                return null;
            }

        }

    }
}


