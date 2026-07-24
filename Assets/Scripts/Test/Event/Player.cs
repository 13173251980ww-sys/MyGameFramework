
using UnityEngine;

public class Player :MonoBehaviour
{
    void Start()
    {
        EventMgr.instance.AddListener("MonsterDead",GetExp);
    }

    void GetExp(object info)
    {
        Debug.Log("击败了"+ info.ToString()+"获得了经验");
    }
}
