//Attach this script to the GameObject you would like to have mouse clicks detected on
//This script outputs a message to the Console when a click is currently detected or when it is released on the GameObject with this script attached

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool beingClicked=false;
    public arrowHandler arrHandler;
    public bool isArrow;
    public bool Locked;
    public bool hasKey;
    public bool startsOff = false;
    public Sprite imgChanger;
    private Sprite imgOld;
    public GameObject OtherEnable;
    public bool OtherEnablebool;
    public GameObject[] Child;
    public bool ChildStart = true;
    public bool isSwapping;
    public string locToChange;
    public int dir;
    //public vector
    //Detect current clicks on the GameObject (the one with the script attached)
    void Start() {
        if (isArrow != true){
            if (arrHandler == null) {
                Debug.Log("Arrow handler is null on " + this.gameObject.name);
            }
            if (OtherEnable == null) {
                Debug.Log("Otherenable is null on " + this.gameObject.name);
            }
        }
        if(locToChange == null) Debug.Log($"How stupid are you?{this.gameObject.name} is lacking LocToChange");
        setAll(ChildStart);
    }
    public void OnPointerDown(PointerEventData pointerEventData) {
        if (!Locked || hasKey) {
            if (arrHandler != null) {
                //1 up,2 down,3 right,4 left
                beingClicked = true;
                if (isArrow) {
                    arrHandler.changeImage(dir);
                }
                if (isArrow != true) {
                    if (OtherEnable != null && !OtherEnablebool) {
                        interact();
                    } else {
                        Debug.Log($"{this.gameObject.name} has no OtherEnable. May not be an error.");
                    }
                }
            } else {
                Debug.Log($"{this.gameObject.name}No arrow Handler attached!");
            }
        }
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        beingClicked = false;
    }
    public void interact() {
        if (!Locked || hasKey) {
            foreach (Location loc in arrHandler.Locations) {
                if (loc != null) {
                    if (loc.Name == locToChange) {
                        imgOld = loc.Img;
                        loc.Img = imgChanger;
                        if (OtherEnablebool) {
                            setAll(false);
                            OtherEnable.SetActive(true);
                            OtherEnable.GetComponent<clickHandler>().setAll(true);
                        }
                        arrHandler.img.sprite = imgChanger;
                        if (isSwapping == true) {
                            // arrHandler.img.sprite = imgChanger;
                            imgChanger = imgOld;
                        }
                    }
                }
            }
        }
    }
    public void setAll(bool set){
        if(Child.Length == 0 && isArrow == false){
            Debug.Log($"{this.gameObject.name} has no children in it's array. May not be an error, so figure out if it is");
        }
        if(Child.Length != 0) {
            foreach (GameObject child in Child) {
                if(child == null) break;
                if(child.gameObject.GetComponent<BoxCollider2D>().autoTiling == true){ child.gameObject.GetComponent<BoxCollider2D>().autoTiling = false; break;}
                child.SetActive(set);
            }
        }
        this.gameObject.SetActive(set);
    }
}