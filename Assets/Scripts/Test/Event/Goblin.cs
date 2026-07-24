
using UnityEngine;

public class Goblin : MonoBehaviour
{
    void Start()
    {
        Invoke("MonsterDead",2f);
    }

    void MonsterDead()
    {
        EventMgr.instance.EventTrigger("MonsterDead",this);
    }
}
