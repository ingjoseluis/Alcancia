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
    public class AlcGeneral : DataLayer
    {
        private static Alcancia_AlcGeneral GetData(IDataReader dr)
        {
            Alcancia_AlcGeneral p = new Alcancia_AlcGeneral();
            if (dr != null && !dr.IsClosed)
            {
                if (!Convert.IsDBNull(dr["IdAlcGeneral"]))
                {
                    p.IdAlcGeneral = dr.GetInt32(dr.GetOrdinal("IdAlcGeneral"));
                }
                if (!Convert.IsDBNull(dr["UserId"]))
                {
                    p.UserId = dr.GetString(dr.GetOrdinal("UserId"));
                }                
                if (!Convert.IsDBNull(dr["CantMonedas"]))
                {
                    p.CantMonedas = dr.GetInt32(dr.GetOrdinal("CantMonedas"));
                }
                if (!Convert.IsDBNull(dr["MontoMonedas"]))
                {
                    p.MontoMonedas = dr.GetDecimal(dr.GetOrdinal("MontoMonedas"));
                }
            }
            return p;
        }

        public Alcancia_AlcGeneral totalAlcancia(string UserId)
        {
            Alcancia_AlcGeneral p = new Alcancia_AlcGeneral();
            int TRANSAC;
            TRANSAC = 1;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_AlcGeneral", TRANSAC, null, UserId, null, null);
            IDataReader dr = db.ExecuteReader(cmd);

            while (dr.Read())
            {
                p = GetData(dr);
            }
            dr.Close();
            return p;
        }

        public void Insert(Alcancia_AlcGeneral p)
        {
            int TRANSAC;
            TRANSAC = 4;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_AlcGeneral", TRANSAC, p.IdAlcGeneral, p.UserId, p.CantMonedas, p.MontoMonedas);
            db.ExecuteNonQuery(cmd);
        }

        public void Update(Alcancia_AlcGeneral p)
        {
            int TRANSAC;
            TRANSAC = 5;
            DbCommand cmd = db.GetStoredProcCommand("Alcancia_AlcGeneral", TRANSAC, p.IdAlcGeneral, p.UserId, p.CantMonedas, p.MontoMonedas);
            db.ExecuteNonQuery(cmd);
        }
    }
}
