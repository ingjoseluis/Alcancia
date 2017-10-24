using Alcancia.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcancia.Business
{
    public class AlcMoneda
    {
        public List<Alcancia_AlcMoneda> List(string UserId)
        {
            try
            {               
                return new Alcancia.Sql.AlcMoneda().List(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Alcancia_AlcMoneda p)
        {
            try
            {
                new Alcancia.Sql.AlcMoneda().Insert(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Alcancia_AlcMoneda p)
        {
            try
            {
                new Alcancia.Sql.AlcMoneda().Update(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int IdAlcMoneda)
        {
            try
            {
                new Alcancia.Sql.AlcMoneda().Delete(IdAlcMoneda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
