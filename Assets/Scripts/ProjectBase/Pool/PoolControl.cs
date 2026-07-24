using UnityEngine;

public class PoolControl : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("PushDelay",1);
    }

    void PushDelay()
    {
        PoolMgr.instance.PushObj(this.gameObject.name,this.gameObject);
    }
}
