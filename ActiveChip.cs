using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveChip : MonoBehaviour
{
    public Image image;
    private Chip chip;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Set(Chip chip)
    {
        this.chip = chip;
        Debug.Log(chip.name + " is being assigned to " + gameObject.name);
        image.sprite = chip.chipSprite;
    }

    public void Clear()
    {
        chip = null;
        image.sprite = null;
    }

    public Chip GetChip()
    {
        return chip;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
