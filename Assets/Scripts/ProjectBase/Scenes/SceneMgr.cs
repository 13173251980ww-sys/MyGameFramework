using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : BaseMgr<SceneMgr>
{
    /// <summary>
    /// 同步加载场景
    /// </summary>
    /// <param name="name"></param>
    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="name"></param>
    public void LoadAsync(string name,UnityAction callback =null)
    {
        MonoMgr.instance.StartCoroutine(ReallyLoadSAsync(name,callback));
    }

    IEnumerator ReallyLoadSAsync(string name,UnityAction callback =null)
    {
        AsyncOperation ao= SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            EventMgr.instance.EventTrigger("进度条更新", ao.progress);
            yield return ao;
        }
        
        callback?.Invoke();
    }
}