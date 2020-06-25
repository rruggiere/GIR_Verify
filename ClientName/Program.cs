
namespace GIR_Preventive_ClientName
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               DataController.Execute();
            }
            catch (System.Exception e)
            {
                LogWriter.Write("Falha de execução.");
                LogWriter.Write(e.ToString());              
                EmailManipulator.EmailFailedExecute();                
            }
        }
    }
}
