using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NumberPuzzleWeb.Core.Domain_Model;
using NumberPuzzleWeb.Core.DomainServices;

namespace NumberPuzzleWeb.Core.ApplicationServices
{
   public class GameService
   {
       private IGameModelRepository _gameModelRepository;

       public GameService(IGameModelRepository gameModelRepository)
       {
           _gameModelRepository = gameModelRepository;
       }

       public async Task<GameModel> StartGame()
       {
            var gameModel = new GameModel();
            await _gameModelRepository.Create(gameModel);
            return gameModel;
       }

       public async Task<GameModel> Read(Guid gameID)
       {
           return await _gameModelRepository.Read(gameID);
       }

       public async Task<GameModel> Play(int index, Guid gameID)
       {
           var gameModel = await _gameModelRepository.Read(gameID);
           var hasPlayed = gameModel.Play(index);
           await _gameModelRepository.Update(gameModel);
           return gameModel;
       }
   }
}
