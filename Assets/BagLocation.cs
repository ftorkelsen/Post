using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagLocation : MonoBehaviour
{
    public bool willMove;
    public GameObject currentBag;
    public Image image;
    public Image flag;
    public GameObject goBag;
    
    void Start()
    {
        currentBag = null;
    }

    public void pushBag(GameObject bag)
    {
        currentBag = bag;
        
        if (bag != null)
        {   
            bag.transform.position = this.transform.position;
            bag.GetComponent<Bag>().CheckCapacity();
        }
    }
}

