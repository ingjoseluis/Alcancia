using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcancia.Entity
{
    public class Alcancia_AlcGeneral : IEntity
    {
        public Alcancia_AlcGeneral() { }

        int _IdAlcGeneral;
        string _UserId;
        int _CantMonedas;        
        decimal _MontoMonedas;

        public int IdAlcGeneral { get { return _IdAlcGeneral; } set { _IdAlcGeneral = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public int CantMonedas { get { return _CantMonedas; } set { _CantMonedas = value; } }        
        public decimal MontoMonedas { get { return _MontoMonedas; } set { _MontoMonedas = value; } }
    }
}
