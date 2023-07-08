using System.Collections.Generic;
using UnityEngine;

public abstract class PoolManager<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;

    protected readonly HashSet<T> ActivePool = new();

    private readonly Queue<T> _poolQueue = new();

    public virtual T Get(Vector3 position)
    {
        var item = GetItem(transform);
        ActivePool.Add(item);
        item.transform.position = position;
        return item;
    }

    private T GetItem(Transform parent)
    {
        if (_poolQueue.TryDequeue(out var item))
        {
            item.gameObject.SetActive(true);
            item.transform.SetParent(parent);
        }
        else
        {
            item = Instantiate(prefab, parent);
        }

        return item;
    }

    public void ReturnToPool(T itemToReturn)
    {
        itemToReturn.gameObject.SetActive(false);
        itemToReturn.transform.SetParent(transform);
        _poolQueue.Enqueue(itemToReturn);
        ActivePool.Remove(itemToReturn);
    }
}