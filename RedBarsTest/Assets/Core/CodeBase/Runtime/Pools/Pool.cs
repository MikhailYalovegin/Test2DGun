using System;
using System.Collections.Generic;
using RBT.CodeBase.Runtime.Gameplay.Factories;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Pools
{
  public class Pool<TElement> : IInitializable where TElement : Component
  {
    private readonly DiContainer _diContainer;
    private readonly Transform _poolContainer;
    private readonly int _maxCapacity = 100;
    private readonly int _minCapacity;
    private readonly bool _autoExpand;
    private readonly GameObject _prefab;

    private List<TElement> _pool;


    public Pool(DiContainer diContainer, GameObject prefab, int minCapacity, bool autoExpand = true)
    {
      _diContainer = diContainer;
      _prefab = prefab;
      _minCapacity = minCapacity;
      _autoExpand = autoExpand;

      if (_autoExpand)
        _maxCapacity = int.MaxValue;

      var poolObj = new GameObject($"PoolContainer {typeof(TElement).Name}");
      poolObj.transform.parent = GameObject.Find(SceneParentNames.Pools).transform;

      _poolContainer = poolObj.transform;
    }

    public void Initialize() =>
      CreatePool();

    public virtual TElement GetFreeElement(Vector3 position, Quaternion rotation)
    {
      TElement element = GetFreeElement();
      Transform transform = element.transform;
      transform.position = position;
      transform.rotation = rotation;
      return element;
    }

    protected virtual TElement CreateElement(bool isActiveByDefault = false)
    {
      var createObject =
        _diContainer.InstantiatePrefabForComponent<TElement>(_prefab.GetComponent<TElement>(), _poolContainer);
      createObject.gameObject.SetActive(isActiveByDefault);

      _pool.Add(createObject);

      return createObject;
    }

    protected virtual TElement GetFreeElement()
    {
      if (TryGetElement(out TElement element))
        return element;

      if (_autoExpand || _pool.Count < _maxCapacity)
        return CreateElement(true);

      throw new Exception($"Pool of {typeof(TElement).Name} is Over!");
    }

    private void CreatePool()
    {
      _pool = new List<TElement>(_minCapacity);

      for (var i = 0; i < _minCapacity; i++)
        CreateElement();
    }

    private bool TryGetElement(out TElement element)
    {
      int index = _pool.FindIndex(item => item.gameObject.activeInHierarchy == false);
      if (index != -1)
      {
        element = _pool[index];
        element.gameObject.SetActive(true);
        return true;
      }

      element = null;
      return false;
    }
  }
}