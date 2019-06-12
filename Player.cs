using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _moveTimeRemaining;
    private float _shootTimeRemaining;
    Vector2 _currentPosition;
    public Vector3 offset;
    public Vector3 projectileOffset;
    public float moveTimer;
    public float shootTimer;
    private List<Projectile> _projectiles;
    public GameObject projectilePrefab;
    public ChipQueue chipQueue;
    // Start is called before the first frame update
    void Start()
    {
        BattleManager.Instance.Player = this;
        BattleManager.Instance.ResetPlayerPosition();
        chipQueue.SetQueue(null);
        _projectiles = new List<Projectile>();
        for(int i = 0;i < BattleManager.Instance.ProjectilePoolSize;i++)
        {
            GameObject p = Instantiate(projectilePrefab);
            _projectiles.Add(p.GetComponent<Projectile>());
        }
    }

    public void Move(Vector2 direction)
    {
        if (_moveTimeRemaining > 0)
            return;
        Vector2 newPosition = _currentPosition + direction;
        BattleSquare newSquare = BattleManager.Instance.GetBattleSquare(newPosition);
        
        if(newSquare != null && CanMove(newSquare))
        {
            ChangeSquare(newSquare);
            _moveTimeRemaining = moveTimer;
        }
    }

    public void ChangeSquare(BattleSquare bs)
    {
        transform.parent = bs.transform;
        transform.position = bs.transform.position + offset;
        _currentPosition = bs.Position;

    }
    public bool CanMove(BattleSquare bs)
    {
        if(bs.IsFriendly)
        {
            return true;
        }

        return false;
    }

    public void Shoot()
    {
        if (_shootTimeRemaining > 0)
            return;

        Projectile projectile = null;
        
        foreach(Projectile p in _projectiles)
        {
            GameObject obj = p.gameObject;
            if (obj.activeSelf == false)
            {
                projectile = p;
                break;
            }
        }

        if (projectile == null)
            return;

        projectile.gameObject.SetActive(true);
        projectile.transform.position = transform.position + projectileOffset;
        projectile.SetSpeed(new Vector2(15, 0));
        projectile.SetOwner(gameObject);
        _shootTimeRemaining = shootTimer;
        _moveTimeRemaining = Mathf.Max(_moveTimeRemaining, _shootTimeRemaining);//Rooted after taking a shot
    }

    public void SetQueue(Chip[] chips)
    {
        
        chipQueue.SetQueue(chips);
    }
    // Update is called once per frame
    void Update()
    {
        if (BattleManager.Instance.State == GameState.Battle)
        {
            if (_moveTimeRemaining > 0)
            {
                _moveTimeRemaining -= Time.deltaTime;
            }

            if (_shootTimeRemaining > 0)
            {
                _shootTimeRemaining -= Time.deltaTime;
            }
        }
    }
}
