using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{   
    #region Singleton

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 20;
    public static Inventory instance;
    void Awake()
    {   if(instance!=null)
            {
                Debug.LogWarning("More than one inventory");
                return;
            }
        instance = this;
    }
    #endregion
   public List<Item> items = new List<Item>();

   public bool Add (Item item)
   {    if(!item.isDefautItem)
    {           
        if(items.Count >= space)
        {
            Debug.Log("Not Enough Space");
            return false;
        }
        items.Add(item);
        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
       return true;
   }

   public void Remove(Item item)
   {
       items.Remove(item);
       if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
   }
   public bool CheckItem(Item item)
	{
		foreach(Item i in items)
		{
			if(item == i)
			{
				return true;
			}
		}
		return false;
	}

}
