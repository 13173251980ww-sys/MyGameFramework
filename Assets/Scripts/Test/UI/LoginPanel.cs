using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Test.UI
{
    public class LoginPanel : BasePanel
    {
        protected override void Start()
        {
            Image image1 = GetControl<Image>("image1");
            UIMgr.instance.AddCustomEventListener(image1,EventTriggerType.Drag, (a) =>
            {
                Debug.Log("图片被拖动："+a);
            });
        }

        protected override void OnClick(string objName)
        {
            switch (objName)
            {
                case "Button1":
                    Debug.Log("点击了按钮一");
                    break;
                case "Button2":
                    Debug.Log("点击了按钮二");
                    break;
            }
        }

        protected override void OnValueChanged(string objName, bool value)
        {
            switch (objName)
            {
                case "Toggle1":
                    Debug.Log("Toggle1的值改变为" + value);
                    break;
                case "Toggle2":
                    Debug.Log("Toggle2的值" + value);
                    break;
            }
        }
    }
}