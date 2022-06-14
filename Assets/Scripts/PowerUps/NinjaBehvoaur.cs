using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaBehvoaur : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    [SerializeField]
    private GameObject _leftSpawnPoint, _rightSpawnPoint, _player;
    public float Damage { get { return _damage; } set { _damage = value; } }
    // Update is called once per frame
    void Update()
    {
        if (this == null)
            return;
        RoutineBehaviour.Instance.StartNewTimedAction(args => ResetGameObject(), TimedActionCountType.UNSCALEDTIME, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallL")
        {
            if (tag == "NinjaL")
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
            if (tag == "NinjaR")
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
        }

        if (other.tag == "WallR")
        {
            if (tag == "NinjaL")
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
            if (tag == "NinjaR")
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
        }
    }
    /// <summary>
    /// Resets the posistion of the ninjas
    /// </summary>
    private void ResetGameObject()
    {
        if (gameObject.tag == "NinjaL")
            transform.position = _leftSpawnPoint.transform.position;
        if (gameObject.tag == "NinjaR")
            transform.position = _rightSpawnPoint.transform.position;
        gameObject.SetActive(false);
    }
}
