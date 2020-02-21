using System;
using System.Collections.Generic;
using DataAccess.Interfaces;
using Entities.Models;
using NSubstitute;
using Services.Interfaces;
using Xunit;

namespace Services.Tests
{
    public class RecipeCategoryServiceTests
    {
        private readonly IRecipeCategoryService _service;
        private readonly IRepository<RecipeCategory> _repository;

        public RecipeCategoryServiceTests()
        {
            _repository = Substitute.For<IRepository<RecipeCategory>>();
            _service = new RecipeCategoryService(_repository);
        }

        [Fact]
        public void DeleteByRecipe_ShouldCallRepositoryDelete()
        {
            //Arrange
            const int recipeId = 1;
            var list = new List<RecipeCategory>()
            {
                new RecipeCategory() { },
                new RecipeCategory() { },
            };

            _repository.Filter(null).ReturnsForAnyArgs(list);
            //Act
            _service.DeleteByRecipe(recipeId);

            //Assert
            _repository.Received(2).Remove(Arg.Any<RecipeCategory>());
        }

        [Fact]
        public void Add_ShouldCallRepositoryAdd()
        {
            //Arrange
            var recipeCategory = new RecipeCategory() { };

            //Act
            _service.Add(recipeCategory);

            //Assert
            _repository.Received(1).Add(recipeCategory);
        }

        [Fact]
        public void Update_ShouldCallRepositoryUpdate()
        {
            //Arrange
            var recipeCategory = new RecipeCategory() { };
            
            //Act
            _service.Update(recipeCategory);

            //Assert
            _repository.Received(1).Update(recipeCategory);
        }
        [Fact]
        public void Delete_ShouldCallRepositoryRemove()
        {
            //Arrange
            var recipeCategory = new RecipeCategory() { };
            _repository.GetById(1).Returns(recipeCategory);

            //Act
            _service.Delete(1);

            //Assert
            _repository.Received(1).Remove(recipeCategory);
        }
    }
}
