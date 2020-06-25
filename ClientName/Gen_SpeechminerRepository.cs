using GIR_Preventive_ClientName.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GIR_Preventive_ClientName
{
    public static class Gen_SpeechminerRepository
    {
        /// <summary>
        /// Conversão da data atual para TimeStamp.
        /// </summary>
        #region[Properties]               
        private static long _StartTimeStamp;
        private static long StartTimeStamp
        {
            get { return _StartTimeStamp; }
            set 
            {
                DateTimeOffset StartDate = DataController.StartDate;
                _StartTimeStamp = StartDate.ToUnixTimeSeconds(); 
            }
        }

        private static long _EndTimeStamp;
        private static long EndTimeStamp
        {
            get { return _EndTimeStamp; }
            set
            {
                DateTimeOffset EndDate = DataController.EndDate;
                _EndTimeStamp = EndDate.ToUnixTimeSeconds();
            }
        }
        #endregion

        /// <summary>
        /// Executa a consulta na tabela Gen_Speecminer efetuando as relações entre suas partes.
        /// </summary>
        /// <returns>Retorna uma lista de objetos contedo as propriedades de uma gravação.</returns>
        #region[QueryAnswerCalls]
        public static List<SmObj> QueryAnswerCalls()
        {    
            using (var context = new Alc_Gen_SPEECHMINEREntities())
            {
                context.Database.CommandTimeout = 180;

                var query = (from cmt in context.callMetaTbl
                             join cat in context.callAudioTbl on cmt.callId equals cat.callId into x
                             from cat in x.DefaultIfEmpty()
                             where (cmt.callTime >= StartTimeStamp && cmt.callTime <= EndTimeStamp && cat.folder != null)
                             select new SmObj
                             {
                                 ExternalID = cmt.externalId,
                                 Folder = cat.filename
                             }
                             ).OrderBy(x => x.ExternalID).Distinct().ToList(); 
                
                return query;
            }
        }
        #endregion
    }
}
