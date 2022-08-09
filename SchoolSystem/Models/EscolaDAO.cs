using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Database;
using MySql.Data.MySqlClient;
using SchoolSystem.Helpers;



namespace SchoolSystem.Models;
class EscolaDAO
{
    private Conexao conn = new Conexao();


    public void Insert(Escola escola)
    {
        try
        {


            var comando = conn.Query();
            //conexao.Open();
            //var comando = conexao.CreateCommand();

            comando.CommandText = "Insert into escola values (null, @nomeFant, @razSocial, @cnpj, @inscEst, @tipo, @data, @responsavel, @telResp, @telEsc, " +
                "@emailEsc, @rua, @bairro, @numRua, @cep, @complemento, @cidade, @estado);";

            comando.Parameters.AddWithValue("@nomeFant", escola.NomeFantasia);
            comando.Parameters.AddWithValue("@razSocial", escola.RazaoSocial);
            comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
            comando.Parameters.AddWithValue("@inscEst", escola.InscricaoEstadual);
            comando.Parameters.AddWithValue("@tipo", escola.Tipo);
            comando.Parameters.AddWithValue("@data", escola.Data);
            comando.Parameters.AddWithValue("@responsavel", escola.NomeResp);
            comando.Parameters.AddWithValue("@telResp", escola.TelResp);
            comando.Parameters.AddWithValue("@telEsc", escola.TelefoneEsc);
            comando.Parameters.AddWithValue("@emailEsc", escola.EmailEsc);
            comando.Parameters.AddWithValue("@rua", escola.Rua);
            comando.Parameters.AddWithValue("@bairro", escola.Bairro);
            comando.Parameters.AddWithValue("@numRua", escola.NumeroRua);
            comando.Parameters.AddWithValue("@cep", escola.Cep);
            comando.Parameters.AddWithValue("@complemento", escola.Complemento);
            comando.Parameters.AddWithValue("@cidade", escola.CidadeEsc);
            comando.Parameters.AddWithValue("@estado", escola.Estado);
            var resultado = comando.ExecuteNonQuery();

            Console.WriteLine(resultado);

            //if (resultado > 0)
            //MessageBox.Show("Registro feito com Sucesso", "Conexão com Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void Update(Escola escola)
    {
        try
        {



            var comando = conn.Query();
            //conexao.Open();
            //var comando = conexao.CreateCommand();

            comando.CommandText = "Update escola set nome_fantasia_esc = @nomeFant, razao_social_esc = @razSocial, cnpj_esc = @cnpj, insc_estadual_esc = @inscEst, tipo_esc = @tipo, data_criacao_esc = @data, responsavel_esc =@responsavel, responsavel_telefone_esc = @telResp, telefone_esc = @telEsc, " +
                "email_esc = @emailEsc, rua_esc = @rua, bairro_esc = @bairro, numero_esc = @numRua, cep_esc = @cep, compemento_esc = @complemento, cidade_esc = @cidade, estado_esc = @estado where id_esc = @id;";

            comando.Parameters.AddWithValue("@nomeFant", escola.NomeFantasia);
            comando.Parameters.AddWithValue("@razSocial", escola.RazaoSocial);
            comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
            comando.Parameters.AddWithValue("@inscEst", escola.InscricaoEstadual);
            comando.Parameters.AddWithValue("@tipo", escola.Tipo);
            comando.Parameters.AddWithValue("@data", escola.Data);
            comando.Parameters.AddWithValue("@responsavel", escola.NomeResp);
            comando.Parameters.AddWithValue("@telResp", escola.TelResp);
            comando.Parameters.AddWithValue("@telEsc", escola.TelefoneEsc);
            comando.Parameters.AddWithValue("@emailEsc", escola.EmailEsc);
            comando.Parameters.AddWithValue("@rua", escola.Rua);
            comando.Parameters.AddWithValue("@bairro", escola.Bairro);
            comando.Parameters.AddWithValue("@numRua", escola.NumeroRua);
            comando.Parameters.AddWithValue("@cep", escola.Cep);
            comando.Parameters.AddWithValue("@complemento", escola.Complemento);
            comando.Parameters.AddWithValue("@cidade", escola.CidadeEsc);
            comando.Parameters.AddWithValue("@estado", escola.Estado);
            comando.Parameters.AddWithValue("@id", escola.Id);
            var resultado = comando.ExecuteNonQuery();


            //if (resultado > 0)
            //MessageBox.Show("Registro feito com Sucesso", "Conexão com Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);


        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);

        }
    }

    public void Delete(Escola escola)
    {
        try
        {

            var comando = conn.Query();

            comando.CommandText = "delete from escola where id_esc = @id";

            comando.Parameters.AddWithValue("@id", escola.Id);
            var resultado = comando.ExecuteNonQuery();

            if(resultado == 0)
            {
                throw new Exception("Erro ao Apagar os dados do Banco de dados");
            }
        } catch (Exception ex)
        {
            throw ex;
        }
    }



    public List<Escola> List()
    {
        try
        {

            var lista = new List<Escola>();
            var comando = conn.Query();
            comando.CommandText = "select * from escola";
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                var escola = new Escola();
                escola.Id = reader.GetInt32("id_esc");

                escola.NomeFantasia = DaoHelper.GetString(reader, "nome_fantasia_esc");
                escola.RazaoSocial = DaoHelper.GetString(reader, "razao_social_esc");
                escola.Cnpj = DaoHelper.GetString(reader, "cnpj_esc");
                escola.InscricaoEstadual = DaoHelper.GetString(reader, "insc_estadual_esc");
                escola.SetTipo(DaoHelper.GetString(reader, "tipo_esc"));
                escola.Data = DaoHelper.GetDateTime(reader, "data_criacao_esc");
                escola.NomeResp = DaoHelper.GetString(reader, "responsavel_esc");
                escola.TelResp = DaoHelper.GetString(reader, "responsavel_telefone_esc");
                escola.TelefoneEsc = DaoHelper.GetString(reader, "telefone_esc");
                escola.EmailEsc = DaoHelper.GetString(reader, "email_esc");
                escola.Rua = DaoHelper.GetString(reader, "rua_esc");
                escola.Bairro = DaoHelper.GetString(reader, "bairro_esc");
                escola.NumeroRua = reader.GetInt32("numero_esc");
                escola.Cep = DaoHelper.GetString(reader, "cep_esc");
                escola.Complemento = DaoHelper.GetString(reader, "compemento_esc");
                escola.CidadeEsc = DaoHelper.GetString(reader, "cidade_esc");
                escola.Estado = DaoHelper.GetString(reader, "estado_esc");


                lista.Add(escola);
                    

                    
            }
            reader.Close();

            return lista;

        } catch (Exception ex)
        {
            throw ex;
        }
            
    }

        
        
    
}
