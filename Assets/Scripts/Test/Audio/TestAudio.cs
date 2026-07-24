using UnityEngine;

public class TestAudio : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "PlayBK"))
            AudioMgr.instance.PlayBK("魔王魂_Luna");
        if (GUI.Button(new Rect(0, 100, 100, 100), "StopBK"))
            AudioMgr.instance.StopBK();
        if (GUI.Button(new Rect(0,200,100,100),"PauseBK"))
            AudioMgr.instance.PauseBK();
        
        AudioMgr.instance.ChangeBKVolume(GUI.HorizontalSlider(new Rect(0, 300, 100, 100), AudioMgr.instance.BKVolume, 0f, 1f));
        
        
        if (GUI.Button(new Rect(100,0,100,100), "PlaySFX"))
            AudioMgr.instance.PlaySFX("消息弹出");
        
        AudioMgr.instance.ChangeSfxVolume(GUI.HorizontalSlider(new Rect(100, 100, 100, 100), AudioMgr.instance.SFXVolume, 0f, 1f));
    }
}