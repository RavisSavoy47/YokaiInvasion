using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private bool _isAlive;
    [SerializeField]
    private bool _destroyOnDeath;

    public float Health
    {
        get { return _health; }
        
    }
    public float MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }


    public bool IsAlive
    {
        get { return _isAlive; }
    }

    //deals the damage amount and sends back the result
    public virtual float TakeDamage(float damgeAmount)
    {
        _health -= damgeAmount;

        return damgeAmount;
    }

    public virtual void OnDeath()
    {
        //sets it to be not alive
        _isAlive = false;
    }
    private void Awake()
    {
        _health = _maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        //checks if health is lower than 0 while being alive
        if (_health <= 0 && IsAlive)
            OnDeath();

        _isAlive = _health > 0;

        //checks if it is dead and deletes on death
        if (!IsAlive && _destroyOnDeath)
        {
            Destroy(gameObject);
            if(tag == "Player")
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
            
    }
}
