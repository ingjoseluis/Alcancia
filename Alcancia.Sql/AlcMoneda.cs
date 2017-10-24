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
    public class AlcMoneda : DataLayer
    {
        private static Alcancia_AlcMoneda GetData(IDataReader dr)
        {
            Alcancia_AlcMoneda p = new Alcancia_AlcMoneda();
            if (dr != null && !dr.IsClosed)
            {
                if (!Convert.IsDBNull(dr["IdAlcMoneda"]))
                {
                    p.IdAlcMoneda = dr.GetInt32(dr.GetOrdinal("IdAlcMoneda"));
                }
                if (!Convert.IsDBNull(dr["UserId"]))
                {
                    p.UserId = dr.GetString(dr.GetOrdinal("UserId"));
                }
                if (!Convert.IsDBNull(dr["IdDenominacion"]))
                {
                    p.IdDenominacion = dr.GetInt32(dr.GetOrdinal("IdDenominacion"));
                }
                if (!Convert.IsDBNull(dr["CantDenominacion"]))
                {
                    p.CantDenominacion = dr.GetInt32(dr.GetOrdinal("CantDenominacion"));
                }
                if (!Convert.IsDBNull(dr["MontoDenominacion"]))
                {
                    p.MontoDenominacion = dr.GetDecimal(dr.GetOrdinal("MontoDenominacion"));
                }
            }
            return p;
        }

        public List<Alcancia_AlcMoneda> List(string UserId)
        {
            List<Alcancia_AlcMoneda> l = new List<Alcancia_AlcMoneda>();
            Alcancia_AlcMoneda p = new Alcancia_AlcMoneda();
            int TRANSAC;            
            TRANSAC = 1;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_AlcMoneda", TRANSAC, null, UserId, null, null, null);
            IDataReader dr = db.ExecuteReader(cmd);

            while (dr.Read())
            {
                p = GetData(dr);
                l.Add(p);
            }
            dr.Close();
            return l;
        }

        public void Insert(Alcancia_AlcMoneda p)
        {
            int TRANSAC;
            TRANSAC = 4;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_AlcMoneda", TRANSAC, p.IdAlcMoneda, p.UserId, p.IdDenominacion, p.CantDenominacion, p.MontoDenominacion);
            db.ExecuteNonQuery(cmd);
        }

        public void Update(Alcancia_AlcMoneda p)
        {
            int TRANSAC;
            TRANSAC = 5;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_AlcMoneda", TRANSAC, p.IdAlcMoneda, p.UserId, p.IdDenominacion, p.CantDenominacion, p.MontoDenominacion);
            db.ExecuteNonQuery(cmd);
        }

        public void Delete(int IdAlcMoneda)
        {
            int TRANSAC;
            int n;
            TRANSAC = 2;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_AlcMoneda", TRANSAC, IdAlcMoneda, null, null, null, null);
            n = db.ExecuteNonQuery(cmd);
        }
    }
}
