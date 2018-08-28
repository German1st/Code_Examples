using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Fixture
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string Department { get; set; }

        [Required(ErrorMessage = "*")]
        public string Entity { get; set; }

        [Required(ErrorMessage = "*")]
        public string FixtureNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public string VesselName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "CPDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CPDate { get; set; } 
        
        public string IMO { get; set; }
       
        [Display(Name = "Vessel Class")]
        public string Class { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string Charterer { get; set; }
        public string ChartererCustID { get; set; }
        public string ChartererGroup { get; set; }
         
        public string ChartererAddress { get; set; }

        public string ChartererWithAddress
        {
            get
            {
                return Charterer + "<BR>" + ChartererAddress;
            }
        }

        public int ChartererUniqueIDInDB { get; set; }

        [Required(ErrorMessage = "*")]
        public string Owner { get; set; }
        public string OwnerCustID { get; set; }
        public string OwnerGroup { get; set; }

        public string ThirdPartyBroker { get; set; }
        public string ThirdPartyBrokerID { get; set; }
        public float? ThirdPartyPercentage { get; set; }

        [Display(Name = "Invoice To")]
        public string OwnerAddress { get; set; }

        public string OwnerWithAddress
        {
            get
            {
                return Owner + OwnerAddress;
            }
        }

        public int OwnerUniqueIDInDB { get; set; }

        public string Cargo { get; set; } 

        [Display(Name = "QTY/Unit")]
        public string Quantity { get; set; }

        public string UOM { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string Desk { get; set; }

        [Required(ErrorMessage = "*")]
        public string Office { get; set; }

        public string CreatedBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdateDate { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string VoyageType { get; set; }

        public string LoadPort { get; set; }

        public string DischargePort { get; set; }

        public string Rate1 { get; set; }

        public string Rate2 { get; set; }

        [Display(Name = "Voyage Status")]
        public string Status { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string ChartererAddressUpdated { get; set; }

        public string OwnerAddressUpdated { get; set; }
    }
}
