using DataAccess.Interfaces;
using Entities.Models;
using NSubstitute;
using Services.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace Services.Tests
{
    public class CommentServiceTests
    {
        private readonly ICommentService _service;
        private readonly IRepository<Comment> _repository;

        public CommentServiceTests()
        {
            _repository = Substitute.For<IRepository<Comment>>();
            _service = new CommentService(_repository);
        }

        [Fact]
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
