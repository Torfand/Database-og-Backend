using System;
using Moq;
using NumberPuzzleWeb.Core.ApplicationServices;
using NumberPuzzleWeb.Core.Domain_Model;
using NumberPuzzleWeb.Core.DomainServices;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NumberPuzzleWeb.UnitTest
{
    class GameServiceTest
    {
        [Test]
        public async Task TestStartGame()
        {
            var mock = new Mock<IGameModelRepository>();
            var mockSetup = mock.Setup(repo => repo.Create(It.IsAny<GameModel>()))
                .Returns(Task.FromResult(true));
            var gameService = new GameService(mock.Object);
            var gameModel = await gameService.StartGame();
            Assert.IsNotNull(gameModel);
            Assert.AreEqual(0, gameModel.PlayCount);
            mock.Verify(repo => repo.Create(gameModel));


        }

        [Test]
        public async Task TestGameStartsOnlyOnce()
        {
            var mock = new Mock<IGameModelRepository>();
            var mockSetup = mock.Setup(repo => repo.Create(It.IsAny<GameModel>()))
                .Returns(Task.FromResult(true));
            var gameService = new GameService(mock.Object);
            var gameModel = await gameService.StartGame();
            Assert.IsNotNull(gameModel);
            Assert.AreEqual(0, gameModel.PlayCount);
            mock.Verify(repo => repo.Create(gameModel), Times.Once);
            mock.VerifyNoOtherCalls();
        }
    
        [Test]
        public async Task TestRead()
        {
            var gameID = new Guid("82ad76d0-d796-4bb5-bddc-1318dcd8cb68");
            var gameModel = new GameModel(gameID, 7, new[] { 1, 3, 2, 4, 5, 6, 7, 8, 0 });
            var mock = new Mock<IGameModelRepository>();
            var mockSetup = mock.Setup(repo => repo.Read(gameID))
                                                        .Returns(Task.FromResult(gameModel));
            var gameService = new GameService(mock.Object);
            var gameModel2FE= await gameService.Read(gameID);
            Assert.AreEqual(gameModel,gameModel2FE );
            Assert.IsNotNull(gameModel);
        
            mock.Verify(repo => repo.Read(gameID), Times.Once);
            mock.VerifyNoOtherCalls();


        }
        [Test]
        public async Task testPlay()
        {
            var gameID = new Guid("82ad76d0-d796-4bb5-bddc-1318dcd8cb68");
            var gameModel = new GameModel(gameID, 7, new[] { 1, 3, 2, 4, 5, 6, 7, 8, 0 });
            var mock = new Mock<IGameModelRepository>();
            var mockSetup = mock.Setup(repo => repo.Read(gameID))
                .Returns(Task.FromResult(gameModel));
            var gameService = new GameService(mock.Object);
            await gameService.Play(7, gameID);

            Assert.AreEqual('8', gameModel[8]);
           
            mock.Verify(repo => repo.Read(gameID), Times.Once);
            mock.Verify(repo => repo.Update(gameModel), Times.Once);
            mock.VerifyNoOtherCalls();


        }
    }
}
