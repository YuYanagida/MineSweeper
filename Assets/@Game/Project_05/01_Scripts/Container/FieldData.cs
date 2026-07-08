using MackySoft.Navigathena.SceneManagement;

public class FieldData : ISceneData
{
    public (int, int) Field { get; }
    public int BomCount {  get; }

    public FieldData((int, int) field, int bomCount)
    {
        Field = field;
        BomCount = bomCount;
    }
}
