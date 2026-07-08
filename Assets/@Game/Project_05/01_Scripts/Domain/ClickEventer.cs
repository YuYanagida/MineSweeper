using Game.MineSweeper.Common;
using Game.MineSweeper.Controller;
using VContainer;

namespace Game.MineSweeper.Domain
{
    public class ClickEventer
    {
        [Inject] private TileOpener _tileOpener;
        [Inject] private FlagController _flagController;
        [Inject] private GameController _gameController;

        public void ClickEvent(ClickkType clickType, (int x, int y) position)
        {
            if (clickType == ClickkType.None) return;

            if (clickType == ClickkType.Left)
            {
                var isSafe = _tileOpener.ClickTile(position);
                if (!isSafe)
                    _gameController.GameOver();
            }

            else if (clickType == ClickkType.Right)
            {
                _flagController.SetFlag(position);
            }
        }
    }
}