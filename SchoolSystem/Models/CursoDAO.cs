using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Database;
using SchoolSystem.Helpers;
using MySql.Data.MySqlClient;

namespace SchoolSystem.Models;

class CursoDAO
{
    private Conexao conn = new Conexao();

    public void Insert(Curso curso)
    {
        try
        {
            var comando = conn.Query();
            comando.CommandText = "Insert into curso values (null, @nome, @cargaHor, @turno, @descricao, @escolaFk)";

            comando.Parameters.AddWithValue("@nome", curso.Nome);
            comando.Parameters.AddWithValue("@cargaHor", curso.CargaHoraria);
            comando.Parameters.AddWithValue("@turno", curso.Turno);
            comando.Parameters.AddWithValue("@descricao", curso.Descricao);
            comando.Parameters.AddWithValue("@escolaFk", curso.Escola.Id);

            var resultado = comando.ExecuteNonQuery();
            conn.Close();   
                
        } catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Update(Curso curso)
    {
        try
        {
            var comando = conn.Query();
            comando.CommandText = "Update curso set nome_cur = @nome, carga_horaria_cur = @cargaHor, turno_cur = @turno, descricao_cur = @descricao where id_cur = @id";

            comando.Parameters.AddWithValue("@nome", curso.Nome);
            comando.Parameters.AddWithValue("@cargaHor", curso.CargaHoraria);
            comando.Parameters.AddWithValue("@turno", curso.Turno);
            comando.Parameters.AddWithValue("@descricao", curso.Descricao);
            comando.Parameters.AddWithValue("@id", curso.Id);
            var resultado = comando.ExecuteNonQuery();
            conn.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public List<Curso> List()
    {
        try
        {


            var lista = new List<Curso>();
            var command = conn.Query();
            command.CommandText = "select curso.*,  escola.nome_fantasia_esc  FROM CURSO , ESCOLA  WHERE(id_esc_fk = id_esc);";

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var curso = new Curso();

                curso.Id = reader.GetInt32("id_cur");
                curso.Nome = DaoHelper.GetString(reader, "nome_cur");
                curso.Turno = DaoHelper.GetString(reader, "turno_cur");
                curso.CargaHoraria = DaoHelper.GetString(reader, "carga_horaria_cur");
                curso.Descricao = DaoHelper.GetString(reader, "descricao_cur");
                curso.Escola = new Escola();
                curso.Escola.Id = DaoHelper.GetId(reader, "id_esc_fk");
                curso.Escola.NomeFantasia = DaoHelper.GetString(reader, "nome_fantasia_esc");
                lista.Add(curso);
            }
            conn.Close();
            return lista;
        } catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Delete(Curso curso)
    {
        try
        {

            var comando = conn.Query();

            comando.CommandText = "delete from curso where id_cur = @id";

            comando.Parameters.AddWithValue("@id", curso.Id);
            var resultado = comando.ExecuteNonQuery();

            if (resultado == 0)
            {
                throw new Exception("Erro ao Apagar os dados do Banco de dados");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

    

