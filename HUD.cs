using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /**
     * brief */
    public void ExitMenuState()
    {
        BattleManager.Instance.ChangeGameState(GameState.Battle);
    }

    public void EnterMenuState()
    {
        BattleManager.Instance.ChangeGameState(GameState.Menu);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
