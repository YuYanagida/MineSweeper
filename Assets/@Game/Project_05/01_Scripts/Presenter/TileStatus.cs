using Game.MineSweeper.Common;
using Game.MineSweeper.View;
using R3;
using System;
using UnityEngine.EventSystems;

namespace Game.MineSweeper.Presenter
{
    public class TileStatus
    {
        private Tile _tile;
        private (int, int) _position;
        private bool _isOpened;        
        private bool _isBom;
        private bool _isFlaged;
        private int _aroundBomCount;
        private readonly Action<ClickkType, (int x, int y)> ClickEvent;

        public bool IsOpened => _isOpened;
        public bool IsBom => _isBom;
        public bool IsFlaged => _isFlaged;
        public int AroundBomCount => _aroundBomCount;

        public TileStatus(Tile tile, Action<ClickkType, (int x, int y)> clickEvent)
        {
            _tile = tile;
            ClickEvent = clickEvent;
            ManagementInputAction();
        }

        /// <summary> マスへの入力を制御する </summary>
        private void ManagementInputAction()
        {
            _tile.ClickEvent.Subscribe(eventData =>
            {
                //既に開かれているマスには何もしない
                if (_isOpened) return;

                var clickType = eventData.button switch
                {
                    PointerEventData.InputButton.Left => ClickkType.Left,
                    PointerEventData.InputButton.Right => ClickkType.Right,
                    _ => ClickkType.None
                };

                //旗を建てているマスには左クリックのアクションを起こさない
                if(clickType == ClickkType.Left && IsFlaged) return;

                ClickEvent?.Invoke(clickType, _position);
            });
        }

        public void SetPosition((int, int) position)
        {
            _position = position;
        }

        public void SetBom(bool isBom)
        {
            _isBom = isBom;
            _tile.SetBom(_isBom);
        }

        public void SwitchTile(bool isOpen)
        {
            _isOpened = isOpen;
            _tile.SwitchTile(isOpen);

            //マスが開かれた時に旗が立っていたなら回収する
            if (isOpen && _isFlaged)
                SwitchFlag();
        }

        public bool SwitchFlag()
        {
            _isFlaged = !_isFlaged;
            _tile.SetFlag(_isFlaged);

            return _isFlaged;
        }

        public void SetAroundBomCount(int BomCount)
        {
            _aroundBomCount = BomCount;
            _tile.BomCount(_aroundBomCount);
        }
    }
}