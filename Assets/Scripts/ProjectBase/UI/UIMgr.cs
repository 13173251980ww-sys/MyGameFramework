using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum E_UI_Layer
{
    Top,
    Mid,
    Bot
}

public class UIMgr : BaseMgr<UIMgr>
{
    private Dictionary<string,BasePanel> _dicPanel = new Dictionary<string,BasePanel>();
    private GameObject _canvas;
    private GameObject _eventSystem;
    
    public UIMgr()
    {
        _canvas = ResMgr.instance.Load<GameObject>("UI/Canvas");
        _canvas.name = "Canvas";
        _eventSystem = ResMgr.instance.Load<GameObject>("UI/EventSystem");
        _eventSystem.name = "EventSystem";
    }
    
    public void ShowPanel<T>(string panelName,E_UI_Layer layer = E_UI_Layer.Top) where T : BasePanel
    {
        if (_dicPanel.ContainsKey(panelName))
        {
            _dicPanel[panelName].ShowMe();
            _dicPanel[panelName].transform.SetParent(_canvas.transform.Find(layer.ToString()));
        }
        else
        {
            ResMgr.instance.LoadAsync<GameObject>($"UI/{panelName}", (obj) =>
            {
                obj.transform.SetParent(_canvas.transform.Find(layer.ToString()));
                obj.transform.localPosition = Vector3.zero; 
                obj.transform.localScale = Vector3.one;
                (obj.transform as RectTransform).offsetMax = Vector2.zero;
                (obj.transform as RectTransform).offsetMin = Vector2.zero;
                obj.name = panelName;
                
                T panel =obj.GetComponent<T>();
                _dicPanel.Add(panelName,panel);
                panel.ShowMe();
            });
        }
    }

    public void HidePanel<T>(string panelName,bool isRemove=false) where T : BasePanel
    {
        if (!_dicPanel.ContainsKey(panelName))
        {
            return;
        }
        
        _dicPanel[panelName].HideMe();
        
        if (isRemove)
        {
            GameObject.Destroy(_dicPanel[panelName].gameObject);
            _dicPanel.Remove(panelName);
        }
    }
    
    public void AddCustomEventListener(UIBehaviour control, EventTriggerType type, UnityAction<BaseEventData> callBack)
    {
        EventTrigger trigger = control.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = control.gameObject.AddComponent<EventTrigger>();
        
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(callBack);
        
        trigger.triggers.Add(entry);
    }

    public void Clear()
    {
        _dicPanel.Clear();
        _dicPanel = null;
        _canvas = null;
        _eventSystem = null;
    }
}
