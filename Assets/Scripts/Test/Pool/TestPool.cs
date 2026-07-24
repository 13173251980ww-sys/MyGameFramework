using UnityEngine;

public class TestPool : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            PoolMgr.instance.GetObj("A");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PoolMgr.instance.GetObj("B");
        }
    }
}