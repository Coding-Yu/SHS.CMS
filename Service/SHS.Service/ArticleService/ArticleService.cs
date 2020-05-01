using Microsoft.Extensions.Logging;
using SHS.Domain.Core.Articles;
using SHS.Domain.Repository.Interfaces;
using SHS.Service.ArticleService.Dto;
using SHS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHS.Service.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly ILogger<ArticleService> _logger;
        public ArticleService(
            IRepository<Article> articleRepository,
            ILogger<ArticleService> logger)
        {
            _articleRepository = articleRepository;
            _logger = logger;
        }
        public async Task<Result> Add(Article article)
        {
            try
            {
                if (article != null)
                {
                    await _articleRepository.AddByAsync(article);
                    return Result.Success(200);
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("文章添加异常" + ex.ToString());
                return Result.Fail(500);
            }
        }

        public async Task<Result> Delete(string id,string userId)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id)&&!string.IsNullOrWhiteSpace(userId))
                {
                    var article = await _articleRepository.GetByAsync(id);
                    if (article != null)
                    {
                        article.DeleteDate = DateTime.Now;
                        article.IsDel = 1;
                        article.DeleteUserId =Guid.Parse(userId);
                        await _articleRepository.RemoveByAsync(article);
                        return Result.Success(200);
                    }
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("文章删除异常" + ex.ToString());
                return Result.Fail(500);
            }
        }

        public async Task<Article> Get(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    return await _articleRepository.GetByAsync(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("文章获取异常" + ex.ToString());
                return null;
            }
        }

        public async Task<PagedResultDto<Article>> GetAll(QueryArticleFilter filter)
        {
            var result = new PagedResultDto<Article>();
            try
            {
                var query = await _articleRepository.GetAllByAsync();
                query = query.Where(x => x.IsDel == 0);
                if (!string.IsNullOrWhiteSpace(filter.title))
                {
                    query = query.Where(x => x.Title.Contains(filter.title));
                }
                result.Items = query.OrderByDescending(x => x.CreateDate).Skip(filter.limit * (filter.page - 1)).Take(filter.limit).ToList();
                result.TotalCount = query.Count();
            }
            catch (Exception ex)
            {
                _logger.LogError("文章获取异常" + ex.ToString());
            }
            return result;
        }

        public async Task<Result> Update(Article article)
        {
            try
            {
                if (article != null)
                {
                    article.UpdateDate = DateTime.Now;
                    await _articleRepository.UpdateByAsync(article);
                    return Result.Success();
                }
                return Result.Fail(500);
            }
            catch (Exception ex)
            {
                _logger.LogError("文章更新异常" + ex.ToString());
                return Result.Fail(500, ex.ToString());
            }
        }
    }
}
