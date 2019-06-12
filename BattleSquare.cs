using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleSquare : MonoBehaviour
{
    public bool _friendly;
    public Color color;
    public SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        SetOwner(_friendly);
    }

    private Vector2 _position;
    public Vector2 Position
    {
        get
        {
            return _position;
        }

        set
        {
            _position = value;
        }
    }
    void SetOwner(bool friendly)
    {
        if ((_friendly = friendly) == true)
        {
            color = BattleManager.Instance.FriendlyColor;
        }
        else
        {
            color = BattleManager.Instance.EnemyColor;
        }
        spriteRenderer.color = color;
    }

    void ToggleOwner()
    {
        if((_friendly = !_friendly) == true)
        {
            color = BattleManager.Instance.FriendlyColor;
        }
        else
        {
            color = BattleManager.Instance.EnemyColor;
        }
        spriteRenderer.color = color;
    }

    public bool IsFriendly
    {
        get
        {
            return _friendly;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
