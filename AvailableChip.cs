using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableChip : MonoBehaviour
{
    public Image chipImage;
    public Image typeImage;
    public Image fadeoutImage;
    private Chip chip;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Set(Chip chip)
    {
        SetFadeout(false);
        this.chip = chip;
        if (chip != null)
        {
            
            chipImage.sprite = chip.chipSprite;
            //TODO: This is ugly, pick a better way.
            typeImage.sprite = BattleManager.Instance.TypeSprite(chip.type);

        }
        else {
            chipImage.sprite = null;
            typeImage.sprite = null;

        }

    }

    public void SetFadeout(bool fade)
    {
        if (fade)
            fadeoutImage.color = new Color(0, 0, 0, .5f);
        else
            fadeoutImage.color = new Color(0, 0, 0, 0f);
    }
    public Chip Chip{
        get{
            return chip;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   
}
