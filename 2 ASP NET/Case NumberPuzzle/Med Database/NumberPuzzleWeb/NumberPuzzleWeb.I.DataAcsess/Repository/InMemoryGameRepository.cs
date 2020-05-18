using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NumberPuzzleWeb.Core.Domain_Model;
using NumberPuzzleWeb.Core.DomainServices;

namespace NumberPuzzleWeb.I.DataAcsess.Repository
{
    public class InMemoryGameRepository : IGameRepository
    {
        private Dictionary<Guid, GameModel> _gameModels;
        public InMemoryGameRepository()
        {
            _gameModels = new Dictionary<Guid, GameModel>();
        }

        public Task<bool> Create(GameModel gameModel)
        {
            _gameModels.Add(gameModel.Id, gameModel);
            return Task.FromResult(true);
        }

        public Task<GameModel> Read(Guid id)
        {
            return Task.FromResult(_gameModels[id]);
        }

        public Task<bool> Update(GameModel gameModel)
        {
            _gameModels[gameModel.Id] = gameModel;
            return Task.FromResult(true);

        }
    }
}
