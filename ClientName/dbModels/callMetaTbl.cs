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
    
    public partial class callMetaTbl
    {
        public int callId { get; set; }
        public string customerId { get; set; }
        public string customerGroupId { get; set; }
        public int callTime { get; set; }
        public float callDuration { get; set; }
        public int programId { get; set; }
        public string externalId { get; set; }
        public int audioStatus { get; set; }
    }
}
