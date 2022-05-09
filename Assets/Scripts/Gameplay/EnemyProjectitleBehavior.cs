using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectitleBehavior : MonoBehaviour
{
    private string _ownerTag;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private FireBehaviour _gun;
    [SerializeField]
    private float _bulletCooldown;
    [SerializeField]
    private bool _destroyOnHit;
    private float _bulletTimer;

    public string OwnerTag
    {
        get { return _ownerTag; }
        set { _ownerTag = value; }
    }

    // Update is called once per frame
    void Update()
    {
        //only fire when the timmer is greater than cooldown
        _bulletTimer += Time.deltaTime;
        if (_bulletTimer >= _bulletCooldown)
        {
            _gun.Fire();
            //resets timer
            _bulletTimer = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == OwnerTag)
            return;

        HealthBehavior otherHealth = other.GetComponent<HealthBehavior>();

        if (!otherHealth)
            return;

        otherHealth.TakeDamage(_damage);

        //deletes the bullet on collision
        if (_destroyOnHit)
            Destroy(gameObject);
    }
}
