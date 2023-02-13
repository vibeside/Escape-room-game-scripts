using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour {
    public inventoryScript inv;
    // Start is called before the first frame update
    void Start() {

    }
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1))
        {
            foreach(Item2 slot in inv.Slots){
                if(slot.obj != null){
                    Debug.Log(slot.Name);
                }

            }
            inv.place(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll (mousePosition, new Vector2 (0, 0), 0.01f);
            foreach(RaycastHit2D hitD in hits){
                GameObject inTer = hitD.collider.gameObject;
                if(inTer.tag == "interact") {
                    if (inTer.GetComponent<clickHandler>() != null) {
                        if (inTer.activeSelf) {
                            inTer.GetComponent<clickHandler>().interact();
                            break;
                        }
                    }
                }
                if(inTer.tag == "object"){
                    foreach(Item2 meh in inv.itemlist.ItemList){
                        if(meh.obj != null) {
                            if (inTer.gameObject == meh.obj) {
                                inv.addByName(meh.Name);
                                break;
                            }
                        }
                    }
                    /*
                    if(inTer.GetComponent<objectScript>() != null){
                        inv.addByName("string");
                        break;
                    }
                    */
                }
            }
        }
    }
}