using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioMgr: BaseMgr<AudioMgr>
{
    private AudioSource _bkAudioSource;
    private List<AudioSource> _sfxAudioSources = new List<AudioSource>();
    private GameObject _sfxObj;

    private float _bkVolume=0.7f;
    private float _sfxVolume=0.7f;
    
    public float BKVolume => _bkVolume;
    public float SFXVolume => _sfxVolume;
    
    public AudioMgr()
    {
        GameObject bkObj = new GameObject("BK");
        GameObject.DontDestroyOnLoad(bkObj);
        _bkAudioSource=bkObj.AddComponent<AudioSource>();
        
        _sfxObj = new GameObject("SFX");
        GameObject.DontDestroyOnLoad(_sfxObj);
        
        MonoMgr.instance.AddEventListener(MyUpdate);
    }

    public void PlayBK(string clipName)
    {
        ResMgr.instance.LoadAsync<AudioClip>("BK/"+clipName, (clip) =>
        {
            _bkAudioSource.clip = clip;
            _bkAudioSource.loop = true;
            _bkAudioSource.Play();
        });
    }

    public void PauseBK()
    {
        if (_bkAudioSource && _bkAudioSource.isPlaying)
        {
            _bkAudioSource.Pause();
        }
    }

    public void StopBK(UnityAction callback =null)
    {
        if(_bkAudioSource && _bkAudioSource.isPlaying)
        {
            _bkAudioSource.Stop();
            callback?.Invoke();
        }
    }

    public void ChangeBKVolume(float volume)
    {
        _bkVolume = volume;
        _bkAudioSource.volume = _bkVolume;
    }

    public void PlaySFX(string clipName)
    {
        ResMgr.instance.LoadAsync<AudioClip>("SFX/"+clipName, (clip) =>
        {
            AudioSource _sfxAudioSource = _sfxObj.AddComponent<AudioSource>();
            _sfxAudioSource.clip = clip;
            _sfxAudioSource.Play();
            _sfxAudioSources.Add(_sfxAudioSource);
        });
    }

    public void ChangeSfxVolume(float volume)
    {
        foreach (var _sfxAudioSource in _sfxAudioSources)
        {
            _sfxVolume = volume;
            _sfxAudioSource.volume = _sfxVolume;
        }
    }

    void MyUpdate()
    {
        foreach (var _sfxAudioSource in _sfxAudioSources)
        {
            if (!_sfxAudioSource.isPlaying)
            {
                GameObject.Destroy(_sfxAudioSource);
                _sfxAudioSources.Remove(_sfxAudioSource);
                break;
            }
        }
    }

    void Clear()
    {
        _sfxAudioSources.Clear();
        _bkAudioSource.clip = null;
    }
}