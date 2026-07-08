using Game.MineSweeper.Domain;
using VContainer;

namespace Game.MineSweeper.Controller
{
    public class FlagController
    {
        [Inject] Model _model;

        public void SetFlag((int, int) position)
        {
            var setFilag = _model.TileData[position].SwitchFlag();
            
            _model.FlagCount += setFilag ? -1 : +1;
        }
    }
}