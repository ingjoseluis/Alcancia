using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcancia.Entity
{
    public class Alcancia_AlcMoneda : IEntity
    {
        public Alcancia_AlcMoneda() { }

        int _IdAlcMoneda;
        string _UserId;
        int _IdDenominacion;
        int _CantDenominacion;
        decimal _MontoDenominacion;

        public int IdAlcMoneda { get { return _IdAlcMoneda; } set { _IdAlcMoneda = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public int IdDenominacion { get { return _IdDenominacion; } set { _IdDenominacion = value; } }
        public int CantDenominacion { get { return _CantDenominacion; } set { _CantDenominacion = value; } }
        public decimal MontoDenominacion { get { return _MontoDenominacion; } set { _MontoDenominacion = value; } }
    }
}
