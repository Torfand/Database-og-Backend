using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberPuzzleWeb.API.ViewModel;
using NumberPuzzleWeb.Core.ApplicationServices;
using NumberPuzzleWeb.Core.Domain_Model;

namespace NumberPuzzleWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private GameService _gameService;
        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public async Task<GameViewModel> StartGame()
        {
            var game = await _gameService.StartGame();
              return ViewFromDomainModel(game);
        }


        [HttpGet("{gameID})")]
        public async Task<GameViewModel> Read(string gameID)
        {
            var game = await _gameService.Read(new Guid(gameID));
            return   ViewFromDomainModel(game);
        }
        [HttpPost]
        public async Task<GameViewModel> Play(PlayViewModel play)
        {
            var game = await _gameService.Play(play.Index, new Guid(play.GameID));
            return ViewFromDomainModel(game);
        }
        private static GameViewModel ViewFromDomainModel(GameModel game)
        {
            return new GameViewModel(game.Id.ToString(), game.PlayCount,game.IsSolved, game.Numbers );
        }
    }
}