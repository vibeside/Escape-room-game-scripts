using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.UI;
//test no.1 trying out differnt setup

//public class Location
//{
 //   public string Name {get; set;}
 //   public bool Up {get; set;}
 //   public bool Down {get; set;}
 //   public bool Left {get; set;}
 //   public bool Right {get; set;}
//    public Location(string name, bool up, bool down, bool left, bool right){
 //       this.Name = name;
//        this.Down = down;
 //       this.Up = up;
  //      this.Left = left;
 //       this.Right = right;
 //   }
//}
[System.Serializable]
public class Location
{
    public string Name;
    public Sprite Img;
    public bool Up;
    public string UpName;
    public bool Down;
    public string DownName;
    public bool Left;
    public string LeftName;
    public bool Right;
    public string RightName;
    public GameObject[] interactables;
}

public class arrowHandler : MonoBehaviour
{
    public Location[] Locations;
    public string curLocname;
    public Location curLoc;
    public Image img;
    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;
    // Start is called before the first frame update
    void Start()
    {
        //1 up,2 down,3 right,4 left
        changeImage(5);


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeImage(int dir)
    {

        foreach(Location loc in Locations){
            if(loc != null) {
                if (loc.Name == curLocname) {
                    curLoc = loc;
                    img.sprite = curLoc.Img;
                    curLocname = curLoc.Name;
                }
                foreach(GameObject interactable in loc.interactables){
                    if(interactable != null)
                    {
                        interactable.SetActive(false);
                    }
                }
            }
        }

        // figure out which location we're changing to
        switch(dir){
            case 1:
                //up
                foreach(Location loc in Locations){
                    if (loc == null || loc.Name != curLoc.UpName) continue;
                    foreach(GameObject interactable in curLoc.interactables){
                        interactable.SetActive(false);
                    }
                curLoc = loc;
                img.sprite = curLoc.Img;
                curLocname = curLoc.Name;
                    foreach(GameObject interactable in curLoc.interactables){
                        if(interactable.GetComponent<clickHandler>() != null){
                            if(!interactable.GetComponent<clickHandler>().startsOff){
                                interactable.SetActive(true);
                            }
                        }
                    }
                    break;
                }
            break;
            case 2:
                //Down
                foreach(Location loc in Locations){
                    if (loc == null || loc.Name != curLoc.DownName) continue;
                    foreach(GameObject interactable in curLoc.interactables){
                        interactable.SetActive(false);
                    }
                    curLoc = loc;
                    img.sprite = curLoc.Img;
                    curLocname = curLoc.Name;
                    foreach(GameObject interactable in curLoc.interactables){
                        if(interactable.GetComponent<clickHandler>() != null){
                            if(!interactable.GetComponent<clickHandler>().startsOff){
                                interactable.SetActive(true);
                            }
                        }
                    }
                    break;
                }
                break;
            case 3:
                //right
                foreach(Location loc in Locations){
                    if (loc == null || loc.Name != curLoc.RightName) continue;
                    foreach(GameObject interactable in curLoc.interactables){
                        interactable.SetActive(false);
                    }
                    curLoc = loc;
                    img.sprite = curLoc.Img;
                    curLocname = curLoc.Name;
                    foreach(GameObject interactable in curLoc.interactables){
                        if(interactable.GetComponent<clickHandler>() != null){
                            if(!interactable.GetComponent<clickHandler>().startsOff){
                                interactable.SetActive(true);
                            }
                        }
                    }
                    break;
                }
                break;
            case 4:
                //left
                foreach(Location loc in Locations){
                    if (loc == null || loc.Name != curLoc.LeftName) continue;
                    curLoc = loc;
                    img.sprite = curLoc.Img;
                    curLocname = curLoc.Name;
                    foreach(GameObject interactable in curLoc.interactables){
                        if(interactable.GetComponent<clickHandler>() != null){
                            if(!interactable.GetComponent<clickHandler>().startsOff){
                                interactable.SetActive(true);
                            }
                        }
                    }
                    break;
                }
                break;
            case 5:
            break;
            default:
            Debug.Log("YOU BUFFOON YOU FED THE WRONG DIR VALUE");
            break;
        }
        //
        Up.SetActive(curLoc.Up);
        Down.SetActive(curLoc.Down);
        Right.SetActive(curLoc.Right);
        Left.SetActive(curLoc.Left);
    }

}

