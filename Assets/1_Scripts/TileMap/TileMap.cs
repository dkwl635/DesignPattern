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

    public Vector3 GetTilePos(int _x, int _y)
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

    public Tile GetTile(Vector3 _pos)
    {
        float half = m_tileMapRecord.width * 0.5f;
        MemoryPoolingItem<Tile> find = m_pool.activeList.Find(item =>
        {
            float minX = item.item.transform.position.x - half;
            float maxX = item.item.transform.position.x + half;
            float minZ = item.item.transform.position.z - half;
            float maxZ = item.item.transform.position.z + half;

            return minX <= _pos.x && _pos.x < maxX && minZ <= _pos.z && _pos.z < maxZ;
        });

        if (find == null)
            return null;

        return find.item;
    }

    public Tile GetNearTile(eTILE_TYPE _tileType, Tile curTile, Tile preTile)
    {
        List<Tile> list = new List<Tile>(); //근접 타일을 담을 
        for (int i = 0; i < 4; i++)
        {
            int sign = i >= 2 ? -1 : 1;
            int x = (1 + i) % 2 * sign;
            int y = (2+ i) % 2 * sign;
           

            Tile find = GetTile(curTile.tileRecord.x + x, curTile.tileRecord.y + y);
            if (find != null && find.titleType == _tileType && find != preTile)
            {
            
                list.Add(find);
            }
        }

        if (list.Count <= 0)
            return null;

        return list[Random.Range(0, list.Count)];


    }
}