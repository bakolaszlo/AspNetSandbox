// <copyright file="BookProfile.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using AspNetSandbox.Dtos;
using AspNetSandbox.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, CreateBookDto>();
            CreateMap<Book, ReadBookDto>();            
        }
    }
}
