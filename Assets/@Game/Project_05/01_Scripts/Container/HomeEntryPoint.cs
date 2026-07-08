using Cysharp.Threading.Tasks;
using MackySoft.Navigathena.SceneManagement;
using System.Threading;
using UnityEngine;

namespace Game.MineSweeper.Home
{
    public class HomeEntryPoint : SceneEntryPointBase
    {
        [SerializeField] private Home _home;

        protected override UniTask OnExit(ISceneDataWriter writer, CancellationToken cancellationToken)
        {
            writer.Write(new FieldData(_home.Field, _home.BomCount));

            return base.OnExit(writer, cancellationToken);
        }
    }
}