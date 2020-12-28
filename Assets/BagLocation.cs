using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagLocation : MonoBehaviour
{
    public GameObject currentBag;
    //public GameObject activeBag;
    public BagLocation previousLocation;

    void Start()
    {
        currentBag = null;
        //activeBag = null;
        //GameEvents.current.onPushBags += pushBag;
    }

    public void SetPreviousBag(BagLocation bagLocation)
    {
        this.previousLocation = bagLocation;
    }

    public void pushBag(GameObject bag)
    {
        if (previousLocation != null)
        {
            currentBag = bag; //previousLocation.activeBag;
        
            if (currentBag != null)
            {
                LeanTween.moveX(currentBag, this.transform.position.x, 1f);
                if (currentBag.GetComponent<Bag>().CheckCapacity())
                {
                    GameEvents.current.FullBag(this);
                }
            }
        }
        //this.activeBag = currentBag;
    }
}

