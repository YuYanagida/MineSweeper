using Game.MineSweeper.Domain;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Game.MineSweeper.Controller
{
    public class TileOpener
    {
        [Inject] Model _model;

        public void SetStartPosition()
        {
            (int x, int y) startPosition;
            do
            {
                startPosition = (Random.Range(0, _model.Field.x), Random.Range(0, _model.Field.y));
            } while (_model.TileData[startPosition].AroundBomCount != 0);

            OpenAround(startPosition.x, startPosition.y);
        }

        public bool ClickTile((int x, int y) position)
        {
            TileOpen(position);

            //”š’e‚È‚ç‚·‚®‚É•Ô‚·
            if (_model.BomPositions.Contains(position))
                return false;

            OpenAround(position.x, position.y);
            return true;            
        }

        public void CloseTile((int, int) position)
        {
            _model.TileData[position].SwitchTile(false);
        }

        private void TileOpen((int, int) position)
        {
            if (!_model.TileData.TryGetValue(position, out var tile)) return;

            _model.PushOpenPosition(position);
            _model.TileData[position].SwitchTile(true);
        }                

        private void OpenAround(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {

                    if (_model.BomPositions.Contains((x + i, y + j))) continue;

                    if (!_model.LockPosition.Contains((x + i, y + j))) continue;
                    TileOpen((x + i, y + j));

                    var bomCount = _model.TileData[(x + i, y + j)].AroundBomCount;
                    if (bomCount > 0) continue;

                    //‚à‚¤ˆê“x‰ñ‚·
                    OpenAround(x + i, y + j);
                }
            }
        }
    }
}