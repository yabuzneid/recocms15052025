using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("EOClaimDetails", Schema = "dbo")]
  public partial class EoClaimDetail
  {
    [Key]
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public int? ClaimInitiationID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public bool ClaimOrIncident
    {
      get;
      set;
    }
    public int? ClaimConvertedToID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public bool UrbanOrRural
    {
      get;
      set;
    }
    public DateTime? LitigationDate
    {
      get;
      set;
    }
    public DateTime? ConvertedToLitigation
    {
      get;
      set;
    }
    public int? DenialCodeID
    {
      get;
      set;
    }
    public Parameter Parameter2 { get; set; }
    public int? AppraiserID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
    public int? DutyOfCareExpertID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider1 { get; set; }
    public int? MediatorID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider2 { get; set; }
    public int? OpposingAppraiserID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider3 { get; set; }
    public int? OpposingDutyOfCareExpertID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider4 { get; set; }
    public int? CoverageReservationsValue
    {
      get;
      set;
    }
    public string InsuredLiabilityComments
    {
      get;
      set;
    }
    public string OtherPartyExposure
    {
      get;
      set;
    }
    public decimal? AmountClaimed
    {
      get;
      set;
    }
    public string RealDamages
    {
      get;
      set;
    }
    public string IndemnityPotential
    {
      get;
      set;
    }
    public string CurrentPlan
    {
      get;
      set;
    }
    public bool OtherInsurance
    {
      get;
      set;
    }
    public int? TypeOfOtherInsuranceID
    {
      get;
      set;
    }
    public Parameter Parameter3 { get; set; }
    public string OtherInsuranceCompany
    {
      get;
      set;
    }
    public string OtherInsurancePolicyNum
    {
      get;
      set;
    }
    public string OtherInsuranceContactInfo
    {
      get;
      set;
    }
    public bool Litigation
    {
      get;
      set;
    }
    public int? TypeOfActionID
    {
      get;
      set;
    }
    public Parameter Parameter4 { get; set; }
    public string Jurisdiction
    {
      get;
      set;
    }
    public string CourtFileNumber
    {
      get;
      set;
    }
    public DateTime? DateLitigationServed
    {
      get;
      set;
    }
    public string WhoIsSuing
    {
      get;
      set;
    }
    public bool MatterSetForTrial
    {
      get;
      set;
    }
    public string OffersMade
    {
      get;
      set;
    }
    public bool CostAwardsGranted
    {
      get;
      set;
    }
    public DateTime? DateOrderMade
    {
      get;
      set;
    }
    public DateTime? DateCollected
    {
      get;
      set;
    }
    public int? FileOutcomeID
    {
      get;
      set;
    }
    public int? StageSettled
    {
      get;
      set;
    }
    public int? FirstDemandFormID
    {
      get;
      set;
    }
    public Parameter Parameter5 { get; set; }
    public int? BoardJurisdictionID
    {
      get;
      set;
    }
    public Parameter Parameter6 { get; set; }
    public int? LitigationTypeID
    {
      get;
      set;
    }
    public Parameter Parameter7 { get; set; }
    public DateTime? PretrialDate
    {
      get;
      set;
    }
    public DateTime? TrialDate
    {
      get;
      set;
    }
    public int? LitigationDocumentsDeliveredID
    {
      get;
      set;
    }
    public Parameter Parameter8 { get; set; }
    public string OtherMethodOfDelivery
    {
      get;
      set;
    }
    public int? AllegationID
    {
      get;
      set;
    }
    public Parameter Parameter9 { get; set; }
    public int? DeductibleHandledID
    {
      get;
      set;
    }
    public Parameter Parameter10 { get; set; }
    public bool IncreasedDeductible
    {
      get;
      set;
    }
    public int? EndOfDealID
    {
      get;
      set;
    }
    public Parameter Parameter11 { get; set; }
    public int? TransactionValueID
    {
      get;
      set;
    }
    public Parameter Parameter12 { get; set; }
    public int? RecoveryID
    {
      get;
      set;
    }
    public Parameter Parameter13 { get; set; }
    public DateTime? ConvertedToClaimDate
    {
      get;
      set;
    }
    public decimal? Misrepresentation
    {
      get;
      set;
    }
    public decimal? Negligence
    {
      get;
      set;
    }
    public decimal? NegligentMisrep
    {
      get;
      set;
    }
    public decimal? PunitiveAmount
    {
      get;
      set;
    }
    public decimal? Fraud
    {
      get;
      set;
    }
    public decimal? OtherAmount
    {
      get;
      set;
    }
    public decimal? DeductibleAmount
    {
      get;
      set;
    }
    public bool RECOComplaint
    {
      get;
      set;
    }
    public int? RECOComplaintOutcomeID
    {
      get;
      set;
    }
    public Parameter Parameter14 { get; set; }
    public string Motions
    {
      get;
      set;
    }
    public string LitigationMiscellaneous
    {
      get;
      set;
    }
    public string OtherClaims
    {
      get;
      set;
    }
    public int? LitigationRoleID
    {
      get;
      set;
    }
    public Parameter Parameter15 { get; set; }
    public string NonLitigationOffers
    {
      get;
      set;
    }
    public string CurrentDevelopments
    {
      get;
      set;
    }
    public string Resolution
    {
      get;
      set;
    }
    public string InitialStatus
    {
      get;
      set;
    }
    public string OtherParties
    {
      get;
      set;
    }
    public string XRefFile
    {
      get;
      set;
    }
    public string Conditions
    {
      get;
      set;
    }
    public int? DidDealClose
    {
      get;
      set;
    }
    public Parameter Parameter16 { get; set; }
    public string Miscellaneous
    {
      get;
      set;
    }
    public string DeductibleDetails
    {
      get;
      set;
    }
    public bool? Denied
    {
      get;
      set;
    }
    public string DenialComments
    {
      get;
      set;
    }
    public string RECOComplaintDetails
    {
      get;
      set;
    }
    public string CostAwardsDetails
    {
      get;
      set;
    }
    public DateTime? DenialLetterDate
    {
      get;
      set;
    }
  }
}
