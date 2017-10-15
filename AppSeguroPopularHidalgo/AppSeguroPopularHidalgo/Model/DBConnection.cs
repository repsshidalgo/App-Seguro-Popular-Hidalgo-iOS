using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeguroPopularHidalgo.Model
{
    public class DBConnection
    {
        private SQLiteConnection _connection;

        public DBConnection(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Sintomas>();
            _connection.CreateTable<SintomasFisicos>();
            _connection.CreateTable<SintomasEmocionales>();
        }

        public void CreateSintoma(Sintomas sintoma)
        {
            _connection.Insert(sintoma);
            _connection.Commit();
        }

        public void CreateSintomaFisico(SintomasFisicos sintomaFisico)
        {
            _connection.Insert(sintomaFisico);
            _connection.Commit();
        }

        public void CreateSintomaEmocional(SintomasEmocionales sintomaEmocional)
        {
            _connection.Insert(sintomaEmocional);
            _connection.Commit();
        }

        public List<Sintomas> GetAllSintomas()
        {
            var query = from c in _connection.Table<Sintomas>()
                        select c;
            return query.ToList();
        }

        public List<SintomasFisicos> GetAllSintomasFisicos(int id)
        {
            var query = from c in _connection.Table<SintomasFisicos>()
                        where c.ídSintoma.Equals(id)
                        orderby c.Fecha descending
                        select c;
            return query.ToList();
        }

        public List<SintomasEmocionales> GetAllSintomasEmocionales(int id)
        {
            var query = from c in _connection.Table<SintomasEmocionales>()
                        where c.ídSintoma.Equals(id)
                        orderby c.Fecha descending
                        select c;
            return query.ToList();
        }
    }
}
