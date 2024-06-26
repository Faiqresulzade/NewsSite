﻿using NewsEntity = News.Domain.Entities.News;


namespace News.Application.Features.NewsModel.Queries.GetNewsById
{
    public record GetNewsByIdQueryResponse
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReadCount { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public static implicit operator GetNewsByIdQueryResponse(NewsEntity entity)
        {
            return new()
            {
                AuthorName = entity.AuthorName,
                Title = entity.Title,
                Description = entity.Description,
                ReadCount = entity.ReadCount,
                ImagePath = entity.ImagePath,
                CategoryId = entity.CategoryId,
                CategoryName = entity.Category.Name
            };
        }
    }
}
