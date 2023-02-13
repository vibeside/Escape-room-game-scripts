using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[System.Serializable]
public class Item2{
    public string Name; //May be irrelevant
    public GameObject obj;
    public Sprite Icon;
}
public class objectScript : MonoBehaviour {
    public inventoryScript inv;
    public bool noWork;
    public Item2[] ItemList;
    // Start is called before the first frame update
    void Start() {
        if (inv == null) {
            Debug.Log($"The gameobject named {this.gameObject.name} has no inv");
            noWork = true;
        }
    }

    // Update is called once per frame
    void Update() {
Debug.Log("penis");
    }
}
