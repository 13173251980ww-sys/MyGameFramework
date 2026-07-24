using UnityEngine;

public class TestInput : MonoBehaviour
{
    void Start()
    {
        InputMgr.instance.Start();
        EventMgr.instance.AddListener("某键抬起", (key) =>
        {
            switch (key)
            {
                case KeyCode.W:
                    Debug.Log("向前走");
                    break;
                case KeyCode.A:
                    Debug.Log("向左走");
                    break;
                case KeyCode.S:
                    Debug.Log("向下走");
                    break;
                case KeyCode.D:
                    Debug.Log("向右走");
                    break;
            }
        });
    }
}