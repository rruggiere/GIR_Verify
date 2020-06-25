using GIR_Preventive_ClientName.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GIR_Preventive_ClientName
{
    
    public static class VssRepository
    {
        /// <summary>
        /// Retira a conversão para GMT.
        /// </summary>
        #region[Properties]
        private static DateTime _StartDate;

        public static DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = DataController.StartDate.AddHours(-3); }
        }      

        private static DateTime _EndDate;

        public static DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = DataController.EndDate.AddHours(-3); }
        }
        #endregion

        /// <summary>
        /// Executa a consulta na tabela VSS para trazer os logs da chamada caso as consultas as outras tabelas não sejam conclusivas.
        /// </summary>
        /// <returns>Retorna uma lista de objetos contedo as propriedades de uma log de eventos de chamada.</returns>            
        #region[QueryLogCalls]
        public static List<EventObj> QueryLogCalls()
        {   
            using (var context = new AlcVSSEntities())
            {
                context.Database.CommandTimeout = 180;
                var query = (from mlc in context.Alc_mtr001LogChamadas
                             where (mlc.evt_hora >= StartDate && mlc.evt_hora <= EndDate && mlc.evt_nome == "EventEstablished")
                             select new EventObj
                             {
                                 Connid = mlc.evt_connid,
                                 Event = mlc.evt_nome
                             }
                             ).ToList();

                return query;
            }
            #endregion
        }
    }
}
