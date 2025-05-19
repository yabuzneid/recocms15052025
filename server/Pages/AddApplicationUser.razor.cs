using System.Collections.Generic;

namespace RecoCms6.Pages
{
    public partial class AddApplicationUserComponent
    {
        string _roleCounterpartLabel;
        protected string roleCounterpartLabel
        {
            get
            {
                return _roleCounterpartLabel;
            }
            set
            {
                if (_roleCounterpartLabel != value)
                {
                    var args = new PropertyChangedEventArgs()
                    {
                        Name = nameof(roleCounterpartLabel),
                        NewValue = value,
                        OldValue = _roleCounterpartLabel
                    };
                    _roleCounterpartLabel = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getServiceProvidersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getServiceProvidersResult
        {
            get
            {
                return _getServiceProvidersResult;
            }
            set
            {
                _getServiceProvidersResult = value;
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getServiceProvidersList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getServiceProvidersList
        {
            get
            {
                return _getServiceProvidersList;
            }
            set
            {
                if (!object.Equals(_getServiceProvidersList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getServiceProvidersList", NewValue = value, OldValue = _getServiceProvidersList };
                    _getServiceProvidersList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public void ServiceProvidersChanged(List<int> args)
        {
            ServiceProviders = args;
        }


        private List<int> _serviceProviders = new();
        public List<int> ServiceProviders
        {
            get => _serviceProviders;
            set
            {
                _serviceProviders = value ?? new List<int>();
            }
        }
    }
}
