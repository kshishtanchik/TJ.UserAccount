using AutoMapper;
using TJ.UserAccount.Contracts;

namespace TJ.UserAccount.Services.MappingProfiles
{
    public class DaoMappingProfile : Profile
    {
        public DaoMappingProfile()
        {
            CreateMap<AccountStatus, Dao.Models.AccountStatus>(MemberList.Destination).ReverseMap();
            CreateMap<Bid, Dao.Models.Bid>(MemberList.Destination).ReverseMap();
            CreateMap<TransferBid, Dao.Models.TransferBid>(MemberList.Destination).ReverseMap();
        }
    }
}
