using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipQueue : MonoBehaviour
{
    public List<Image> icons;
    List<Chip> queue;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetQueue(Chip[] chips)
    {

        if (chips != null)
        {
            queue = new List<Chip>(chips);
            Debug.Log("Setting up ChipQueue with " + chips.Length + " chips.");
transform.localPosition = new Vector3(-0.36f + .12f * chips.Length, 0.631f);
        }
        for (int i = 0;i < icons.Count;i++)
        {
            if (chips != null && i < queue.Count)
            {
                icons[i].sprite = queue[i].chipSprite;
                icons[i].gameObject.SetActive(true);
            }else
                icons[i].gameObject.SetActive(false);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
