using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActiveChipManager : MonoBehaviour
{
    public List<ActiveChip> activeChips;
    int _chipCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetChip(int slotNum, Chip chip)
    {
        if (slotNum < 0 || slotNum >= activeChips.Count)
            return;
        activeChips[slotNum]?.Set(chip);
    }

    public void ClearLastChip()
    {
        if (_chipCount > 0)
            activeChips[--_chipCount].Clear();
    }

    public void ClearChips()
    {
        foreach(ActiveChip ac in activeChips)
        {
            ac.Clear();
        }
    }

    public bool CanAddChip()
    {
        return _chipCount < activeChips.Count;
    }
    public bool CanDropChip()
    {
        return _chipCount > 0;
    }

    public void AddChip(Chip chip)
    {
        activeChips[_chipCount++].Set(chip);
        return;
    }

    public void DropChip()
    {
        activeChips[--_chipCount].Clear();
    }

    public void Reset()
    {
        ClearChips();
    }

    public Chip[] LoadQueue()
    {
        Chip[] queue = new Chip[_chipCount];
        for(int i = 0;i<_chipCount;i++)
        {
            queue[i] = activeChips[i].GetChip();
            activeChips[i].Clear();
        }
        _chipCount = 0;
        return queue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
