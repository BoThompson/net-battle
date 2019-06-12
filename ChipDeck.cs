using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipDeck : MonoBehaviour
{
    public List<int> deck = new List<int>();
    List<int> _availableChips = new List<int>();
    List<int> _remainingChips = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        BattleManager.Instance.Deck = this;
        if (BattleManager.Instance.testMode)
        {
            BattleManager.Instance.GenerateDeck();
        }
        Reset();
        Shuffle();
        Draw(5);
    }

    private void Reset()
    {
        _remainingChips = new List<int>(deck);
    }

    public void Shuffle()
    {
        for (int i = _remainingChips.Count - 2; i > 0; i--)
        {
            int index = Random.Range(0, i);
            int chipNumber = _remainingChips[index];
            _remainingChips[index] = _remainingChips[i];
            _remainingChips[i] = chipNumber;
        }
    }

    public void AddChip(int chipNumber, bool addToAvailable = false)
    {
        deck.Add(chipNumber);
        if (addToAvailable)
            _availableChips.Add(chipNumber);
    }
    public void Draw(int drawAmount)
    {
        for(int i = 0;i < drawAmount;i++)
        {
            int index = Random.Range(0, _remainingChips.Count);
            int chipNumber = _remainingChips[index];
            _remainingChips.RemoveAt(index);
            //Debug.Log("Chip Index: " + index + " Number: " + chipNumber);
            _availableChips.Add(chipNumber);
        }
    }

    public void ClearAvailable()
    {
        List<int> availableChips = new List<int>();
    }

    public Chip GetAvailableChip(int index)
    {
        Chip chip = null;
        if(index < _availableChips.Count)
            chip = BattleManager.Instance.GetChip(_availableChips[index]);
        return chip;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
