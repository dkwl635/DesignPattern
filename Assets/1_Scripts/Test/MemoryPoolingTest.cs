using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPoolingTest : MonoBehaviour
{
    MemoryPooling<MemoryPoolingTestItem> m_pooling;
    MemoryPoolingTestItem m_lastItem;

    private void Start()
    {
        m_pooling = new MemoryPooling<MemoryPoolingTestItem>(transform, 5);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            m_lastItem = m_pooling.Get("memoryPoolingTestItem");
            //m_lastItem = m_pooling.Get("memoryPoolingTestItem", item => item.AddComponent<MemoryPoolingTestItem>());
            m_lastItem.Open();
        }

        m_pooling.UpdateLogic();
    }
}
