using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableChipManager : MonoBehaviour
{
    public List<AvailableChip> _availableChips;
    private List<int> _usedChips = new List<int>();
    private int _chipCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetSlotPosition(int index)
    {
        if(index < 0 || index >= _availableChips.Count )
        {
            Debug.Log("Index out of range: " + index);
            return Vector3.zero;
        }
        return _availableChips[index].transform.position;
    }
    public void Reset(bool shuffle = true)
    {
        _usedChips = new List<int>();
        if (shuffle)
            BattleManager.Instance.ShuffleDeck();
        BattleManager.Instance.DrawStartingHand();
        for (int i = 0; i < _availableChips.Count; i++)
        {
            Chip chip = null;
            if(i < BattleManager.Instance.StartingHandSize)
                chip = BattleManager.Instance.GetAvailableChip(i);
            _availableChips[i].Set(chip);
            if(chip != null)
                _chipCount++;
        }
    }
    public void AddChip(Chip chip)
    {
        if (_chipCount < _availableChips.Count)
            return;
        _availableChips[_chipCount++].Set(chip);
    }

    public bool SlotInUse(int index)
    {
        return _usedChips.Contains(index);
    }

    public bool CanDeselectAny()
    {
        return _usedChips.Count > 0;
    }

    public void Deselect()
    {
        int index = _usedChips[_usedChips.Count-1];
        _usedChips.RemoveAt(_usedChips.Count - 1);
        _availableChips[index].SetFadeout(false);
    }

    public void FlushUsedChips()
    {
        if (_usedChips.Count == 0)
            return;
        List<Chip> remainingChips = new List<Chip>();
        foreach (AvailableChip ac in _availableChips)
        {
            if (ac.Chip != null)
                remainingChips.Add(ac.Chip);
        }
        
        foreach (int index in _usedChips)
        {
            remainingChips[index] = null;
        }

        _chipCount -= _usedChips.Count;
        _usedChips = new List<int>();
        int i = 0;
        foreach (AvailableChip ac in _availableChips)
        {
            bool found = false;
            for (; i < remainingChips.Count; i++)
            {
                if (remainingChips[i] != null)
                {
                    ac.Set(remainingChips[i++]);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                ac.Set(null);
            }
        }

    }


    public Chip SelectSlot(int index)
    {
        if (index < 0 || index >= _availableChips.Count)
            return null;
        if (_usedChips.Contains(index))
            return null;
        _availableChips[index].SetFadeout(true);
        _usedChips.Add(index);
        return _availableChips[index].Chip;
    }
}
