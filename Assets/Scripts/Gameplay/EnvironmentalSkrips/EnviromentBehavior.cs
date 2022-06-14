using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentBehavior : MonoBehaviour
{
    public static EnviromentBehavior Instance;
    [SerializeField]
    private GameObject _enviromentRef;
    private Rigidbody _rigidbody;
    private int _hitCount;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.Instace._advaceForwardTrue == true)
        {
            Instance.GetComponent<MovementBehavior>().Speed = 40;
            GameManager.Instace._advaceForwardTrue = false;
        }
           
        RoutineBehaviour.Instance.StartNewTimedAction(args => Destroy(this._enviromentRef), TimedActionCountType.UNSCALEDTIME, 15);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            _hitCount++;
            if (_hitCount <= 1)
            {
                GetComponent<MovementBehavior>().Speed = 0;
            }
        }
    }
}
