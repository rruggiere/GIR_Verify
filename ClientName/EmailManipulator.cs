using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace GIR_Preventive_ClientName
{
    public  static class EmailManipulator
    {
        #region [Email_Start_String]
        private static string newEmail =
                  "<table style=\"color: white; font-family: Arial, Helvetica, sans-serif; text-align: center; background-color:rgb(30, 30, 30)\">" +
                  "<tr style=\"background-color:rgb(30, 30, 30);text-align:center; margin: 0px;display:table;float:left; height: 70px;\">" +
                  "<th style=\"width: 350;\"></th>" +
                   $"<th style=\"width: 250;\">{DataController.CLIENT_NAME}<br>{DataController.StartDate.ToString("dd/MM/yyyy")} até {DataController.EndDate.ToString("dd/MM/yyyy")}</th>" +
                  "<th style=\"width: 250;\"></th>" +
                  "<th style=\"width: 250;\"></th>" +
                  "<th style=\"width: 250;\"></th>" +
                  "</tr>";
        #endregion

        /// <summary>
        /// Corpo do e-mail para o caso de nenhuma falha ser detectada pela consulta ao banco.
        /// </summary>
        #region [EmailNoErros]
        public static void EmailNoErrors()
        {
            newEmail += "<tr style=\"background-color:rgb(30, 30, 30);text-align:center; margin: 0px;display:table;float:left;\">" +
                        "<td style=\"width: 1350;\">Nenhuma falha foi encontrada.</td>" +
                       "</tr>";
            newEmail += "<tr style=\"background-color:rgb(30, 30, 30);text-align:center; margin: 0px;display:table;float:left;\"><td style=\"width: 1350;\"></td></table>";
            SendEmail();
        }
        #endregion

        /// <summary>
        /// Corpo do e-mail caso possíveis ligações com falhas de postagem sejam encontradas pela consulta ao banco.
        /// </summary>
        /// <param name="callObjsList"></param>        
        #region [EmailFailedCalls]
        public static void EmailFailedCalls(List<CallObj> callObjsList)
        {
            double rgb;
            newEmail +=
                 "<tr style=\"background-color:rgb(40, 40, 40);text-align:center; margin: 0px;display:table;float:left; height: 40px;\">" +
                 "<th style=\"width: 250;\">CALLID</th>" +
                 "<th style=\"width: 250;\">CONNID</th>" +
                 "<th style=\"width: 250;\">DURAÇÃO</th>" +
                 "<th style=\"width: 250;\">DATA</th>" +
                 "<th style=\"width: 250;\">EVENTO</th>" +
                 "</tr>";

            for (int i = 0; i < callObjsList.Count; i++)
            {
                rgb = i % 2 == 0 ? 70 : 90;

                newEmail +=
                    $"<tr style=\"background-color:rgb({rgb}, {rgb}, {rgb});text-align:center; margin: 0px;display:table;float:left;\">" +
                    "<td style=\"width: 250;\">" +
                    $"&nbsp{ callObjsList[i].CallID }&nbsp&nbsp" +
                    "</td>" +
                    "<td style=\"width: 250;\">" +
                    $"{ callObjsList[i].ConnID }" +
                    "</td>" +
                    "<td style=\"width: 250;\">" +
                    $"{ callObjsList[i].Duracao }" +
                    "</td>" +
                    "<td style=\"width: 250;\">" +
                    $"{ callObjsList[i].Created }" +
                    "</td>" +
                    "<td style=\"width: 250;\">" +
                    $"{ callObjsList[i].Event }" +
                    "</td>" +
                    "</tr>";
            }

            newEmail += "<tr style=\"background-color:rgb(30, 30, 30);text-align:center; margin: 0px;display:table;float:left;\"><td style=\"width: 1350;\"></td></table>";
            SendEmail();
        }
        #endregion

        /// <summary>
        /// Corpo do e-mail caso haja uma falha geral na execução da verificação.
        /// </summary>        
        #region [EmailFailedExecute]
        public static void EmailFailedExecute()
        {
            newEmail +=
                "<tr style=\"background-color:rgb(30, 30, 30);text-align:center; margin: 0px;display:table;float:left;\"><td style=\"width: 1350;\">" +
                "Erro de execução favor verificar o registro de logs." +
                "</td>" +
                "<tr style=\"background-color:rgb(30, 30, 30);text-align:center; margin: 0px;display:table;float:left;\"><td style=\"width: 1350;\"></td></table>";

            SendEmail();
        }
        #endregion

        /// <summary>
        /// Função que efetua o envio do e-mail com os dados resgatados.
        /// </summary>
        #region [SendMail]
        private static void SendEmail()
        {

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("Alc.gir@gmail.com", "Abc123@#"),
                EnableSsl = true
            };

            MailMessage mensagemEmail = new MailMessage("Alc.gir@gmail.com", "reinaldo.cruz@Alc.com.br", DataController.CLIENT_NAME + " - PREVENTIVA GIR", newEmail)
            {
                IsBodyHtml = true
            };

            client.Send(mensagemEmail);
            LogWriter.EndLogCreate();
        }
        #endregion

    }
}

