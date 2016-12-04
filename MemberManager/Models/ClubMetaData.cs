using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MemberManager.Models
{
    [MetadataType(typeof(ClubMetaData))]
    public partial class Club
    {

    }
    public class ClubMetaData
    {
        public int ClubId;
        public string Name;
        [Display(Name = "Legal Name")]
        public string LegalName;
        [Display(Name = "Short Name")]
        public string ShortName;
        [Display(Name = "Website Link")]
        public string WebsiteURL;
        [Display(Name = "Facebook Link")]
        public string FacebookURL;
        [Display(Name = "Is Member?")]
        public bool MemberClub;
        [Display(Name = "Is Country Club?")]
        public bool CountryClub;
        [Display(Name = "Parent Club")]
        public Nullable<int> MemberOf;
        public string Email;
        [Display(Name = "Address Line 1")]
        public string AddressLine1;
        [Display(Name = "Address Line 2")]
        public string AddressLine2;
        [Display(Name = "Suburb")]
        public string Locality;
        public string Postcode;
        public string State;
    }
}