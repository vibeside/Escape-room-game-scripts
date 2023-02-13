using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DisplayIcons : MonoBehaviour {
    private GameObject theParent;
    public List<GameObject> iconPos = new List<GameObject>();
    public inventoryScript inv;
    private Image def;
    // Start is called before the first frame update
    void Start() {
        theParent = this.gameObject;
        for (int i = 0; i < theParent.transform.childCount; i++) {
            if(theParent.transform.GetChild(i).GetComponent<Image>() != null){
                iconPos.Add(theParent.transform.GetChild(i).gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        foreach(GameObject obj in iconPos){
            if(obj.GetComponent<Image>().sprite == def){
                obj.GetComponent<Image>().color = new Color(255,255,255,0);
            }else{
                obj.GetComponent<Image>().color = new Color(255,255,255,255);
            }
        }
        for(int i = 0; i < iconPos.Count; i++){
            iconPos[i].GetComponent<Image>().sprite = inv.Slots[i].Icon;
        }
    }
}

