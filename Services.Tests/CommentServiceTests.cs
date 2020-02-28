using DataAccess.Interfaces;
using Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Tests
{
    [TestClass]
    public class CommentServiceTests
    {
        private readonly ICommentService _service;
        private readonly IRepository<Comment> _repository;
               
        public CommentServiceTests()
        {
            _repository = Substitute.For<IRepository<Comment>>();
            _service = new CommentService(_repository);
        }

        [TestMethod]
        public void DeleteByRecipe_ShouldCallRepositoryDelete()
        {
            //Arrange
            const int recipeId = 1;
            var commentList = new List<Comment>()
            {
                new Comment() { },
                new Comment() { },
            };

            _repository.Filter(null).ReturnsForAnyArgs(commentList);
            //Act
            _service.DeleteByRecipe(recipeId);

            //Assert
            _repository.Received(2).Remove(Arg.Any<Comment>());
        }
    }
}
