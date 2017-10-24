using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcancia.Sql
{
    public class DataLayer
    {
        public Database db;
        public DbCommand cmd;
        private DbConnection connection;
        private DbTransaction transaction;

        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        public DbConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public int ExecuteNonQuery(string store, params object[] parameters)
        {
            if (Transaction == null)
            {
                return db.ExecuteNonQuery(store, parameters);
            }
            else
            {
                return db.ExecuteNonQuery(Transaction, store, parameters);
            }
        }

        public DbCommand GetStoredProcCommand(string store, params object[] parameters)
        {

            return db.GetStoredProcCommand(store, parameters);

        }

        public int ExecuteNonQuery(DbCommand command)
        {
            if (Transaction == null)
            {
                return db.ExecuteNonQuery(command);
            }
            else
            {
                return db.ExecuteNonQuery(command, Transaction);
            }
        }

        public DataLayer()
        {
            db = DatabaseFactory.CreateDatabase("AlcanciaSqlConnection");
        }

        public DataLayer(bool transaction)
        {
            db = DatabaseFactory.CreateDatabase("AlcanciaSqlConnection");
            Connection = db.CreateConnection();
            Connection.Open();
            if (transaction)
                Transaction = Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void RollBack()
        {
            Transaction.Rollback();
        }
        public DataLayer(Database dbexternal, DbTransaction transaction)
        {
            db = dbexternal;
            Transaction = transaction;
        }

        /// <summary>
        /// Verifica si una fecha viene con valor y si no retorna null 
        /// </summary>
        /// <param name="newvalue">Valor a comparar</param>
        /// <returns>Un null o el valor enviado</returns>
        protected object GetValueDateTimeKey(DateTime datevalue)
        {
            DateTime date = new DateTime();
            if (datevalue <= date)
                return ConvertDateToFormatSQLServer(Convert.ToDateTime("01/01/1900"));
            else
            {
                string datestring = String.Empty;
                datestring = ConvertDateToFormatSQLServer(datevalue);
                return datestring;
            }
        }
        /// <summary>
        /// Verifica si una fecha viene con valor y si no retorna null 
        /// </summary>
        /// <param name="newvalue">Valor a comparar</param>
        /// <returns>Un null o el valor enviado</returns>


        protected object GetValueDateTimeHourMinuteKey(DateTime datevalue)
        {
            DateTime date = new DateTime();
            if (datevalue <= date)
                return ConvertDateToFormatSQLServer(Convert.ToDateTime("01/01/1900"));
            else
            {
                string datestring = String.Empty;
                datestring = ConvertDateAndTimeToFormatSQLServer(datevalue);
                return datestring;
            }
        }
        /// <summary>
        /// Verifica si un valor es igual a 0 y retorna un DBNull de lo contrario retorna su valor
        /// </summary>
        /// <param name="newvalue">Valor a comparar</param>
        /// <returns>Un null o el valor enviado</returns>
        protected object GetValueDecimalKey(decimal newvalue)
        {
            if (newvalue == 0)
                return System.DBNull.Value;
            else
                return newvalue;
        }

        /// <summary>
        /// Verifica si un valor es igual a 0 y retorna un DBNull de lo contrario retorna su valor
        /// </summary>
        /// <param name="newvalue">Valor a comparar</param>
        /// <returns>Un null o el valor enviado</returns>
        protected object GetValueIntegerKey(int newvalue)
        {
            if (newvalue == 0)
                return System.DBNull.Value;
            else
                return newvalue;
        }

        /// <summary>
        /// Verifica si un valor es igual a "" y retorna un DBNull de lo contrario retorna su valor
        /// </summary>
        /// <param name="newvalue">Valor a comparar</param>
        /// <returns>Un null o el valor enviado</returns>
        protected object GetValueStringKey(string newvalue)
        {
            if (newvalue == "")
                return System.DBNull.Value;
            else
                return newvalue;
        }

        /// <summary>
        /// Obtiene el valor de un campo en formato texto
        /// </summary>
        /// <param name="reader">objeto que realiza lectura</param>
        /// <param name="field">campo que se quiere revisar</param>
        /// <returns></returns>
        protected string GetString(IDataReader reader, string field)
        {
            int index = reader.GetOrdinal(field);
            if (reader.GetValue(index) == System.DBNull.Value)
                return "";
            else
                return reader.GetString(index);
        }

        /// <summary>
        /// Obtiene el valor de un campo en formato Int32
        /// </summary>
        /// <param name="reader">objeto que realiza lectura</param>
        /// <param name="field">campo que se quiere revisar</param>
        /// <returns></returns>
        protected int GetInt32(IDataReader reader, string field)
        {
            int index = reader.GetOrdinal(field);
            if (reader.GetValue(index) == System.DBNull.Value)
                return 0;
            else
                return reader.GetInt32(index);
        }

        /// <summary>
        /// Obtiene el valor de un campo en formato Bool
        /// </summary>
        /// <param name="reader">objeto que realiza lectura</param>
        /// <param name="field">campo que se quiere revisar</param>
        /// <returns></returns>
        protected bool? GetBoolNullable(IDataReader reader, string field)
        {
            int index = reader.GetOrdinal(field);
            if (reader.GetValue(index) == System.DBNull.Value)
                return null;
            else
                return reader.GetBoolean(index);
        }

        /// <summary>
        /// Obtiene el valor de un campo en formato Bool
        /// </summary>
        /// <param name="reader">objeto que realiza lectura</param>
        /// <param name="field">campo que se quiere revisar</param>
        /// <returns></returns>
        protected bool GetBool(IDataReader reader, string field)
        {
            int index = reader.GetOrdinal(field);
            if (reader.GetValue(index) == System.DBNull.Value)
                return false;
            else
                return reader.GetBoolean(index);
        }

        /// <summary>
        /// Obtiene el valor de un campo en formato decimal
        /// </summary>
        /// <param name="reader">objeto que realiza lectura</param>
        /// <param name="field">campo que se quiere revisar</param>
        /// <returns></returns>
        protected decimal GetDecimal(IDataReader reader, string field)
        {
            int index = reader.GetOrdinal(field);
            if (reader.GetValue(index) == System.DBNull.Value)
                return 0;
            else
                return reader.GetDecimal(index);
        }


        /// <summary>
        /// Obtiene el valor de un campo en formato DateTime
        /// </summary>
        /// <param name="reader">objeto que realiza lectura</param>
        /// <param name="field">campo que se quiere revisar</param>
        /// <returns></returns>
        protected DateTime GetDateTime(IDataReader reader, string field)
        {
            int index = reader.GetOrdinal(field);
            if (reader.GetValue(index) == System.DBNull.Value)
                return DateTime.MinValue;
            else
                return reader.GetDateTime(index);
        }

        /// <summary>
        /// Funcion que retorna el metodo y clase que realiza llamado a la cache
        /// </summary>
        /// <param name="className">Nombre de la clase</param>
        /// <returns>Nombre del metodo</returns>
        /// <author> Informática & Tecnología - JM </author> 
        private string GetCallingMethodName(out string className)
        {
            className = String.Empty;
            string methodName = String.Empty;
            System.Diagnostics.StackTrace stack = new System.Diagnostics.StackTrace(false);
            for (int i = 1; i < stack.FrameCount; i++)
            {
                System.Reflection.MethodBase mb = stack.GetFrame(i).GetMethod();
                if (mb.DeclaringType != typeof(DataLayer))
                {
                    methodName = mb.Name;
                    className = mb.DeclaringType.Name;
                    break;
                }
            }
            return methodName;
        }

        public IDataReader ExecuteReader(string store, params object[] parameters)
        {
            if (Transaction == null)
            {
                return db.ExecuteReader(store, parameters);
            }
            else
            {
                return db.ExecuteReader(Transaction, store, parameters);
            }

        }

        /// <summary>
        /// Convierte una fecha al formato que SQL-Server reconoce como válido
        /// </summary>
        /// <param name="Fecha">Fecha y hora a convertir</param>
        /// <returns>Fecha en el formato yyyyMMdd</returns>
        public string ConvertDateToFormatSQLServer(DateTime Fecha)
        {
            string strFecha = String.Concat(Fecha.Year, Fecha.Month.ToString().PadLeft(2, '0'), Fecha.Day.ToString().PadLeft(2, '0'));

            return strFecha;
        }

        /// <summary>
        /// Convierte una fecha que incluye la hora al formato que SQL-Server reconoce como válido
        /// </summary>
        /// <param name="Fecha">Fecha y hora a convertir</param>
        /// <returns>Fecha y hora en formato yyyyMMdd HH:mm:ss</returns>        
        public string ConvertDateAndTimeToFormatSQLServer(DateTime Fecha)
        {
            if (Fecha == DateTime.MinValue)
            {
                Fecha = Convert.ToDateTime("01/01/1900");
            }

            string strFormat = "yyyyMMddHHmmss'Z'";
            string strFecha = String.Concat(Fecha.Year, Fecha.Month.ToString().PadLeft(2, '0'), Fecha.Day.ToString().PadLeft(2, '0'));
            string strFechaMil = String.Concat(strFecha, Fecha.Hour.ToString().PadLeft(2, '0'), Fecha.Minute.ToString().PadLeft(2, '0'), Fecha.Second.ToString().PadLeft(2, '0'), "Z");
            DateTime dt = DateTime.ParseExact(strFechaMil, strFormat, System.Globalization.CultureInfo.InvariantCulture);

            string strHora = String.Concat(dt.Hour.ToString().PadLeft(2, '0'), ":", dt.Minute.ToString().PadLeft(2, '0'), ":", dt.Second.ToString().PadLeft(2, '0'));

            return String.Concat(strFecha, " ", strHora);
        }
    }
}
