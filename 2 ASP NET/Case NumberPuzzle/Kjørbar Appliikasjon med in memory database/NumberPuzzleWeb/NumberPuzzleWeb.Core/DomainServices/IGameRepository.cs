using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using NumberPuzzleWeb.Core.Domain_Model;

namespace NumberPuzzleWeb.Core.DomainServices
{
   public interface IGameRepository
   {
       Task<bool> Create(GameModel gameModel);
       Task<GameModel> Read(Guid id);
       Task<bool> Update(GameModel gameModel);


   }
}
