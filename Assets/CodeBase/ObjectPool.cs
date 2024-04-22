using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _itemPrefab;
    private List<T> _items = new List<T>();

    protected void InitPool(T itemprefab)
    {
        _itemPrefab = itemprefab;
    }

    protected T GetItem()
    {
        var item = _items.FirstOrDefault(i => i.gameObject.activeSelf == false);

        if (item == null)
        {
            item = Object.Instantiate(_itemPrefab);
            _items.Add(item);
        }

        return item;
    }
}
