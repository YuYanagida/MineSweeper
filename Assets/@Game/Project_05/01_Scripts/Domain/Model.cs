using Game.MineSweeper.Presenter;
using ObservableCollections;
using R3;
using System.Collections.Generic;
using System;

namespace Game.MineSweeper.Domain
{
    public class Model
    {
        private (int, int) _field;
        private int _bomCount;
        private ReactiveProperty<int> _flagCount = new();        
        private ObservableList<(int, int)> _lockPositions = new();
        private Stack<(int, int)> _openPositions = new();
        private List<(int, int)> _bomPositions = new();
        private Dictionary<(int x, int y), TileStatus> _tileDict = new();

        public (int x, int y) Field => _field;
        public int BomCount => _bomCount;
        public int FlagCount { get { return _flagCount.Value; } set { _flagCount.Value = Math.Max(0, value); } }
        public Observable<int> FlagCounter => _flagCount;
        public IReadOnlyCollection<(int, int)> BomPositions => _bomPositions;
        public IReadOnlyObservableList<(int, int)> LockPosition => _lockPositions;
        public IReadOnlyDictionary<(int x, int y), TileStatus> TileData => _tileDict;
        
        public void InitBoard((int, int) field, int bomCount)
        {
            _field = field;
            _bomCount = bomCount;
            _flagCount.Value = bomCount;
        }
        
        public void AddBom((int, int) position) => _bomPositions.Add(position);

        public void PushOpenPosition((int, int) position)
        {
            _lockPositions.Remove(position);
            _openPositions.Push(position);
        }

        public void PopOpenPosition() 
        { 
            var popPosition = _openPositions.Pop(); 
            _lockPositions.Add(popPosition);
            _tileDict[popPosition].SwitchTile(false);
        }

        public void RegisterTile((int x, int y) position, TileStatus tile)
        {
            _tileDict.TryAdd(position, tile);
            tile.SetPosition(position);
            tile.SetBom(_bomPositions.Contains(position));
            tile.SetAroundBomCount(CheckAroundBomCount(position.x, position.y));
            _lockPositions.Add(position);

        }

        private int CheckAroundBomCount(int x, int y)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (_bomPositions.Contains((x + i, y + j)))
                        count++;
                }
            }

            return count;
        }
    }
}

