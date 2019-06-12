using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuDirection
{
    Up,
    Down,
    Left,
    Right
}
public class CustomMenu : MonoBehaviour
{
    public bool firstTime = true;
    public ActiveChipManager activeChipManager;
    public AvailableChipManager availableChipManager;
    public SlotSelector slotSelector;
    public Animator animator;
    private int _selectedSlot;
    public float InputTimer;
    private float InputTimeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

    }

    public void Reset()
    {
        activeChipManager.Reset();
        availableChipManager.Reset();
    }
    public void Open()
    {

        gameObject.SetActive(true);
        _selectedSlot = 0;
        animator.SetBool("Active", true);
        if (firstTime)
        {
            Reset();
            firstTime = false;
        }
    }
 
    public bool HasActiveChips
    {
        get
        {
            return activeChipManager.CanDropChip();
        }
    }
    public void Close()
    {
        BattleManager.Instance.SetupQueue(activeChipManager.LoadQueue());
        availableChipManager.FlushUsedChips();
        animator.SetBool("Active", false);
    }
    public void MoveSelected(MenuDirection direction)
    {
        if (InputTimeRemaining > 0)
        {
            return;
        }
        switch (direction)
        {
            case MenuDirection.Left:
                if (_selectedSlot == 0 || _selectedSlot == 6)
                {
                    _selectedSlot += 5;
                }
                else
                {
                    _selectedSlot--;
                }
                break;
            case MenuDirection.Right:
                if (_selectedSlot == 5 || _selectedSlot == 11)
                {
                    _selectedSlot -= 5;
                }
                else
                {
                    _selectedSlot++;
                }
                break;
            case MenuDirection.Up:
            case MenuDirection.Down:
                if (_selectedSlot > 5)
                    _selectedSlot -= 6;
                else
                    _selectedSlot += 6;
                break;
        }
        InputTimeRemaining = InputTimer;
        UpdateSelected();
    }

    public void SelectSlot()
    {
        if(InputTimeRemaining > 0)
        {
            return;
        }

        if(!activeChipManager.CanAddChip())
        {
            return;
        }

        Chip chip = availableChipManager.SelectSlot(_selectedSlot);
        if(chip != null)
        {
            activeChipManager.AddChip(chip);
            InputTimeRemaining = InputTimer;
        }
        return;
    }

    public void UndoSelectSlot()
    {
        if (InputTimeRemaining > 0)
        {
            return;
        }

        if (!activeChipManager.CanDropChip())
        {
            return;
        }

        //availableChipManager.UndoSelect();
        activeChipManager.DropChip();
        InputTimeRemaining = InputTimer;
    }

    void UpdateSelected()
    {
        slotSelector.transform.position = availableChipManager.GetSlotPosition(_selectedSlot);
    }
    // Update is called once per frame
    void Update()
    {
        if (InputTimeRemaining > 0)
        {
            InputTimeRemaining -= Time.deltaTime;
        }
    }
}
