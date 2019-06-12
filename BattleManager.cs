using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Battle,
    Menu,
    Pause
}



public class BattleManager : MonoBehaviour
{
    public bool testMode;
    public Color FriendlyColor;
    public Color EnemyColor;
    public Vector2 PlayerStartingPosition;
    public int ProjectilePoolSize;
    public float CustomFillSpeed;
    public int MaximumDeckSize;
    public int StartingHandSize;
    public float moveTimer;
    public bool firstDraw;
    public float inputLockTimer;
    private float inputLockTimeRemaining;

    [System.Serializable]
    public class ChipTypeSpritePair
    {
        public ChipType type;
        public Sprite sprite;
    }
    [SerializeField]
    public List<ChipTypeSpritePair> ChipTypePairs;
    private Dictionary<ChipType, Sprite> ChipTypeSprites = new Dictionary<ChipType, Sprite>();
    public GameState State
    {
        get
        {
            return _gamestate;
        }
    }
    private GameState _gamestate = GameState.Battle;
    private static BattleManager _instance = null;
    public static BattleManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private Player _player;
    public Player Player
    {
        get
        {
            return _player;
        }
        set
        {
            if (_player == null)
                _player = value;
        }
    }
    public CustomMenu customMenu;
    
    private ChipDeck _deck;
    public ChipDeck Deck
    {
        get
        {
            return _deck;
        }
        set
        {
            if (_deck == null)
                _deck = value;
        }
    }

    private ChipLibrary _library;
    public ChipLibrary Library
    {
        get
        {
            return _library;
        }
        set
        {
            if (_library == null)
                _library = value;
        }
    }

    private CustomSlider _customSlider;
    public CustomSlider CustomSlider
    {
        get
        {
            return _customSlider;
        }
        set
        {
            if (_customSlider == null)
                _customSlider = value;
        }
    }

    public Board _board;
    public Board Board
    {
        get
        {
            return _board;
        }
        set
        {
            if (_board == null)
                _board = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        firstDraw = false;
        foreach(ChipTypeSpritePair ctsp in ChipTypePairs)
        {
            ChipTypeSprites.Add(ctsp.type, ctsp.sprite);
        }
    }

    public void GenerateDeck()
    {
        for (int i = 0; i < MaximumDeckSize; i++)
        {
            int chipNum = Library.GetRandom();
            Deck.AddChip(chipNum);
        }
    }

    public Chip GetChip(int chipNumber)
    {
        return Library.GetChip(chipNumber);
    }

    public void ShuffleDeck()
    {
        _deck.Shuffle();
    }

    void ProcessInput()
    {
        switch(_gamestate)
        {
            case GameState.Battle: ProcessBattleInput(); break;
            case GameState.Menu: ProcessMenuInput(); break;
            default: break;
        }
    }

    void ProcessMenuInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0)
        {
            customMenu.MoveSelected(MenuDirection.Right);
        }
        else if (horizontal < 0)
        {
            customMenu.MoveSelected(MenuDirection.Left);
        }
        else if (vertical > 0)
        {
            customMenu.MoveSelected(MenuDirection.Up);
        }
        else if (vertical < 0)
        {
            customMenu.MoveSelected(MenuDirection.Down);
        }
        else if (Input.GetButtonDown("Select"))
        {
            customMenu.SelectSlot();
        }
        else if(Input.GetButtonDown("Cancel"))
        {
            customMenu.UndoSelectSlot();
        }
        if (Input.GetButtonDown("Custom Menu"))
        {
            CloseCustomMenu();
        }

    }
    void ProcessBattleInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       
        Vector2 moveImpulse = Vector2.zero;
        if (horizontal > 0)
        {
            moveImpulse.x = 1;
        }
        else if (horizontal < 0)
        {
            moveImpulse.x = -1;
        }


        if (vertical > 0)
        {
            moveImpulse.y = 1;
        }
        else if (vertical < 0)
        {
            moveImpulse.y = -1;
        }
        if (moveImpulse.x != 0 || moveImpulse.y != 0)
            _player.Move(moveImpulse);
        if(Input.GetButton("Shoot"))
            _player.Shoot();
        if (Input.GetButtonDown("Custom Menu"))
        {
            OpenCustomMenu();
        }
    }

    public void ResetPlayerPosition()
    {
        _player.ChangeSquare(_board.GetBattleSquare(PlayerStartingPosition));
    }

    public void OpenCustomMenu()
    {
        if (CustomSlider.Value < 1)
            return;
        customMenu.Open();
    }

    public void CloseCustomMenu()
    {
        if(customMenu.HasActiveChips)
            CustomSlider.Value = 0;
        customMenu.Close();
    }
    public BattleSquare GetBattleSquare(Vector2 coord)
    {
        return _board.GetBattleSquare(coord);
    }

    public Sprite TypeSprite(ChipType type)
    {
        return ChipTypeSprites[type];
    }

    public void ChangeGameState(GameState newState)
    {
        inputLockTimeRemaining = inputLockTimer;
        _gamestate = newState;
    }

    public void SetupQueue(Chip[] queue)
    {
        if(queue != null)
            Debug.Log("Setting up queue with " + queue.Length);
        _player.SetQueue(queue);
    }
    public void DrawStartingHand()
    {
        _deck.ClearAvailable();
        _deck.Draw(StartingHandSize);
    }
    public Chip GetAvailableChip(int slotNumber)
    {
        return _deck.GetAvailableChip(slotNumber);
    }
    // Update is called once per frame
    void Update()
    {
        if(inputLockTimeRemaining > 0)
        {
            inputLockTimeRemaining -= Time.deltaTime;
        }else
            ProcessInput();
    }
}
