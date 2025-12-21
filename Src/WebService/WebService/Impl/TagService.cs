using EF;
using Entities;
using Service;
using Service.Impl;

namespace WebService.Impl
{
    public class TagService : BaseService<Tag>, ITagService
    {
        public TagService(BlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
