using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace nwtf_mobile_bl.customBind
{
    public class cbClaimSelectionHeader:INotifyPropertyChanged
    {
        public string customerID { get; set; }
        public string customerName { get; set; }
        public string productID {
            get => productID;
            set
            {
                productID = value;
                onProductIDChanged(nameof(productID));
            }
        }

        public string productname
        {
            get => productname;
            set
            {
                productname = value;
                onProductIDChanged(nameof(productname));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void onProductIDChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
