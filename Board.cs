using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Board : MonoBehaviour
{
    public Dictionary<Vector2, BattleSquare> battleSquares = new Dictionary<Vector2, BattleSquare>();
    // Start is called before the first frame update
    void Start()
    {
       foreach(BattleSquare bs in GetComponentsInChildren<BattleSquare>())
        {
            Vector2 v = new Vector2((bs.transform.position.x + 1) / 2 + 4, bs.transform.position.y + 4);
            battleSquares.Add(v, bs);
            bs.Position = v;

        }
    }

    public BattleSquare GetBattleSquare(Vector2 coordinate)
    {
        BattleSquare bs;
        battleSquares.TryGetValue(coordinate, out bs);
        return bs;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
