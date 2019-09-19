using SHS.Domain.Core.Tags;
using SHS.Service.Interfaces;
using SHS.Service.TagService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Service.TagService
{
    public interface ITagService
    {
        Task<Result> Add(Tag  tag);
        Task<IEnumerable<Tag>> GetAll(QueryTagFilter filter);
        Task<Result> Update(Tag tag);
        Task<Tag> Get(string id);
        Task<Result> Delete(string id);
    }
}
