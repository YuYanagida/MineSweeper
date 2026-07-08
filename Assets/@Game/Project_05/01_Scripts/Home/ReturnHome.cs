using Cysharp.Threading.Tasks;
using MackySoft.Navigathena.SceneManagement;
using R3;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MineSweeper.Home
{
    public class ReturnHome : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;

        private ISceneIdentifier _homeScene = new BuiltInSceneIdentifier("Home");

        private void Start()
        {
            _homeButton.OnClickAsObservable().SubscribeAwait(async (_, ct) =>
            {
                await Home();

            }, AwaitOperation.Drop).AddTo(this);
        }

        public async UniTask Home()
        {
            await GlobalSceneNavigator.Instance.Push(_homeScene);
        }
    }
}