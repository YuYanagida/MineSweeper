using Game.MineSweeper.Domain;
using VContainer;
using VContainer.Unity;
using UnityEngine;
using Game.MineSweeper.Presenter;
using Game.MineSweeper.View;
using Game.MineSweeper.Controller;
using MackySoft.Navigathena.SceneManagement.VContainer;

namespace Game.MineSweeper.Container
{
    public class MineSweeperLifetimeScope : LifetimeScope
    {
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private Vector2 _field;
        [SerializeField] private int _bomCount;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<DisplayUI>();

            builder.Register<FieldCreater>(Lifetime.Singleton).WithParameter(_tilePrefab);

            builder.Register<Model>(Lifetime.Singleton);
            builder.Register<TileOpener>(Lifetime.Singleton);
            builder.Register<FlagController>(Lifetime.Singleton);            
            builder.Register<ClickEventer>(Lifetime.Singleton);
            builder.Register<CameraController>(Lifetime.Singleton);
            builder.Register<UIPresenter>(Lifetime.Singleton);
            builder.Register<GameController>(Lifetime.Singleton);

            builder.RegisterSceneLifecycle<MineSweeperSceneEntryPoint>().WithParameter(((int)_field.x, (int)_field.y)).WithParameter(_bomCount);
        }
    }
}