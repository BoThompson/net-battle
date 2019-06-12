using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChipType
{
    Star,
    A,
    B,
    C,
    S,
    W
}

public class Chip : MonoBehaviour
{
    public string name;
    public Sprite chipSprite;
    public int chipNumber;
    public ChipType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
