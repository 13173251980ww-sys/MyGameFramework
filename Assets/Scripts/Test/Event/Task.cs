
using UnityEngine;

public class Task : MonoBehaviour
{
    private void Start()
    {
        EventMgr.instance.AddListener("MonsterDead",FinishTask);
    }
    
    void FinishTask(object info)
    {
        Debug.Log("击败了"+ info.ToString()+"完成了任务");
    }
}
