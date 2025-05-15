using System;
using System.Collections.Generic;
using System.Linq;
using Radzen;

namespace RecoCms6;

public class GlobalsService
{
    public GlobalsService(RecoDbService recoDb)
    {
        var recoDbGetGeneralSettingsResult = recoDb.GetGeneralSettings(new Query { Filter = "i => i.Active == @0", FilterParameters = new object[] { true } });
        generalsettings = recoDbGetGeneralSettingsResult.FirstOrDefault() ??
                          new Models.RecoDb.GeneralSetting();
    }

    public event Action<PropertyChangedEventArgs> PropertyChanged;


    int _selectedProgramID;
    public int selectedProgramID
    {
        get
        {
            return _selectedProgramID;
        }
        set
        {
            if(!object.Equals(_selectedProgramID, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "selectedProgramID", NewValue = value, OldValue = _selectedProgramID, IsGlobal = true };
                _selectedProgramID = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    private RecoCms6.Models.RecoDb.GeneralSetting _generalsettings = new();
    public RecoCms6.Models.RecoDb.GeneralSetting generalsettings
    {
        get
        {
            return _generalsettings;
        }
        set
        {
            if(!object.Equals(_generalsettings, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "generalsettings", NewValue = value, OldValue = _generalsettings, IsGlobal = true };
                _generalsettings = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    int _defaultProvinceID;
    public int defaultProvinceID
    {
        get
        {
            return _defaultProvinceID;
        }
        set
        {
            if(!object.Equals(_defaultProvinceID, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "defaultProvinceID", NewValue = value, OldValue = _defaultProvinceID, IsGlobal = true };
                _defaultProvinceID = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    int _defaultCountryID;
    public int defaultCountryID
    {
        get
        {
            return _defaultCountryID;
        }
        set
        {
            if(!object.Equals(_defaultCountryID, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "defaultCountryID", NewValue = value, OldValue = _defaultCountryID, IsGlobal = true };
                _defaultCountryID = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    RecoCms6.Models.RecoDb.ClaimList _gblCurrentClaim;
    public RecoCms6.Models.RecoDb.ClaimList gblCurrentClaim
    {
        get
        {
            return _gblCurrentClaim;
        }
        set
        {
            if(!object.Equals(_gblCurrentClaim, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "gblCurrentClaim", NewValue = value, OldValue = _gblCurrentClaim, IsGlobal = true };
                _gblCurrentClaim = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    string _Uri;
    public string Uri
    {
        get
        {
            return _Uri;
        }
        set
        {
            if(!object.Equals(_Uri, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "Uri", NewValue = value, OldValue = _Uri, IsGlobal = true };
                _Uri = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    RecoCms6.Models.RecoDb.UserDetail _userdetails;
    public RecoCms6.Models.RecoDb.UserDetail userdetails
    {
        get
        {
            return _userdetails;
        }
        set
        {
            if(!object.Equals(_userdetails, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "userdetails", NewValue = value, OldValue = _userdetails, IsGlobal = true };
                _userdetails = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    dynamic _claimantsolicitortitle;
    public dynamic claimantsolicitortitle
    {
        get
        {
            return _claimantsolicitortitle;
        }
        set
        {
            if(!object.Equals(_claimantsolicitortitle, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "claimantsolicitortitle", NewValue = value, OldValue = _claimantsolicitortitle, IsGlobal = true };
                _claimantsolicitortitle = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    string _txtSearch;
    public string txtSearch
    {
        get
        {
            return _txtSearch;
        }
        set
        {
            if(!object.Equals(_txtSearch, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "txtSearch", NewValue = value, OldValue = _txtSearch, IsGlobal = true };
                _txtSearch = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }

    IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference> _ServiceProviderClaims;
    public IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference> ServiceProviderClaims
    {
        get
        {
            return _ServiceProviderClaims;
        }
        set
        {
            if(!object.Equals(_ServiceProviderClaims, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "ServiceProviderClaims", NewValue = value, OldValue = _ServiceProviderClaims, IsGlobal = true };
                _ServiceProviderClaims = value;
                PropertyChanged?.Invoke(args);
            }
        }
    }
}

public class PropertyChangedEventArgs
{
    public string Name { get; set; }
    public object NewValue { get; set; }
    public object OldValue { get; set; }
    public bool IsGlobal { get; set; }
}