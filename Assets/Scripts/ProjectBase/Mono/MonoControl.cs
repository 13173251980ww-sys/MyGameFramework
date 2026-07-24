using UnityEngine;
using UnityEngine.Events;

public class MonoControl : MonoBehaviour
{
    private event UnityAction UpdateEvent;
    
    private void Update()
    {
        UpdateEvent?.Invoke();
    }
    
    public void AddEventListener(UnityAction listener)
    {
        UpdateEvent += listener;
    }

    public void RemoveEventListener(UnityAction listener)
    {
        UpdateEvent -= listener;
    }

    public void Clear()
    {
        UpdateEvent = null;
    }
}
