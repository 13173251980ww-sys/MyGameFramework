using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
    private bool isShow = false;
    protected Dictionary<string,List<UIBehaviour>> _dicUIComponent = new Dictionary<string, List<UIBehaviour>>();
    private CanvasGroup _canvasGroup;
    public  float fadeSpeed = 3f;

    protected virtual void Awake()
    {
        FindUIComponent<Button>();
        FindUIComponent<Image>();
        FindUIComponent<Text>();
        FindUIComponent<Toggle>();
        FindUIComponent<Slider>();
        FindUIComponent<ScrollRect>();
        FindUIComponent<InputField>();
    }
    
    protected virtual void Start()
    {
        _canvasGroup =GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
        {
            _canvasGroup =   gameObject.AddComponent<CanvasGroup>();
        }
        
        MonoMgr.instance.AddEventListener(MyUpdate);
        
    }
    
    public virtual void ShowMe()
    {
        isShow = true;
    }

    public virtual void HideMe()
    {
        isShow = false;
    }

    protected virtual void OnClick(string objName)
    {
        
    }

    protected virtual void OnValueChanged(string objName, bool value)
    {
        
    }

    protected virtual void MyUpdate()
    {
        if (isShow && _canvasGroup.alpha != 1)
        {
            _canvasGroup.alpha =Mathf.MoveTowards(_canvasGroup.alpha, 1, fadeSpeed*Time.deltaTime);
        }
        else if (!isShow && _canvasGroup.alpha != 0)
        {
            _canvasGroup.alpha =Mathf.MoveTowards(_canvasGroup.alpha , 0, fadeSpeed*Time.deltaTime);
        }
    }

    protected T GetControl<T>(string controlName) where T : UIBehaviour
    {
        if(_dicUIComponent.ContainsKey(controlName))
        {
            for( int i = 0; i <_dicUIComponent[controlName].Count; ++i )
            {
                if (_dicUIComponent[controlName][i] is T)
                    return _dicUIComponent[controlName][i] as T;
            }
        }

        return null;
    }

    private void FindUIComponent<T>() where T:UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>();
        foreach (var control in controls)
        {
            string objName =control.gameObject.name;
            if (_dicUIComponent.ContainsKey(objName))
                _dicUIComponent[objName].Add(control);
            else
                _dicUIComponent.Add(objName,new List<UIBehaviour>{control});
            
            //如果是按钮
            if (control is Button)
            {
                (control as Button).onClick.AddListener(() =>
                {
                    OnClick(objName);
                });
            }
            //如果是单选框或多选框
            else if (control is Toggle)
            {
                (control as Toggle).onValueChanged.AddListener((value) =>
                {
                    OnValueChanged(objName,value);
                });
            }
        }

        Debug.Log(_dicUIComponent.Count);
    }
}