using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UsApplication.Models;

namespace UsApplication.DTOs.Profiles
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            //source ---> Target

            CreateMap<ReceiveUserDTO, User>();
            CreateMap<User, ReturnUserDTO>();

            CreateMap<ReceiveMessageDTO, Message>();
            CreateMap<Message, ReturnMessageDTO>();

            CreateMap<Connection, ReturnConnectionDTO>();
            CreateMap<ReceieveConnectionDTO, Connection>();
        }
    }
}
