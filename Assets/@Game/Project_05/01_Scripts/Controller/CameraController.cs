using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Game.MineSweeper.Controller
{
    public class CameraController
    {
        private bool _isBreak = false;
        private CancellationTokenSource _source = new();
        private readonly float BORD_RANGE = 0.9f;

        /// <summary> ”Õ‚ªŽw’è”ÍˆÍ‚Ì’†‚ÉŽû‚Ü‚é‚æ‚¤‚É‚·‚é </summary>
        public void ControllCamera((int x, int y) field)
        {
            var camera = Camera.main;
            var boardEdge = camera.WorldToViewportPoint(new Vector2(field.x, field.y) / 2);

            _source = new();
            WaitTile(_source.Token).Forget();
            while (boardEdge.x > BORD_RANGE || boardEdge.y > BORD_RANGE)
            {
                camera.transform.position = camera.transform.position + Vector3.back;
                boardEdge = camera.WorldToViewportPoint(new Vector2(field.x, field.y) / 2);

                if (_isBreak)
                {
                    Debug.Log("ƒLƒƒƒ“ƒZƒ‹‚³‚ê‚Ü‚µ‚½");
                    break;
                }
            }
            _source.Cancel();
        }

        private async UniTask WaitTile(CancellationToken token)
        {
            await UniTask.WaitForSeconds(3, ignoreTimeScale: true, cancellationToken: token);
            _isBreak = true;
        }
    }
}