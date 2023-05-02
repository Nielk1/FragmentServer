using AutoMapper;
using Fragment.NetSlum.Core.Models;
using Fragment.NetSlum.Persistence.Entities;

namespace Fragment.NetSlum.Server.Mappings;

public class CharacterInfoProfile : Profile
{
    public CharacterInfoProfile()
    {
        CreateMap<CharacterInfo, Character>()
            .ForMember(x => x.SaveSlotId, y => y.MapFrom(z => z.SaveSlot))
            .ForMember(x => x.CharacterName, y => y.MapFrom(z => z.CharacterName))
            .ForMember(x => x.Class, y => y.MapFrom(z => z.Class))
            .ForMember(x => x.CurrentLevel, y => y.MapFrom(z => z.Level))
            .ForMember(x => x.GreetingMessage, y => y.MapFrom(z => z.Greeting))
            .ForMember(x => x.FullModelId, y => y.MapFrom(z => z.ModelId))
            .AfterMap((src, dst, context) => dst.CharacterStats = context.Mapper.Map<CharacterInfo, CharacterStats>(src))
            .AfterMap((src, dst, context) => dst.PlayerAccount = context.Mapper.Map<CharacterInfo, PlayerAccount>(src))
        ;

        CreateMap<CharacterInfo, CharacterStats>()
            .ForMember(x => x.CurrentHp, y => y.MapFrom(z => z.SaveSlot))
            .ForMember(x => x.CurrentSp, y => y.MapFrom(z => z.SaveSlot))
            .ForMember(x => x.CurrentGp, y => y.MapFrom(z => z.SaveSlot))
            .ForMember(x => x.OnlineTreasures, y => y.MapFrom(z => z.OnlineStatueCounter))
            .ForMember(x => x.AverageFieldLevel, y => y.MapFrom(z => z.OfflineStatueCounter))
        ;

        CreateMap<CharacterInfo, PlayerAccount>()
            .ForMember(x => x.SaveId, y => y.MapFrom(z => z.SaveId))
        ;
    }
}
