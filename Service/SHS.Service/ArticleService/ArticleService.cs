using AutoMapper;
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

        public async Task<Result> Delete(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var article = await _articleRepository.GetByAsync(id);
                    if (article != null)
                    {
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

        public async Task<IEnumerable<Article>> GetAll(QueryArticleFilter filter)
        {
            var result = new List<Article>();
            try
            {
                var query = await _articleRepository.GetAllByAsync();
                if (!string.IsNullOrWhiteSpace(filter.title))
                {
                    query = query.Where(x => x.Title.Contains(filter.title));
                }
                result = query.OrderByDescending(x => x.CreateDate).Skip(filter.PageSize * (filter.PageNum - 1)).Take(filter.PageSize).ToList();
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
