using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("0 - none, 1-libKey, 2- diskette, 3 - elixir")]

    [SerializeField] private List<int> items;
    public List<int> Items
    {
        get
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] < 0)
                {
                    print("Item nefative value in Inventory ¹ " + items[i]);
                }
            }
            return items;
        }
        set
        {
            items = value;
        }
    }

    private void Awake()
    {
        Items = items;
    }

    public void AddItemToInventory(int itemTypeInt)
    {
        Items[itemTypeInt]++;
    }

    public void RemoveItem(int itemTypeInt)
    {
        Items[itemTypeInt] = 0;
    }
}
