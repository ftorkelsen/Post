using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public int capacity;
    private int current;
    public List<LetterType> acceptedTypes;
    public List<Sprite> sprites;
    private int fillStage;
    public Image flag;
    public Sprite sprite;

    public void Initialise(Sprite flag, List<LetterType> acceptedTypes)
    {
        this.flag.sprite = flag;
        this.acceptedTypes = acceptedTypes;
        this.sprite = sprites[1];
        this.current = 0;
    }

    private enum fillStages
    {
        low = 2,
        med = 5,
        high = 7
    }
    
    public Bag(List<LetterType> acceptedTypes)
    {
        
    }

    public void AddLetter(LetterType letterType)
    {
        if (acceptedTypes.Contains(letterType))
        {
            if (letterType == LetterType.Gold)
            {
                current = capacity;
            }
            else
            {
                current += 1;
            }
        }
        CheckCapacity();
    }

    public void CheckCapacity()
    {
        if (current == capacity)
        {

        }
    }
}
