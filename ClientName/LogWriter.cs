using System;
using System.IO;

namespace GIR_Preventive_ClientName
{
    public static class LogWriter
    { 
        #region [Data]
        private static string LogText { get; set; }
        private static DateTime DataHora { get; set; }
        private static readonly string path = @"C:\GIRPreventive\LOGS\";
        private static readonly string pathTxt = @"C:\GIRPreventive\LOGS\Log_" + DataController.EndDate.ToString("dd/MM/yyyy").Substring(0, 10).Replace('/', '_');
        #endregion
        /// <summary>
        /// Finaliza a escrita dos logs e salva o arquivo de texto. 
        /// </summary>
        public static void EndLogCreate()
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            string[] files = Directory.GetFiles(path); 
            for (int i = 0; i < files.Length - 1; i++)
            {
                File.Delete(files[i]);
            }
           
            StreamWriter writer = new StreamWriter(pathTxt + ".txt");
            writer.Write(LogText);
            writer.Close();
        }
        /// <summary>
        /// Recebe um registro de tempo de execução.
        /// </summary>
        /// <param name="register">Tarefa sendo executada</param>
        public static void Write(string register)
        {
            DataHora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            LogText += DataHora.ToString() + " " + register + "\n";
        }

    }
}
