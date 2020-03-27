﻿using System;
using System.Collections.Generic;
using System.Text;

namespace nwtf_mobile_bl.dto
{
    public class claimDTO
    {

        public Guid id { get; set; }
        public string claimTransactionReferenceNumber { get; set; }

        public views.vwCustomer customer { get; set; }
        public views.vwMafEnrollmentClosure maf { get; set; }

        public string claimantID { get; set; }
        public int claimantType { get; set; }
        public string defaultPayeeID { get; set; }
        public string defaultPayeeName { get; set; }
        public int defaultPayeeType { get; set; }

        public  Guid blockID { get; set; }
        public Guid branchID { get; set; }

        public List<views.vwCustomer> listCustomer { get; set; }
        public List<views.vwMafEnrollmentClosure> listMAF { get; set; }
        public List<views.vwClaimant> listClaimants { get; set; }
        public List<views.vwClaimTypes> listClaimTypes { get; set; }
        public List<views.vwClaimTypes> listSelectedClaimTypes { get; set; }

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
