using System.Collections.Generic;
using System.Linq;

namespace GIR_Preventive_ClientName
{
    public class DataReader
    {
        #region[Properties]
        public List<CallObj> ListCallObjs { get; set; }       
        #endregion

        #region[Constructor]
        public DataReader()
        {
            ListCallObjs = new List<CallObj>();             
        }
        #endregion
        /// <summary>
        /// Compara as listas geradas pelas consultas verificando se as chamadas atendidas foram de fatos gravadas.
        /// </summary>
        /// <param name="queryCallObjs">Lista de chamadas geradas pela consulta a tabela Gen_icon</param>
        /// <param name="querySmObjs">Lista de gravaçÕes geradas pela consulta a tabela Gen_Speechminer</param>
        #region[CompareQuerys]
        public void CompareQuerys(List<CallObj> queryCallObjs, List<SmObj> querySmObjs)
        {
            ListCallObjs = queryCallObjs;           

            for (int i = 0; i < querySmObjs.Count; i++)
            {
                var compare =  ListCallObjs.Where(l => l.CallID == querySmObjs[i].ExternalID).FirstOrDefault();
                if (compare != null)
                {    
                    ListCallObjs.RemoveAt(ListCallObjs.IndexOf(compare));
                }
            }
         
        }
        /// <summary>
        /// Compara as listas geradas pelas consultas verificando se as chamadas atendidas foram de fatos gravadas.
        /// </summary>
        /// <param name="queryEventObj">Lista de log de eventos gerada pela consulta a tabela VSS.</param>
        public void CompareQuerys(List<EventObj> queryEventObj)
        {
            for (int i = 0; i < ListCallObjs.Count; i++)
            {
                var compare = queryEventObj.Where(l => l.Connid == ListCallObjs[i].ConnID).FirstOrDefault();
                if (compare == null) 
                { 
                    ListCallObjs.RemoveAt(i); 
                    i--; 
                }
            }
        }
        #endregion
    }
}
