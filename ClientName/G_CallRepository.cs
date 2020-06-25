using GIR_Preventive_ClientName.dbModels;
using System.Collections.Generic;
using System.Linq;

namespace GIR_Preventive_ClientName
{
    
    public static class Gen_IconRepository
    {
        /// <summary>
        /// Executa a consulta na tabela Gen_ICON efetuando as relações entre suas partes.
        /// </summary>
        /// <returns>Retorna uma lista de objetos contedo as propriedades de uma chamada.</returns>
        #region[QueryAnswerCalls]
        public static List<CallObj> QueryAnswerCalls()
        {  
            using (var context = new Alc_Gen_ICONEntities())
            {               
                context.Database.CommandTimeout = 180;
                var query = (from gc in context.G_CALL
                             join gp in context.G_PARTY on gc.CALLID equals gp.CALLID
                             join gps in context.G_PARTY_STAT on gp.PARTYID equals gps.PARTYID
                             where (gp.CREATED >= DataController.StartDate && gp.CREATED <= DataController.EndDate && gp.AGENTID != 0 && gps.TT_ON_CONNECTED != 0)
                             select new CallObj { CallID = gc.CALLID, 
                                                  ConnID = gc.CONNID, 
                                                  Duracao = gps.TT_ON_CONNECTED, 
                                                  Created = gc.CREATED.ToString(),
                                                  Event = "Gravação não postada."
                                                 } 
                             ).OrderBy(x=> x.CallID).Distinct().ToList();

                return query;
            }
        }
        #endregion
    }
}
