using UnityEngine;

public class TestRes: MonoBehaviour
{
    void Start()
    {
        ResMgr.instance.LoadAsync<GameObject>("A", (obj) =>
        {
            Debug.Log(obj.name);
        });
    }
}
