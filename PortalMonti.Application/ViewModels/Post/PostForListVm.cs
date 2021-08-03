﻿using AutoMapper;
using PortalMonti.Application.Mapping;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Application.ViewModels.Post
{
    public class PostForListVm : IMapFrom<Domain.Model.Post>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Post, PostForListVm>();
              
        }

    }
}
