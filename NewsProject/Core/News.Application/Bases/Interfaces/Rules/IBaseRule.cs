﻿using News.Application.Bases.Interfaces.DI;

namespace News.Application.Bases.Interfaces.Rules
{
    public interface IBaseRule<Tentity>
    {
        Tentity EntityNotFound(Tentity? category);
    }
}
