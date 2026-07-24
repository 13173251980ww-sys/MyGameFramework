using System.Collections.Generic;
using UnityEngine;

public class PoolData
{
    internal GameObject FatherObj;
    internal List<GameObject> ObjList;

    internal PoolData(string name,GameObject poolObj,GameObject obj)
    {
        if(FatherObj == null && ObjList ==null)
        {
            FatherObj = new GameObject(name);
            FatherObj.transform.SetParent(poolObj.transform);
            ObjList = new List<GameObject>();
            obj.transform.SetParent(FatherObj.transform);
        }
    }
}

public class PoolMgr : BaseMgr<PoolMgr>
{
    private Dictionary<string,PoolData> _dicPool = new Dictionary<string,PoolData>();
    internal GameObject _poolObj;

    public PoolMgr()
    {
        if (_poolObj == null)
        {
            _poolObj = new GameObject("Pool");
        }
    }
    
    /// <summary>
    /// 获取缓存池中的内容
    /// </summary>
    /// <param name="name"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public void GetObj(string name)
    {
        GameObject obj;
        //如果有
        if (_dicPool.ContainsKey(name) && _dicPool[name].ObjList.Count > 0)
        {
            obj= _dicPool[name].ObjList[0];
            _dicPool[name].ObjList.Remove(obj);
            obj.SetActive(true);
            obj.transform.SetParent(null);
        }
        else
        {
            ResMgr.instance.LoadAsync<GameObject>(name, (_obj) =>
            {
                obj = _obj;
                obj.name = name;
                obj.SetActive(true);
                obj.transform.SetParent(null);
            });
        }
    }
    
    /// <summary>
    /// 放入缓存池进行缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void PushObj(string name,GameObject obj)
    {
        obj.SetActive(false);
        if (_dicPool.ContainsKey(name))
        {
            _dicPool[name].ObjList.Add(obj);
            obj.transform.SetParent(_dicPool[name].FatherObj.transform);
        }
        else
        {
            _dicPool.Add(name,new PoolData(name,_poolObj,obj));
        }
    }

    
    /// <summary>
    /// 切场景时调用进行清空
    /// </summary>
    public void Clear()
    {
        _dicPool.Clear();
        if (_poolObj != null)
            GameObject.Destroy(_poolObj);
        _poolObj=null;
    }
}
