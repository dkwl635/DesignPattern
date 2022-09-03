using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    MemoryPooling<Tile> m_pool;
    TileMapRecord m_tileMapRecord;

    private void Awake()
    {
        m_pool = new MemoryPooling<Tile>(transform, 100);
    }
    public void Clear()
    {
        m_pool.Clear();
    }

    public void Load(TileMapRecord _record)
    {
        m_pool.Clear();
        m_tileMapRecord = _record;
        for (int i = 0; i < m_tileMapRecord.tileList.Count; i++)
        {
            TileRecord _tileRecord = m_tileMapRecord.tileList[i];
            Tile _tile = m_pool.Get(m_tileMapRecord.path);
            _tile.Open(_tileRecord, m_tileMapRecord.width);
        }

        transform.position = new Vector3(-m_tileMapRecord.width * m_tileMapRecord.x * 0.5f, 0.0f, -m_tileMapRecord.width * m_tileMapRecord.y * 0.5f);

    }

    public Tile GetTile(int _x, int _y)
    {
        MemoryPoolingItem<Tile> _find = m_pool.activeList.Find(item => item.item.tileRecord.x == _x && item.item.tileRecord.y == _y);
        if (_find == null)
            return null;

        return _find.item;
    }

    public Vector3 GetTilePos(int _x ,int _y)
    {
        Tile _find = GetTile(_x, _y);
        if (_find == null)
            return Vector3.zero;

        return _find.transform.position;
    }

    public Tile GetTile(eTILE_TYPE _tileType)
    {
        List<MemoryPoolingItem<Tile>> _find = m_pool.activeList.FindAll(item => item.item.tileRecord.tileType == _tileType);
        if (_find == null)
            return null;
        if (_find.Count <= 0)
            return null;

        return _find[Random.Range(0, _find.Count)].item;
    }

    public Vector3 GetTilePos(eTILE_TYPE _tileType)
    {
        Tile _find = GetTile(_tileType);
        if (_find == null)
            return Vector3.zero;

        return _find.transform.position;
    }

}
