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
    
    public partial class callAudioTbl
    {
        public int callId { get; set; }
        public int segmentId { get; set; }
        public int owner { get; set; }
        public int format { get; set; }
        public float stretchSpeed { get; set; }
        public int siteId { get; set; }
        public int audioLen { get; set; }
        public int samplingRate { get; set; }
        public int storeMode { get; set; }
        public byte[] audio { get; set; }
        public string folder { get; set; }
        public string filename { get; set; }
        public int encryptionKey { get; set; }
    }
}