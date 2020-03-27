using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.dto
{
    public class claimDTO
    {

        views.vwClaimTransaction claimTransaction { get; set; }

        List<views.vwCustomer> listCustomer { get; set; }
        List<views.vwMafEnrollmentClosure> listMAF { get; set; }
        List<views.vwClaimant> listClaimants { get; set; }
        List<views.vwClaimTypes> listClaimTypes { get; set; }

        claimDTO()
        {
            claimTransaction = new views.vwClaimTransaction();

            listCustomer = new List<views.vwCustomer>();
            listMAF = new List<views.vwMafEnrollmentClosure>();
            listClaimants = new List<views.vwClaimant>();
            listClaimTypes = new List<views.vwClaimTypes>();
        }
    }
}
