
using System.Collections;
using UnityEngine;

public class TestMono_01
{
    public TestMono_01()
    {
        MonoMgr.instance.AddEventListener(MyUpdate);
        MonoMgr.instance.StartCoroutine(coroutine());
    }

    void MyUpdate()
    {
        Debug.Log("MyUpdate");
    }

    IEnumerator coroutine()
    {
        Debug.Log("Coroutine");
        yield return 0;
    }
}
