using AutoMapper;
using RecoCms6.Models.RecoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Mappings
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            this.CreateMap<NoticeOfClaimFile, File>()
                .ForMember(dest => dest.StoredDocument, opt => opt.MapFrom(src => src.StoredFile));
            this.CreateMap<GetFileById, File>();
        }
    }
}
