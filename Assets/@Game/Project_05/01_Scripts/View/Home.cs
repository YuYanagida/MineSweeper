using MackySoft.Navigathena.SceneManagement;
using R3;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MineSweeper.Home
{
    public class Home : MonoBehaviour
    {
        [SerializeField] List<int> _fieldWidths;
        [SerializeField] List<int> _fieldHights;
        [SerializeField] List<int> _bomCounts;
        [SerializeField] List<Button> _startButtons;
        [SerializeField] private Button _easyButton;
        [SerializeField] private Button _normalButton;
        [SerializeField] private Button _hardButton;
        [SerializeField] private Button _customButton;
        [SerializeField] private CustamMode _custamMode;

        private (int, int) _field;
        private int _bomCount;
        private readonly ISceneIdentifier _sceneName = new BuiltInSceneIdentifier("Project05");

        public (int, int) Field => _field;
        public int BomCount => _bomCount;

        private void Awake()
        {
            for (int i = 0; i < _startButtons.Count; i++)
            {
                int j = i;

                _startButtons[j].OnClickAsObservable().SubscribeAwait(async (_, ct) =>
                {
                    _field = (_fieldWidths[j], _fieldHights[j]);
                    _bomCount = _bomCounts[j];

                    await GlobalSceneNavigator.Instance.Push(_sceneName, data: new FieldData(_field, _bomCount));

                }, AwaitOperation.Drop).AddTo(this);
            }

            _customButton.OnClickAsObservable().SubscribeAwait(async (_, ct) =>
            {
                if (!_custamMode.IsInput())
                    return;

                _field = _custamMode.Field;
                _bomCount = _custamMode.BomCount;

                await GlobalSceneNavigator.Instance.Push(_sceneName, data: new FieldData(_field, _bomCount));

            }, AwaitOperation.Drop).AddTo(this);
        }
    }
}