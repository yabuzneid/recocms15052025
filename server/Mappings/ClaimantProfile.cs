using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RecoCms6.Models;
using RecoCms6.Models.RecoDb;

namespace RecoCms6.Mappings
{
    public class ClaimantProfile : Profile
    {
        public ClaimantProfile()
        {
            this.CreateMap<ClaimClaimant, ClaimantViewModel>();
            this.CreateMap<ClaimClaimant, CppClaimantViewModel>();
            this.CreateMap<ClaimClaimant, EOClaimantViewModel>();
            this.CreateMap<ClaimInsured, CppInsuredViewModel>();
            this.CreateMap<ClaimInsured, CppBrokerageViewModel>();
            this.CreateMap<ClaimOtherParty, CppOtherPartyViewModel>();
            this.CreateMap<ClaimExpert, ExpertViewModel>();
            this.CreateMap<TradeDetail, TradeViewModel>();
        }
    }
}
