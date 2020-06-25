using System;

namespace GIR_Preventive_ClientName
{
    public class CallObj
    {
        public string CallID { get; set; }
        public string ConnID { get; set; }
        public int? Duracao { get; set; }       
        private string _Created;        
        public string Created
        {
            get { return _Created; }
            set { _Created = Convert.ToDateTime(value).AddHours(-3).ToString("dd/MM HH:mm"); }
        }

        public string Event { get; set; }       
    }
}
