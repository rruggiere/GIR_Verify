using System;
using System.Collections.Generic;

namespace GIR_Preventive_ClientName
{
    public static class DataController
    {
        #region[GlobalDates]
        public static DateTime StartDate = DateTime.Now.AddDays(-1).AddHours(-3 - DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute).AddSeconds(-DateTime.Now.Second);
        public static DateTime EndDate = DateTime.Now.AddHours(-3 - DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute).AddSeconds(-DateTime.Now.Second);
        #endregion
        #region[Constant]
        public const string CLIENT_NAME = "ClientName";
        #endregion

        /// <summary>
        /// Executa a cadeia de consultas da preventiva e envia os resultados para geração do e-mail. 
        /// </summary>
        #region[Execute]
        public static void Execute()
        {
            #region[LogWirte]
            LogWriter.Write("Instanciando um novo DataReader");
            #endregion
            DataReader newReader = new DataReader();

            #region[LogWirte]
            LogWriter.Write("Comprado o resultado das consulstas:  newReader.CompareQuerys(Gen_IconRepository.QueryAnswerCalls(), Gen_SpeechminerRepository.QueryAnswerCalls())");
            #endregion
            newReader.CompareQuerys(Gen_IconRepository.QueryAnswerCalls(), Gen_SpeechminerRepository.QueryAnswerCalls());

            #region[LogWirte]          
            LogWriter.Write($"Chamadas para serem verificadas nos logs: {newReader.ListCallObjs.Count}\nSe maior que 0 executa: newReader.CompareQuerys(VssRepository.QueryLogCalls()");
            #endregion
            if (newReader.ListCallObjs.Count > 0) newReader.CompareQuerys(VssRepository.QueryLogCalls());
            
            #region[LogWirte]
            LogWriter.Write("Chamando o método: GenerateEmail(newReader.ListCallObjs)");
            #endregion
            GenerateEmail(newReader.ListCallObjs);
        }
        #endregion
        /// <summary>
        /// Verifica que os resultados gerados e envia as informações para que o e-mail seja gerado e enviado.
        /// </summary>
        private static void GenerateEmail(List<CallObj> results)
        {
            if (results.Count > 0) EmailManipulator.EmailFailedCalls(results);
            else EmailManipulator.EmailNoErrors();
        }
    }
}
