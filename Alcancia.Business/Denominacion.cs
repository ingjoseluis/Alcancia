using Alcancia.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcancia.Business
{
    public class Denominacion
    {
        public List<Alcancia_Denominacion> listDenominaciones()
        {
            try
            {
                return new Alcancia.Sql.Denominacion().listDenominaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alcancia_Denominacion denominacionValor(int Denominacion)
        {
            try
            {                
                return new Alcancia.Sql.Denominacion().denominacionValor(Denominacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alcancia_Denominacion denominacionId(int IdDenominacion)
        {
            try
            {
                return new Alcancia.Sql.Denominacion().denominacionId(IdDenominacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Alcancia_Denominacion p)
        {
            try
            {
                new Alcancia.Sql.Denominacion().Insert(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Alcancia_Denominacion p)
        {
            try
            {
                new Alcancia.Sql.Denominacion().Update(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int idDenominacion)
        {
            try
            {
                new Alcancia.Sql.Denominacion().Delete(idDenominacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
