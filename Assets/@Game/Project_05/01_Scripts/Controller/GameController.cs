using Game.MineSweeper.Domain;
using MackySoft.Navigathena.SceneManagement;
using R3;
using UnityEngine.SceneManagement;
using VContainer;

namespace Game.MineSweeper.Controller
{
    public class GameController
    {
        [Inject] Model _model;

        private ReactiveCommand<Unit> _clearCommand = new();
        private ReactiveCommand<Unit> _gameOverCommand = new();

        public Observable<Unit> ClearCommand => _clearCommand;
        public Observable<Unit> GameoverCommand => _gameOverCommand;

        public void Clear()
        {
            _clearCommand.Execute(Unit.Default);
        }

        public void GameOver()
        {
            _gameOverCommand.Execute(Unit.Default);
        }

        public void Retry()
        {
            _model.PopOpenPosition();
        }

        public void Restart()
        {
            GlobalSceneNavigator.Instance.Reload();
        }

        public void Home()
        {
            GlobalSceneNavigator.Instance.Pop();
        }
    }
}