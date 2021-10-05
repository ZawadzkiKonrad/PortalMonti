using AutoMapper;
using FluentValidation;
using PortalMonti.Application.Mapping;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Application.ViewModels.Post
{
    public class NewPostVm:IMapFrom<Domain.Model.Post>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string PostImage { get; set; }

        public DateTime Date { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPostVm, Domain.Model.Post>().ReverseMap();

        }

    }
    public class NewPostValidation : AbstractValidator<NewPostVm>
    {
        public NewPostValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Text).MaximumLength(255);   
            RuleFor(x => x.Name).MaximumLength(50);   
        }
        
    }
}
