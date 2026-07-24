using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ResMgr : BaseMgr<ResMgr>
{
    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public T Load<T>(string name)  where T : Object
    {
        T res = Resources.Load<T>(name);
        if (res is GameObject)
        {
            return GameObject.Instantiate(res);
        }

        return res;
    }

    
    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void LoadAsync<T>(string name ,UnityAction<T> callback =null) where T : Object
    {
        MonoMgr.instance.StartCoroutine(ReallyLoadAsync<T>(name,callback));
    }

    IEnumerator ReallyLoadAsync<T>(string name,UnityAction<T> callback =null) where T : Object
    {
        ResourceRequest r=Resources.LoadAsync(name);
        yield return r;

        if (r.asset is GameObject)
        {
            callback?.Invoke(GameObject.Instantiate(r.asset) as T);
        }
        else
        {
            callback?.Invoke(r.asset as T);
        }
    }
}