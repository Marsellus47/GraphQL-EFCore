using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
    [Table("ObjectMetadata", Schema = "HamSFA_Interface")]
    public partial class ObjectMetadata
    {
        [Column("SI_SessionID")]
        public int SessionID { get; set; }
        [Column("OMTD_ID")]
        public int ID { get; set; }
        [Column("OMTDD_ID")]
        public short ObjectMetadataDefinitionID { get; set; }
        [Column("OMTDD_ObjectID")]
        [StringLength(128)]
        public string ObjectID { get; set; }
        [Required]
        [Column("OMTDD_Value")]
        [StringLength(128)]
        public string Value { get; set; }

		public ObjectMetadataDefinition ObjectMetadataDefinition { get; set; }
    }
}
