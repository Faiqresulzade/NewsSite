﻿using News.Application.Bases.Interfaces.DI;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Features.NewsModel.Command.CreateNews;
using NewsEntity = News.Domain.Entities.News;
using News.Application.DTOs.News;

namespace News.Application.Bases.Interfaces.Factories
{
    public interface INewsFactory : IDependencyInjections, IFactory<NewsEntity, NewsCreateDto>
    {

    }
}
