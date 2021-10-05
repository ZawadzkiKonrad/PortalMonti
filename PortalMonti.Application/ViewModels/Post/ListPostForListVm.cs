using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Application.ViewModels.Post
{
    public class ListPostForListVm
    {
        public List<PostForListVm> Posts { get; set; }
        public int Id { get; set; }
        public int? CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string PostImage { get; set; }
        public int Count { get; set; }
    }
}
