using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;


namespace Estacionamento
{

    public class MarcaDAO
    {

        private static String INSERT = "INSERT INTO Marca (descricao) VALUES (@descricao)";
        private static String DELETE = "DELETE FROM Marca WHERE codMarca = @codMarca";
        private static String UPDATE = "UPDATE Marca SET descricao = @descricao WHERE codMarca = @codMarca";
        private static String SELECTALL = "SELECT codMarca, descricao FROM Marca";
        private static String SELECTBYID = "SELECT codMarca, Descricao FROM Marca WHERE codMarca = @codMarca";

        public void insert(Marca marca)
        {
            FbConnection conn = ConnectionFactory.getConnection();
            FbCommand query = new FbCommand(INSERT, conn);
            try
            {
                query.Parameters.AddWithValue("@descricao", marca.getDescricao());
                conn.Open();
                query.ExecuteNonQuery();
            }
            catch (FbException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                ConnectionFactory.closeAll(conn, query);
            }
        }

        public void delete(Marca marca) {
            FbConnection conn = ConnectionFactory.getConnection();
            FbCommand query = new FbCommand(DELETE, conn);
            try
            {
                query.Parameters.AddWithValue("@codMarca", marca.getCodMarca());
                conn.Open();
                query.ExecuteNonQuery();
            }
            catch (FbException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                ConnectionFactory.closeAll(conn, query);
            }
        }

        public void update(Marca marca) {
            FbConnection conn = ConnectionFactory.getConnection();
            FbCommand query = new FbCommand(UPDATE, conn);
            try
            {
                query.Parameters.AddWithValue("@descricao", marca.getDescricao());
                query.Parameters.AddWithValue("@codMarca", marca.getCodMarca());
                conn.Open();
                query.ExecuteNonQuery();
            }
            catch (FbException ex) {
                ex.Message.ToString();
            }
            finally {
                ConnectionFactory.closeAll(conn, query);
            }
        }

        public List<Marca> selectAll() {
            FbConnection conn = ConnectionFactory.getConnection();
            FbCommand query = new FbCommand(SELECTALL, conn);
            FbDataReader reader = null;
            List<Marca> lista = null;
            try
            {
                conn.Open();
                reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Marca marca = new Marca();
                    marca.setCodMarca(int.Parse(reader["codMarca"].ToString()));
                    marca.setDescricao(reader["descricao"].ToString());
                    lista.Add(marca);
                }
            }
            catch (FbException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                ConnectionFactory.closeAll(conn, query, reader);
            }
            return lista;
        }

        public Marca selectById(Marca marca) {
            FbConnection conn = ConnectionFactory.getConnection();
            FbCommand query = new FbCommand(SELECTBYID, conn);
            FbDataReader reader = null;
            try
            {
                query.Parameters.AddWithValue("@codMarca", marca.getCodMarca());
                conn.Open();
                reader = query.ExecuteReader();
                if (reader.Read()) {
                    marca.setCodMarca(int.Parse(reader["codMarca"].ToString()));
                    marca.setDescricao(reader["descricao"].ToString());
                }
            }
            catch (FbException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                ConnectionFactory.closeAll(conn, query, reader);
            }
            return marca;
        }
    }

}