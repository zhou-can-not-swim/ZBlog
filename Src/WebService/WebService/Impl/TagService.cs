using EF;
using Entities;
using Service;
using Service.Impl;

namespace WebService.Impl
{
    public class TagService(BlogDbContext dbContext) : BaseService<Tag>(dbContext), ITagService
    {
    }
}
