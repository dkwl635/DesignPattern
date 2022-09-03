using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eTILE_TYPE
{
    NONE = 0,
    MOVEABLE = 1,
    START = 2,
    TARGET = 3,
    SPAWN = 4
}

[System.Serializable]
public class TileRecord
{
    public eTILE_TYPE tileType;
    public int x, y;
}

[System.Serializable]
public class TileMapRecord : Record
{
    public int x, y;
    public float width;
    public string path;
    public List<TileRecord> tileList = new List<TileRecord>();

}

public class TileMapTable : Table<TileMapRecord>
{
  static public TileMapTable Instance { get { return TableManager.Instance.GetTable<TileMapTable>(); } }

    public override void LoadFile(string _path)
    {
        base.LoadFile(_path);
        //烙矫 鸥老 积己 内靛
        TileMapRecord _record = new TileMapRecord();
        _record.index = 1;
        _record.x = 20;
        _record.y = 10;
        _record.width = 1.0f;
        _record.path = "Map/TileMap_1";

        for (int x = 0; x < _record.x; x++)
        {
            for (int y = 0; y < _record.y; y++)
            {
                TileRecord _tileRecord = new TileRecord();
                _tileRecord.x = x;
                _tileRecord.y = y;

                if (_tileRecord.x == 0 && _tileRecord.y == 5)
                {
                    _tileRecord.tileType = eTILE_TYPE.TARGET;
                }
                else if (_tileRecord.x == 19 && _tileRecord.y == 5)
                {
                    _tileRecord.tileType = eTILE_TYPE.START;
                }
                else if (_tileRecord.y == 5)
                {
                    _tileRecord.tileType = eTILE_TYPE.MOVEABLE;
                }
                else if (_tileRecord.y == 7 || _tileRecord.y == 3)
                {
                    _tileRecord.tileType = eTILE_TYPE.SPAWN;
                }
                else
                    _tileRecord.tileType = eTILE_TYPE.NONE;

                _record.tileList.Add(_tileRecord);

            }       
        }
        list.Add(_record);
    }//public override void LoadFile(string _path)



}
