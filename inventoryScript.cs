using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryScript : MonoBehaviour
{
    public List<Item2> Slots = new List<Item2>(8);
    public objectScript itemlist;
    public GameObject hide;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addByName(string name) {
        for (int i = 0; i < Slots.Count; i++) {
            foreach (Item2 item in itemlist.ItemList) {
                if (item.Name == name) {
                    if (Slots[i].obj == null) {
                        Slots[i] = item;
                        Slots[i].obj.transform.position = hide.transform.position;
                        return;
                    }
                }
            }
        }
    }
    // debug purposes
    public void place(Vector2 pos){
        if(Slots[0].obj != null) {
           // Slots[0].obj.transform.position = pos;
            Slots.RemoveAt(0);
            Slots.Add(new Item2());
        }
    }
}
