//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIR_Preventive_ClientName.dbModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alc_mtr001LogChamadas
    {
        public int sequencial { get; set; }
        public string evt_connid { get; set; }
        public System.DateTime evt_hora { get; set; }
        public int evt_id { get; set; }
        public string evt_nome { get; set; }
        public string evt_origem { get; set; }
        public string evt_fila { get; set; }
        public string evt_agentid { get; set; }
        public string evt_thisDN { get; set; }
        public string evt_otherdn { get; set; }
        public string evt_thisqueue { get; set; }
        public string evt_otherqueue { get; set; }
        public int evt_callstate { get; set; }
        public System.DateTime evt_registro { get; set; }
    }
}