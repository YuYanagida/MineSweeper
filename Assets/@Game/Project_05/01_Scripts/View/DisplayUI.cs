using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MineSweeper.View
{
    public class DisplayUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _flagCountText;
        [SerializeField] private TextMeshProUGUI _blockCountText;
        [SerializeField] private Canvas _resultCanvas;
        [SerializeField] private RectTransform _gameoverUIs;
        [SerializeField] private RectTransform _clearUIs;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;

        public Observable<Unit> RetryEvent => _retryButton.OnClickAsObservable();
        public Observable<Unit> RestartEvent => _restartButton.OnClickAsObservable();
        public Observable<Unit> HomeButton => _homeButton.OnClickAsObservable();

        public void CountFlag(int count)
        {
            _flagCountText.text = $"Å~ {count}";
        }

        public void CountBlock(int count)
        {
            _blockCountText.text = $"Å~ {count}";
        }

        public void DisplayGameOver(bool enable)
        {
            _resultCanvas.enabled = enable;
            _gameoverUIs.gameObject.SetActive(enable);
        }

        public void DisplayClear(bool enable)
        {
            _resultCanvas.enabled = enable;
            _clearUIs.gameObject.SetActive(enable);
        }
    }
}