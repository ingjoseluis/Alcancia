using Alcancia.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcancia.Sql
{
    public class Denominacion : DataLayer
    {
        private static Alcancia_Denominacion GetData(IDataReader dr)
        {
            Alcancia_Denominacion p = new Alcancia_Denominacion();
            if (dr != null && !dr.IsClosed)
            {
                if (!Convert.IsDBNull(dr["IdDenominacion"]))
                {
                    p.IdDenominacion = dr.GetInt32(dr.GetOrdinal("IdDenominacion"));
                }
                if (!Convert.IsDBNull(dr["Denominacion"]))
                {
                    p.Denominacion = dr.GetInt32(dr.GetOrdinal("Denominacion"));
                }
            }
            return p;
        }

        public List<Alcancia_Denominacion> listDenominaciones()
        {
            List<Alcancia_Denominacion> l = new List<Alcancia_Denominacion>();
            Alcancia_Denominacion p = new Alcancia_Denominacion();
            int TRANSAC;
            TRANSAC = 3;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_Denominacion", TRANSAC, null, null);
            IDataReader dr = db.ExecuteReader(cmd);

            while (dr.Read())
            {
                p = GetData(dr);
                l.Add(p);
            }
            dr.Close();
            return l;
        }

        public Alcancia_Denominacion denominacionValor(int Denominacion)
        {
            Alcancia_Denominacion p = new Alcancia_Denominacion();
            int TRANSAC;            
            TRANSAC = 1;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_Denominacion", TRANSAC, null, Denominacion);
            IDataReader dr = db.ExecuteReader(cmd);

            while (dr.Read())
            {
                p = GetData(dr);                
            }
            dr.Close();
            return p;
        }

        public Alcancia_Denominacion denominacionId(int IdDenominacion)
        {
            Alcancia_Denominacion p = new Alcancia_Denominacion();
            int TRANSAC;
            TRANSAC = 6;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_Denominacion", TRANSAC, IdDenominacion, null);
            IDataReader dr = db.ExecuteReader(cmd);

            while (dr.Read())
            {
                p = GetData(dr);
            }
            dr.Close();
            return p;
        }

        public void Insert(Alcancia_Denominacion p)
        {
            int TRANSAC;
            TRANSAC = 4;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_Denominacion", TRANSAC, p.IdDenominacion, p.Denominacion);
            db.ExecuteNonQuery(cmd);
        }

        public void Update(Alcancia_Denominacion p)
        {
            int TRANSAC;
            TRANSAC = 5;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_Denominacion", TRANSAC, p.IdDenominacion, p.Denominacion);
            db.ExecuteNonQuery(cmd);
        }

        public void Delete(int idDenominacion)
        {
            int TRANSAC;
            int n;            
            TRANSAC = 2;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_Denominacion", TRANSAC, idDenominacion, null);
            n = db.ExecuteNonQuery(cmd);
        }
    }
}
