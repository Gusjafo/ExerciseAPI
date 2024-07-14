using Aplication.Services;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetExercises_ReturnsNull_WhenRepositoryReturnsEmptyList()
        {
            // Arrange
            var mockRepo = new Mock<IExerciseRepository>();
            mockRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(new List<Exercise>());
            var service = new ExerciseService(mockRepo.Object);

            // Act
            var result = await service.GetExercises(1);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task GetExercises_ReturnsNull_WhenRepositoryReturnsNull()
        {
            // Arrange
            var mockRepo = new Mock<IExerciseRepository>();
            mockRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync((IEnumerable<Exercise>?)null);
            var service = new ExerciseService(mockRepo.Object);

            // Act
            var result = await service.GetExercises(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetExercises_ReturnsExerciseFullDTOs_WhenRepositoryReturnsExercises()
        {
            // Arrange
            var exercises = new List<Exercise>
            {
                new Exercise { Id = 1, Name = "Squat" },
                new Exercise { Id = 2, Name = "Deadlift" }
            };

            var mockRepo = new Mock<IExerciseRepository>();
            mockRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync(exercises);
            var service = new ExerciseService(mockRepo.Object);

            // Act
            var result = await service.GetExercises(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, dto => dto.Name == "Squat");
            Assert.Contains(result, dto => dto.Name == "Deadlift");
        }

    }
}