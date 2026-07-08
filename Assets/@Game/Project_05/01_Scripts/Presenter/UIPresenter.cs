using Game.MineSweeper.Domain;
using VContainer;
using R3;
using ObservableCollections;
using Game.MineSweeper.View;
using Game.MineSweeper.Controller;

namespace Game.MineSweeper.Presenter
{
    public class UIPresenter
    {
        [Inject] DisplayUI _displayUI;
        [Inject] Model _model;
        [Inject] GameController _gameController;

        public void SubScribe()
        {
            _model.FlagCounter.Subscribe(count =>
            {
                _displayUI.CountFlag(count);
            });

            _model.LockPosition.ObserveCountChanged().Subscribe(count =>
            {
                _displayUI.CountBlock(count - _model.BomCount);

                if (count == _model.BomCount)
                    //ƒQ[ƒ€ƒNƒŠƒA
                    _gameController.Clear();
            });

            _displayUI.RetryEvent.Subscribe(_ =>
            {
                _gameController.Retry();
                _displayUI.DisplayGameOver(false);
            });

            _displayUI.RestartEvent.Subscribe(_ =>
            {
                _gameController.Restart();
            });

            _displayUI.HomeButton.Subscribe(_ =>
            {
                _gameController.Home();
            });

            _gameController.ClearCommand.Subscribe(_ =>
            {
                _displayUI.DisplayClear(true);
            });

            _gameController.GameoverCommand.Subscribe(_ =>
            {
                _displayUI.DisplayGameOver(true);
            });
        }
    }
}