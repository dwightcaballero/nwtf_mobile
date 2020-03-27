using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.dto
{
    public class claimDTO
    {

        Guid id { get; set; }
        string claimTransactionReferenceNumber { get; set; }

        views.vwCustomer customer { get; set; }
        views.vwMafEnrollmentClosure maf { get; set; }

        string claimantID { get; set; }
        int claimantType { get; set; }
        string defaultPayeeID { get; set; }
        string defaultPayeeName { get; set; }
        int defaultPayeeType { get; set; }

        Guid blockID { get; set; }
        Guid branchID { get; set; }

        List<views.vwCustomer> listCustomer { get; set; }
        List<views.vwMafEnrollmentClosure> listMAF { get; set; }
        List<views.vwClaimant> listClaimants { get; set; }
        List<views.vwClaimTypes> listClaimTypes { get; set; }
        List<views.vwClaimTypes> listSelectedClaimTypes { get; set; }

        claimDTO()
        {
            listCustomer = new List<views.vwCustomer>();
            listMAF = new List<views.vwMafEnrollmentClosure>();
            listClaimants = new List<views.vwClaimant>();
            listClaimTypes = new List<views.vwClaimTypes>();
            listSelectedClaimTypes = new List<views.vwClaimTypes>();
        }
    }
}
