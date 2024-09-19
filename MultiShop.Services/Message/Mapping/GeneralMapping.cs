using AutoMapper;
using Message.DAL.Entities;
using Message.Dtos;

namespace Message.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
        CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
        CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
        CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
    }
}
