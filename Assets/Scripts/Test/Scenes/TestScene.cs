
using UnityEngine;

public class TestScene : MonoBehaviour
{
    void Start()
    {
        EventMgr.instance.AddListener("进度条更新", (obj) =>
        {
            Debug.Log("进度条更新中，进度为:" + obj);
        });
        
        SceneMgr.instance.LoadAsync("Scene2", () =>
        {
            Debug.Log("异步加载，切换到场景2");
        });
    }
}