using System;
using System.Collections.Generic;

namespace nwtf_mobile_bl
{
    public partial class dto
    {
        public class claimDTO
        {

            public Guid id { get; set; }
            public string claimTransactionReferenceNumber { get; set; }

            public views.vwCustomer customer { get; set; }
            public views.vwMafEnrollmentClosure maf { get; set; }
            public views.vwClaimant claimant { get; set; }

            public string claimantID { get; set; }
            public int claimantType { get; set; }
            public string defaultPayeeID { get; set; }
            public string defaultPayeeName { get; set; }
            public int defaultPayeeType { get; set; }

            public Guid blockID { get; set; }
            public Guid branchID { get; set; }

            public List<views.vwCustomer> listCustomer { get; set; }
            public List<views.vwMafEnrollmentClosure> listMAF { get; set; }
            public List<views.vwClaimant> listClaimant { get; set; }
            public List<views.vwClaimTypes> listClaimType { get; set; }
            public List<views.vwClaimTypes> listSelectedClaimType { get; set; }

            public claimDTO()
            {
                customer = new views.vwCustomer();
                maf = new views.vwMafEnrollmentClosure();
                claimant = new views.vwClaimant();

                listCustomer = new List<views.vwCustomer>();
                listMAF = new List<views.vwMafEnrollmentClosure>();
                listClaimant = new List<views.vwClaimant>();
                listClaimType = new List<views.vwClaimTypes>();
                listSelectedClaimType = new List<views.vwClaimTypes>();
            }
        }
    }

}
