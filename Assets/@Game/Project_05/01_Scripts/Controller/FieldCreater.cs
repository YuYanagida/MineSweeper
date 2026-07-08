using Game.MineSweeper.Domain;
using Game.MineSweeper.Presenter;
using Game.MineSweeper.View;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Game.MineSweeper.Controller
{
    public class FieldCreater
    {
        [Inject] private Model _model;
        [Inject] private ClickEventer _clickEventer;
        [Inject] private Tile _tile;

        public void SetField()
        {
            SetBomPosition();
            CreateField();
        }

        private void SetBomPosition()
        {
            for (int i = 0; i < _model.BomCount; i++)
            {
                (int x, int y) bomPosition;
                do
                {
                    bomPosition = (Random.Range(0, _model.Field.x), Random.Range(0, _model.Field.y));
                } while (_model.BomPositions.Contains(bomPosition));

                _model.AddBom(bomPosition);
            }
        }

        private void CreateField()
        {
            for (int x = 0; x < _model.Field.x; x++)
            {
                for (int y = 0; y < _model.Field.y; y++)
                {
                    var position = (x, y);
                    var tile = Object.Instantiate(_tile, new Vector2(position.x - _model.Field.x / 2 + .5f, position.y - _model.Field.y / 2 + .5f), Quaternion.identity);
                    TileStatus tileStatus = new(tile, _clickEventer.ClickEvent);
                    _model.RegisterTile((x, y), tileStatus);
                }
            }
        }
    }
}