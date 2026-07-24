
using Test.UI;
using UnityEngine;

public class TestUI : MonoBehaviour
{ 
    private void Start()
    {
        UIMgr.instance.ShowPanel<LoginPanel>("LoginPanel",E_UI_Layer.Bot);
        Invoke("Hide",2f);
        
    }

    public void Hide()
    {
        UIMgr.instance.HidePanel<LoginPanel>("LoginPanel");
    }
}