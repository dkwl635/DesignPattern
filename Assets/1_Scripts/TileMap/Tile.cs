using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBase
{
    public TileRecord tileRecord;
    public MeshRenderer render;
    public eTILE_TYPE titleType;

    public virtual void Open(TileRecord _tileRecord, float _width)
    {
        base.Open();
        tileRecord = _tileRecord;
        SetTileType(tileRecord.tileType);
        transform.localPosition = new Vector3(_tileRecord.x * _width, 0.0f, _tileRecord.y * _width);
    }

    public virtual void SetTileType(eTILE_TYPE _type)
    {
        titleType = _type;
        string _matPath = null;
        switch(titleType)
        {
            case eTILE_TYPE.NONE:
                _matPath = "Map/matNone";
                break;
            case eTILE_TYPE.MOVEABLE:
                _matPath = "Map/matMoveable";
                break;
            case eTILE_TYPE.START:
                _matPath = "Map/matStart";
                break;
            case eTILE_TYPE.TARGET:
                _matPath = "Map/matTarget";
                break;
            case eTILE_TYPE.SPAWN:
                _matPath = "Map/matSpawn";
                break;
            default:

                break;
        }

        render.material = KUtil.ResUtil.Load<Material>(_matPath);
    }

}
