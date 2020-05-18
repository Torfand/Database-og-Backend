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
       private IGameRepository _gameRepository;

       public GameService(IGameRepository gameRepository)
       {
           _gameRepository = gameRepository;
       }

       public async Task<GameModel> StartGame()
       {
            var gameModel = new GameModel();
            await _gameRepository.Create(gameModel);
            return gameModel;
       }

       public async Task<GameModel> Read(Guid gameID)
       {
           return await _gameRepository.Read(gameID);
       }

       public async Task<GameModel> Play(int index, Guid gameID)
       {
           var gameModel = await _gameRepository.Read(gameID);
           var hasPlayed = gameModel.Play(index);
           await _gameRepository.Update(gameModel);
           return gameModel;
       }
   }
}
