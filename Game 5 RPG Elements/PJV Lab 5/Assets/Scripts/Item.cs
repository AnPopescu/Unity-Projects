
using UnityEngine;
[CreateAssetMenu(fileName="New Item",menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
   new public string name = "New Item";
   public Sprite icon = null;
   public bool isDefautItem = false;
   
   GameObject player;
   public GameObject gamePrefab;

   

   

   //Transform someScript = GameObject.FindWithTag("Player").GetComponent<Transform>();

   public virtual void Use()
   {
      Debug.Log("Using"+name);
      player = GameObject.Find("Player");
      Vector3 placePOS = new Vector3 (player.transform.position.x,-2.7f,player.transform.position.z);
      Instantiate(gamePrefab,placePOS,Quaternion.identity);
      RemoveItem();
      
   }
   public void RemoveItem()
   {
      Inventory.instance.Remove(this);
   }


}
