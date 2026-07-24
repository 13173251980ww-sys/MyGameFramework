using System.Collections.Generic;
using UnityEngine.Events;

public class EventMgr : BaseMgr<EventMgr>
{
    private Dictionary<string,UnityAction<object>> _dicEvent = new Dictionary<string,UnityAction<object>>();

    /// <summary>
    /// 增加监听
    /// </summary>
    /// <param name="name"></param>
    /// <param name="listener"></param>
    public void AddListener(string name, UnityAction<object> listener)
    {
        if(_dicEvent.ContainsKey(name))
        {
            _dicEvent[name]+=listener;
        }
        else
        {
            _dicEvent.Add(name,listener);
        }
    }

    /// <summary>
    /// 移除监听
    /// </summary>
    /// <param name="name"></param>
    public void RemoveListener(string name, UnityAction<object> listener)
    {
        if (_dicEvent.ContainsKey(name))
        {
            _dicEvent[name]-=listener;
        }
    }

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name,object info)
    {
        if (_dicEvent.ContainsKey(name))
        {
            _dicEvent[name]?.Invoke(info);
        }
    }

    void Clear()
    {
        _dicEvent.Clear();
    }
}