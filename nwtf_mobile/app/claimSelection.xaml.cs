﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using nwtf_mobile_bl;

namespace nwtf_mobile.app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class claimSelection : ContentPage
    {
        dto.claimDTO claimDTO { get; set; }
        custombinds.cbClaimSelectionHeader cbClaimSelectionHeader = new custombinds.cbClaimSelectionHeader();
        controllers.claimTransaction pcon = new controllers.claimTransaction();
       
        public claimSelection()
        {
            InitializeComponent();
            claimDTO = new dto.claimDTO();

            hideStacks();
            subscribeToAllEvents();
            pcon.getListCustomerForGrid();
        }

        // hide all stacks in claim selection
        void hideStacks()
        {
            stackHeader.IsVisible = false;

            stackCustomer.IsVisible = false;
            stackMAF.IsVisible = false;
            stackClaimant.IsVisible = false;
            stackClaimType.IsVisible = false;
        }   

        // subscribe to all events in the controller
        void subscribeToAllEvents()
        {
            pcon.showMessage += Pcon_showMessage;
            pcon.loadCustomerGrid += Pcon_loadCustomerGrid;
            pcon.loadMAFGrid += Pcon_loadMAFGrid;
            pcon.loadClaimantGrid += Pcon_loadClaimantGrid;
            pcon.loadClaimTypeGrid += Pcon_loadClaimTypeGrid;
            pcon.saveClaimTypeSelected += Pcon_saveClaimTypeSelected;
        }

        // display messages
        void displayMessage(string title, string message, string buttonName)
        {
            DisplayAlert(title, message, buttonName);
        }

        private void Pcon_showMessage(object sender, (string, string, string) e)
        {
            displayMessage(e.Item1, e.Item2, e.Item3);
        }

        private void Pcon_loadCustomerGrid(object sender, List<views.vwCustomer> e)
        {
            Title = "Selection of Customer";
            stackCustomer.IsVisible = true;

            claimDTO.listCustomer = e;
            lvCustomer.ItemsSource = e;
        }

        private void btnCustomer_Clicked(object sender, System.EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid customerID = (Guid)btnSelected.CommandParameter;
            pcon.getListMAFForGrid(customerID);
        }

        private void Pcon_loadMAFGrid(object sender, (List<views.vwMafEnrollmentClosure>, views.vwCustomer) e)
        {
            var listMAF = e.Item1;
            var customer = e.Item2;

            Title = "Selection of Customer's Enrolled Packages";
            stackCustomer.IsVisible = false;
            stackMAF.IsVisible = true;

            stackHeader.IsVisible = true;
            gridClaimSelectionHeader.BindingContext = cbClaimSelectionHeader;
            cbClaimSelectionHeader.customerID = customer.customerID;
            cbClaimSelectionHeader.customerName = customer.customerLastName + ", " +
                                                  customer.customerFirstName + " " +
                                                  customer.customerMiddleName + " " +
                                                  customer.customerSuffix;
            claimDTO.listMAF = listMAF;
            lvMAF.ItemsSource = listMAF;
            claimDTO.customer = customer;
        }

        private void btnMAF_Clicked(object sender, System.EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid mafID = (Guid)btnSelected.CommandParameter;

            pcon.getListClaimantForGrid(mafID);
        }

        private void Pcon_loadClaimantGrid(object sender, (List<views.vwClaimant>, views.vwMafEnrollmentClosure) e)
        {
            var listClaimant = e.Item1;
            var maf = e.Item2;
            
            cbClaimSelectionHeader.productName = maf.productName;
            cbClaimSelectionHeader.productID = maf.productID;

            stackMAF.IsVisible = false;
            claimDTO.maf = maf;
            claimDTO.listClaimant = listClaimant;

            if (listClaimant.Count == 0)
            {
                // should not proceed! for now, lets continue without selecting (delete after modification)
                claimDTO.claimantID = "463120";
                claimDTO.claimantType = 1;
                pcon.getListClaimTypeForGrid(claimDTO.maf.productID, claimDTO.claimantType);

                // uncomment this after modifications
                //lblNoClaimant.IsVisible = true;
            }
            else if (listClaimant.Count == 1)
            {
                var claimant = listClaimant.FirstOrDefault();
                
                claimDTO.claimantID = claimant.claimantID;
                claimDTO.claimantType = claimant.claimantType;
                pcon.getListClaimTypeForGrid(claimDTO.maf.productID, claimDTO.claimantType);
            }
            else
            {
                Title = "Selection of Claimant";
                stackClaimant.IsVisible = true;
                lvClaimant.ItemsSource = listClaimant;
            }
        }

        private void btnClaimant_Clicked(object sender, EventArgs e)
        {
            Button btnSelected = (Button)sender;
            Guid claimantID = (Guid)btnSelected.CommandParameter;

            // get claimant data (not yet implemented)

            pcon.getListClaimTypeForGrid(claimDTO.maf.productID, claimDTO.claimantType);
        }

        private void Pcon_loadClaimTypeGrid(object sender, List<views.vwClaimTypes> e)
        {
            Title = "Selection of Claim Type";
            stackClaimant.IsVisible = false;
            stackHeader.IsVisible = false;
            stackClaimType.IsVisible = true;

            claimDTO.listClaimType = e;
            lvClaimtype.ItemsSource = e;
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar sbar = (SearchBar)sender;
            if (!string.IsNullOrWhiteSpace(sbar.Text))
            {
                string searchText = sbar.Text.ToUpper();
                var listFilteredCustomer = (from cust in claimDTO.listCustomer
                                           where cust.dungganonID.Contains(searchText) ||
                                                 cust.customerLastName.Contains(searchText) ||
                                                 cust.customerFirstName.Contains(searchText) ||
                                                 cust.customerMiddleName.Contains(searchText)
                                           orderby cust.customerLastName, cust.customerFirstName
                                           select cust).ToList();

                lvCustomer.ItemsSource = listFilteredCustomer;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar sbar = (SearchBar)sender;
            if (string.IsNullOrWhiteSpace(sbar.Text))
            {
                lvCustomer.ItemsSource = claimDTO.listCustomer;
            }
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // get row data
            var chk = (CheckBox)sender;
            var row = Grid.GetRow(chk);
            var grid = chk.Parent as Grid;
            var tempLbl = grid.Children.Where(child => Grid.GetRow(child) == row && Grid.GetColumn(child) == 4).FirstOrDefault();

            // get claim type id
            Label lblID = (Label)tempLbl;
            Guid id = Guid.Parse(lblID.Text);

            if (chk.IsChecked) // add claim type
            {
                var claimType = new views.vwClaimTypes();
                claimType.id = id;
                claimDTO.listSelectedClaimType.Add(claimType);
            }
            else // remove claim type
            {
                var selected = claimDTO.listSelectedClaimType.Where(ct => ct.id == id).FirstOrDefault();
                claimDTO.listSelectedClaimType.Remove(selected);
            }
        }

        private async void btnContinue_Clicked(object sender, EventArgs e)
        {
            // validation (count number of selected claim type)
            if (claimDTO.listSelectedClaimType.Count > 0)
            {
                hideStacks();
                ActivityIndicator activityIndicator = new ActivityIndicator { IsRunning = true };

                var listClaimTypeIDs = claimDTO.listClaimType.Select(ct => ct.id).ToList();
              //  await Navigation.PushAsync(new claimCreation(claimDTO));
            }
            else
            {
                displayMessage("Error", "Please select atleast one claim type!", "Close");
            } 
        }

        private void Pcon_saveClaimTypeSelected(object sender, List<views.vwClaimTypes> e)
        {
            claimDTO.listClaimType = e;
        }
    }
}