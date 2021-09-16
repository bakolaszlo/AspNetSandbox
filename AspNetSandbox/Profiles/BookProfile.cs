// <copyright file="BookProfile.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Dtos;
using AspNetSandbox.Models;
using AutoMapper;

namespace AspNetSandbox.Profiles
{
    /// <summary>
    ///   <para>Profiles for automapper.</para>
    /// </summary>
    public class BookProfile : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="BookProfile" /> class.</summary>
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, CreateBookDto>();
            CreateMap<Book, ReadBookDto>();
        }
    }
}
