using UnityEngine;

public class InputMgr : BaseMgr<InputMgr>
{ 
    private bool _isStart = false;

    public void Start()
    {
        _isStart = true;
    }

    public void Stop()
    {
        _isStart = false;
    }
    
    public InputMgr()
    {
        MonoMgr.instance.AddEventListener(MyUpdate);
    }

    void MyUpdate()
    {
        if (!_isStart)
            return;
        
        CheckInput(KeyCode.W);
        CheckInput(KeyCode.A);
        CheckInput(KeyCode.S);
        CheckInput(KeyCode.D);
    }

    public void CheckInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
            EventMgr.instance.EventTrigger("某键按下",key);
        
        if (Input.GetKeyUp(key))
            EventMgr.instance.EventTrigger("某键抬起",key);
    }
}