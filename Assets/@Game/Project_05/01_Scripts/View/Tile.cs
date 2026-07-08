using R3;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.MineSweeper.View
{
    public class Tile : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TextMeshPro _bomCountText;
        [SerializeField] private SpriteRenderer _tileRenderer;
        [SerializeField] private SpriteRenderer _bomRenderer;
        [SerializeField] private SpriteRenderer _BlockRenderer;
        [SerializeField] private SpriteRenderer _flagRenderer;

        private Subject<PointerEventData> _clickEvent = new();

        public Observable<PointerEventData> ClickEvent => _clickEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            _clickEvent.OnNext(eventData);
        }

        public void BomCount(int Count)
        {
            _bomCountText.text = Count == 0 ? "" : Count.ToString();
        }

        public void SetBom(bool isBom)
        {
            _bomRenderer.enabled = isBom;
        }

        public void SwitchTile(bool isOpen)
        {
            _BlockRenderer.enabled = !isOpen;
        }

        public void SetFlag(bool isFlag)
        {
            _flagRenderer.enabled = isFlag;
        }
    }
}