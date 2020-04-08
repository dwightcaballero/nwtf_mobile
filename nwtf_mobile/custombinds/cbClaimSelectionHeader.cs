using System.ComponentModel;

namespace nwtf_mobile.custombinds
{
    class cbClaimSelectionHeader : INotifyPropertyChanged
    {
        public string _customerID { get; set; }
        public string customerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                if (_customerID != value)
                {
                    _customerID = value;
                    OnPropertyChanged("customerID");
                }
            }
        }

        public string _customerName { get; set; }
        public string customerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    OnPropertyChanged("customerName");
                }
            }
        }

        public string _productID { get; set; }
        public string productID
        {
            get
            {
                return _productID;
            }
            set
            {
                if (_productID != value)
                {
                    _productID = value;
                    OnPropertyChanged("productID");
                }
            }
        }

        public string _productName { get; set; }
        public string productName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged("productName");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
