﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BagQueue : MonoBehaviour
{
    public float bagInterval;
    public List<BagLocation> bagPositions;
    private float timer;
    public GameObject bag;
    public List<Bag> bags;
    private System.Random random;
    private int maxBagNumber;
    public int currentBagNumber;

    public List<Sprite> sprites;
    public Sprite swedish;
    public Sprite danish;
    public Sprite gold;
    
    void Start()
    {
        timer = bagInterval;
        random = new System.Random();
        maxBagNumber = bagPositions.Count;
    }

    void Update()
    {
        timer += Time.deltaTime; //Debug.Log("time: "+timer);
        if (timer >= bagInterval)
        {
            AddBag(); timer = 0f;
        }
    }

    public void AddBag()
    {
        bag = GameObject.Instantiate(bag);

        List<LetterType> acceptedTypes = new List<LetterType>();
        LetterType accepted = (LetterType)random.Next(1, Enum.GetNames(typeof(LetterType)).Length);
        acceptedTypes.Add(accepted); 
        acceptedTypes.Add(LetterType.Gold);

        bag.GetComponent<Bag>().Initialise(sprites[(int)accepted], acceptedTypes);
        bag.transform.SetParent(this.transform);
        bag.transform.position = this.bagPositions[0].transform.position;
        
        currentBagNumber += 1;
        bagPositions[0].currentBag = bag;

        for (int i = bagPositions.Count-1; i>0; i--)
        {
            bagPositions[i].pushBag(bagPositions[i - 1].currentBag);
        }
        CheckBagQueue();
    }
    
    void CheckBagQueue()
    {
        if (currentBagNumber > maxBagNumber)
        {
            
        }
    }

    public void RemoveBag(BagLocation bagLocation)
    {
        currentBagNumber -= 1;
    }
}
