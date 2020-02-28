using DataAccess.Interfaces;
using Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Tests
{
    [TestClass]
    public class RecipeCategoryServiceTests
    {
        private readonly IRecipeCategoryService _service;
        private readonly IRepository<RecipeCategory> _repository;

        public RecipeCategoryServiceTests()
        {
            _repository = Substitute.For<IRepository<RecipeCategory>>();
            _service = new RecipeCategoryService(_repository);
        }

        [TestMethod]
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

        [TestMethod]
        public void Add_ShouldCallRepositoryAdd()
        {
            //Arrange
            var recipeCategory = new RecipeCategory() { };

            //Act
            _service.Add(recipeCategory);

            //Assert
            _repository.Received(1).Add(recipeCategory);
        }

        [TestMethod]
        public void Update_ShouldCallRepositoryUpdate()
        {
            //Arrange
            var recipeCategory = new RecipeCategory() { };

            //Act
            _service.Update(recipeCategory);

            //Assert
            _repository.Received(1).Update(recipeCategory);
        }

        [TestMethod]
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
