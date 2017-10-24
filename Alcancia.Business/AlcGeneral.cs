using Alcancia.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcancia.Business
{
    public class AlcGeneral
    {
        public Alcancia_AlcGeneral totalAlcancia(string UserId)
        {
            try
            {
                return new Alcancia.Sql.AlcGeneral().totalAlcancia(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Alcancia_AlcGeneral p)
        {
            try
            {
                new Alcancia.Sql.AlcGeneral().Insert(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Alcancia_AlcGeneral p)
        {
            try
            {
                new Alcancia.Sql.AlcGeneral().Update(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
