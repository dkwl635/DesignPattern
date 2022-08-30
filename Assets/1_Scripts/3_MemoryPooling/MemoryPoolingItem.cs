using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPoolingItem<T> where T :MonoBase 
{
    public int resKey;
    public T item;

    public MemoryPoolingItem(int _resKey, T _item)
    {
        resKey = _resKey;
        item = _item;
    }
}
