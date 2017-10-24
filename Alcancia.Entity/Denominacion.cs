using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcancia.Entity
{
    public class Alcancia_Denominacion : IEntity
    {
        public Alcancia_Denominacion() { }

        int _IdDenominacion;
        int _Denominacion;

        public int IdDenominacion { get { return _IdDenominacion; } set { _IdDenominacion = value; } }
        public int Denominacion { get { return _Denominacion; } set { _Denominacion = value; } }
    }
}
