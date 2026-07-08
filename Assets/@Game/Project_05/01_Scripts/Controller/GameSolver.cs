using Game.MineSweeper.Domain;
using VContainer;

namespace Game.MineSweeper.Controller
{
    public class GameSolver
    {
        [Inject] private Model _model;

        public void SolverBoard()
        {
            foreach (var tileData in _model.TileData.Keys)
            {
                int remainingCount = 9;

                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        var neiber = (tileData.x + x, tileData.y + y);
                        if (!_model.TileData.TryGetValue(neiber, out var tile)) continue;

                        if (tile.IsOpened)
                            remainingCount--;
                    }
                }
            }
        }
    }
}