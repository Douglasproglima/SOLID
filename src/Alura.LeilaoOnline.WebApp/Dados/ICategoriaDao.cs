﻿using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> GetCategories();
        Categoria GetCategoryId(int id);
    }
}
