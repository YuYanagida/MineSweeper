using Cysharp.Threading.Tasks;
using Game.MineSweeper.Controller;
using Game.MineSweeper.Domain;
using Game.MineSweeper.Presenter;
using MackySoft.Navigathena.SceneManagement;
using MackySoft.Navigathena.SceneManagement.VContainer;
using System.Threading;
using VContainer;

public class MineSweeperSceneEntryPoint : SceneLifecycleBase
{
    [Inject] Model _model;
    [Inject] TileOpener _tileOpener;
    [Inject] FieldCreater _fieldCreater;
    [Inject] CameraController _cameraController;
    [Inject] UIPresenter _uiPresenter;
    [Inject] private (int, int) _field;
    [Inject] private int _bomCount;

    protected override UniTask OnEnter(ISceneDataReader reader, CancellationToken cancellationToken)
    {
        if (reader.TryRead(out FieldData fieldData))
        {
            _model.InitBoard(fieldData.Field, fieldData.BomCount);
            _fieldCreater.SetField();
            _cameraController.ControllCamera(_model.Field);
            _uiPresenter.SubScribe();
            _tileOpener.SetStartPosition();
        }

        return UniTask.CompletedTask;
    }

#if UNITY_EDITOR

    protected override UniTask OnEditorFirstPreInitialize(ISceneDataWriter writer, CancellationToken cancellationToken)
    {
        // ISceneDataWriterÇ…èâä˙ÉfÅ[É^ÇèëÇ´çûÇﬁ
        writer.Write(new FieldData(_field, _bomCount));
        return UniTask.CompletedTask;
    }
#endif
}
