using Game.MineSweeper.View;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private Vector2 _field;
    [SerializeField] private Tile _tile;
    [SerializeField] private int _bomCount;

    private Dictionary<(int x, int y), Tile> _tileDict = new();
    private List<(int x, int y)> _bomPositions = new();

    private List<(int x, int y)> _lockList = new();
    /*
    private void Start()
    {
        SetBomPosition();
        CreateField();
        SetStartPosition();
        ControllCamera();
    }

    private void ControllCamera()
    {
        var camera = Camera.main;

        while (camera.WorldToViewportPoint(_field / 2).x > 1 || camera.WorldToViewportPoint(_field / 2).y > 1)
        {
            camera.transform.position = camera.transform.position + Vector3.back;
        }        

        Debug.Log(camera.WorldToViewportPoint(_field / 2));
    }

    private void SetStartPosition()
    {
        (int x, int y) startPosition;
        do
        {
            startPosition = (Random.Range(0, (int)_field.x), Random.Range(0, (int)_field.y));
        } while (CheckAround(startPosition.x, startPosition.y) != 0);

        OpenAround(startPosition.x, startPosition.y);
    }

    private void SetBomPosition()
    {
        for (int i = 0; i < _bomCount; i++)
        {
            (int x, int y) bomPosition;
            do
            {
                bomPosition = (Random.Range(0, (int)_field.x), Random.Range(0, (int)_field.y));
            } while (_bomPositions.Contains(bomPosition));
            
            _bomPositions.Add(bomPosition);
        }
    }

    private void CreateField()
    {
        for (int x = 0; x < _field.x; x++)
        {
            for (int y = 0; y < _field.y; y++)
            {
                var position = (x, y);
                var tile = Instantiate(_tile, new Vector2(position.x - _field.x / 2 + .5f, position.y - _field.y / 2 + .5f), Quaternion.identity);
                _tileDict.Add((x, y), tile);
                tile.Init(ClickEvent, (position));
                tile.SetBom(_bomPositions.Contains(position));
                tile.BomCount(CheckAround(x, y));
                _lockList.Add(position);
            }
        }
    }

    private void ClickEvent(ClickType clickType, (int x, int y) position)
    {
        if (clickType == ClickType.None) return;

        if (clickType == ClickType.Left)
        {
            TileOpen(position);

            if (_bomPositions.Contains(position))
                Debug.Log("BOM!!");
            else
            {
                OpenAround(position.x, position.y);
            }
                
        }

        else if (clickType == ClickType.Right)
        {
            _tileDict[position].SetFlag();
        }
    }

    private void TileOpen((int, int)position)
    {
        if (!_tileDict.TryGetValue(position, out var tile)) return;

        _lockList.Remove(position);
        tile.ClickTile();
    }

    private void OpenAround(int x, int y)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                
                if (_bomPositions.Contains((x + i, y + j))) continue;

                if (!_lockList.Contains((x + i, y + j))) continue;
                TileOpen((x + i, y + j));
                
                var bomCount = CheckAround(x + i, y + j);
                if (bomCount > 0) continue;

                //‚à‚¤ˆê“x‰ñ‚·
                OpenAround(x + i, y + j);
            }
        }
    }

    private int CheckAround(int x, int y)
    {
        int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (_bomPositions.Contains((x + i, y + j)))
                    count++;
            }
        }

        return count;
    }
    */
}
