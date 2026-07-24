using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MonoMgr : BaseMgr<MonoMgr>
{
    private MonoControl _monoControl;

    public MonoMgr()
    {
        if (_monoControl ==null)
        {
            GameObject obj = new GameObject("Mono");
            GameObject.DontDestroyOnLoad(obj);
            _monoControl=obj.AddComponent<MonoControl>();
        }
    }

    public void AddEventListener(UnityAction listener)
    {
        _monoControl.AddEventListener(listener);
    }

    public void RemoveEventListener(UnityAction listener)
    {
        _monoControl.RemoveEventListener(listener);
    }

    public void StartCoroutine(IEnumerator coroutine)
    {
        _monoControl.StartCoroutine(coroutine);
    }
}