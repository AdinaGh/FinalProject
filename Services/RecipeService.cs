﻿using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RecipeService : Service<Recipe>, IRecipeService
    {
        public RecipeService(IRepository<Recipe> repository) : base(repository)
        {
        }
    }
}
