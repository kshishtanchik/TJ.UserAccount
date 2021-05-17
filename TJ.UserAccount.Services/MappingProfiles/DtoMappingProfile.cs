using AutoMapper;
using TJ.UserAccount.Contracts;

namespace TJ.UserAccount.Services.MappingProfiles
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<AccountStatus, Dto.AccountStatus>(MemberList.Destination).ReverseMap();
            CreateMap<Bid, Dto.Bid>(MemberList.Destination).ReverseMap();
            CreateMap<TransferBid, Dto.TransferBid>(MemberList.Destination).ReverseMap();

            CreateMap<Dto.AccountStatus, Dao.Models.AccountStatus>(MemberList.Destination).ReverseMap();
            CreateMap<Dto.Bid, Dao.Models.Bid>(MemberList.Destination).ReverseMap();
            CreateMap<Dto.TransferBid, Dao.Models.TransferBid>(MemberList.Destination).ReverseMap();
        }
    }
}
