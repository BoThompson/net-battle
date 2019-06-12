using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipLibrary : MonoBehaviour
{
    private Dictionary<int, Chip> _chips = new Dictionary<int,Chip>();
    private List<int> _chipList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        BattleManager.Instance.Library = this;
        foreach(Chip chip in GetComponentsInChildren<Chip>())
        {
            _chips.Add(chip.chipNumber, chip);
            _chipList.Add(chip.chipNumber);
        }
    }

    public Chip GetChip(int chipNumber)
    {
        Chip chip;
        _chips.TryGetValue(chipNumber, out chip);
        return chip;
    }

    public int GetRandom()
    {
        return _chipList[Random.Range(0, _chips.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
