using System;
using System.Collections.Generic;
using System.Linq;

namespace nwtf_mobile_bl
{
    public partial class dataservices
    {
        public class claimant
        {
            public static List<views.vwClaimant> getListClaimantForGrid(List<string> listProductClaimantSelected, views.vwCustomer customer)
            {
                bool customer_isMarried = views.vwCivilStatus.checkIfCustomerIsMarried(customer.customerCivilStatus);
                var listDependent = views.vwDependent.getListDependentByCustomerUID(customer.id);
                List<views.vwClaimant> listClaimant = new List<views.vwClaimant>();

                var member_IsSelected = listProductClaimantSelected.Where(type => type == systemconst.getClaimantDescription(1)).FirstOrDefault();
                var SA_IsSelected = listProductClaimantSelected.Where(type => type == systemconst.getClaimantDescription(2)).FirstOrDefault();
                var LD_IsSelected = listProductClaimantSelected.Where(type => type == systemconst.getClaimantDescription(3)).FirstOrDefault();

                // MEMBER
                if (!string.IsNullOrEmpty(member_IsSelected))
                {
                    var nrec = new views.vwClaimant();
                    nrec.id = customer.id;
                    nrec.customerID = customer.id;
                    nrec.claimantID = customer.customerID;
                    nrec.claimantFullName = customer.customerLastName + ", " +
                                            customer.customerFirstName + " " +
                                            customer.customerMiddleName + " " +
                                            customer.customerSuffix;
                    nrec.claimantBirthdate = customer.customerBirthdate;
                    nrec.claimantType = (int)systemconst.claimant.Member;
                    nrec.claimantRelation = systemconst.getClaimantDescription(1);
                    listClaimant.Add(nrec);
                }

                // SECONDARY ASSURED
                if (!string.IsNullOrEmpty(SA_IsSelected))
                {
                    // check if customer is married
                    if (customer_isMarried)
                    {
                        int spouseAgeLimit = int.Parse(views.vwRegistry.getEntry(systemreg.Key_AgeLimitSpouse));
                        int spouseAge = systool.calculateAge(customer.spouseBirthdate);

                        // check spouse age
                        if (spouseAge < spouseAgeLimit)
                        {
                            var nrec = new views.vwClaimant();
                            nrec.id = customer.id;
                            nrec.customerID = customer.id;
                            nrec.claimantID = customer.spouseID;
                            nrec.claimantFullName = customer.spouseLastName + ", " +
                                                    customer.spouseFirstName + " " +
                                                    customer.spouseMiddleName + " " +
                                                    customer.spouseSuffix;
                            nrec.claimantBirthdate = customer.spouseBirthdate;
                            nrec.claimantType = (int)systemconst.claimant.SecondaryAssured;
                            nrec.claimantRelation = "Spouse";
                            listClaimant.Add(nrec);
                        }
                    }
                    else
                    {
                        // check if mother exists. else, check father
                        var mother = listDependent.Where(dependent => dependent.dependentRelationship == systemconst.Relation_Mother).FirstOrDefault();
                        if (mother != null)
                        {
                            int motherAgeLimit = int.Parse(views.vwRegistry.getEntry(systemreg.Key_AgeLimitMother));
                            int motherAge = systool.calculateAge(DateTime.Parse(mother.dependentBirthdate));

                            // check mother age
                            if (motherAge < motherAgeLimit)
                            {
                                var nrec = new views.vwClaimant();
                                nrec.id = mother.id;
                                nrec.customerID = customer.id;
                                nrec.claimantID = mother.dependentID;
                                nrec.claimantFullName = mother.dependentFullName;
                                nrec.claimantBirthdate = DateTime.Parse(mother.dependentBirthdate);
                                nrec.claimantType = (int)systemconst.claimant.SecondaryAssured;
                                nrec.claimantRelation = mother.dependentRelationship;
                                listClaimant.Add(nrec);
                            }
                        }
                        else
                        {
                            var father = listDependent.Where(dependent => dependent.dependentRelationship == systemconst.Relation_Father).FirstOrDefault();
                            if (father != null)
                            {

                                // check father age
                                int fatherAgeLimit = int.Parse(views.vwRegistry.getEntry(systemreg.Key_AgeLimitFather));
                                int fatherAge = systool.calculateAge(DateTime.Parse(father.dependentBirthdate));

                                if (fatherAge < fatherAgeLimit)
                                {
                                    var nrec = new views.vwClaimant();
                                    nrec.id = father.id;
                                    nrec.customerID = customer.id;
                                    nrec.claimantID = father.dependentID;
                                    nrec.claimantFullName = father.dependentFullName;
                                    nrec.claimantBirthdate = DateTime.Parse(father.dependentBirthdate);
                                    nrec.claimantType = (int)systemconst.claimant.SecondaryAssured;
                                    nrec.claimantRelation = father.dependentRelationship;
                                    listClaimant.Add(nrec);
                                }
                            }
                        }

                    }
                }

                // LEGAL DEPENDENT
                if (!string.IsNullOrEmpty(LD_IsSelected))
                {
                    if (customer_isMarried)
                    {
                        // check if child exists
                        var child = listDependent.Where(dependent => dependent.dependentRelationship == systemconst.Relation_Child).FirstOrDefault();
                        if (child != null)
                        {
                            int childAgeLimit = int.Parse(views.vwRegistry.getEntry(systemreg.Key_AgeLimitChild));
                            int childAge = systool.calculateAge(DateTime.Parse(child.dependentBirthdate));

                            // check child age
                            if (childAge < childAgeLimit)
                            {
                                var nrec = new views.vwClaimant();
                                nrec.id = child.id;
                                nrec.customerID = customer.id;
                                nrec.claimantID = child.dependentID;
                                nrec.claimantFullName = child.dependentFullName;
                                nrec.claimantBirthdate = DateTime.Parse(child.dependentBirthdate);
                                nrec.claimantType = (int)systemconst.claimant.LegalDependent;
                                nrec.claimantRelation = child.dependentRelationship;
                                listClaimant.Add(nrec);
                            }
                        }
                    }
                    else
                    {
                        //check if father exists
                        var father = listDependent.Where(dependent => dependent.dependentRelationship == systemconst.Relation_Father).FirstOrDefault();
                        if (father != null)
                        {

                            // check father age
                            int fatherAgeLimit = int.Parse(views.vwRegistry.getEntry(systemreg.Key_AgeLimitFather));
                            int fatherAge = systool.calculateAge(DateTime.Parse(father.dependentBirthdate));

                            if (fatherAge < fatherAgeLimit)
                            {
                                var nrec = new views.vwClaimant();
                                nrec.id = father.id;
                                nrec.customerID = customer.id;
                                nrec.claimantID = father.dependentID;
                                nrec.claimantFullName = father.dependentFullName;
                                nrec.claimantBirthdate = DateTime.Parse(father.dependentBirthdate);
                                nrec.claimantType = (int)systemconst.claimant.LegalDependent;
                                nrec.claimantRelation = father.dependentRelationship;
                                listClaimant.Add(nrec);
                            }
                        }
                    }
                }
                return listClaimant;
            }
        }
    }
}
