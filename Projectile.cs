using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 _speed;
    GameObject _owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetOwner(GameObject owner)
    {
        _owner = owner;
    }
    public void SetSpeed(Vector2 speed)
    {
        _speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _owner)
            return;

        gameObject.SetActive(false);
        return;
    }
    // Update is called once per frame
    void Update()
    {
        if(BattleManager.Instance.State == GameState.Battle)
        {
            transform.position += _speed * Time.deltaTime;
        }
    }
}
