using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UsePowerUpBehavior : PowerUpBehavior
{

    /// <summary>
    /// Activates the current powerUp
    /// </summary>
    /// <param name="arg">the argument that needs to be passed through</param>
    public override void Activate(params object[] arg)
    {
        if (CurrentPowerUp is null)
            return;

        CurrentPowerUp.Activate(arg);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ninja")
        {
            PowerUpBehavior powerUp = other.GetComponent<PowerUpBehavior>();
            if (powerUp)
            {
                GetComponent<PowerUpBehavior>().CurrentPowerUp = powerUp.CurrentPowerUp;
                Activate();
                Destroy(other.gameObject);
            }
        }
        //I am setting a tag for this so nothing can mess up Ravis's tests, However I do think we should use this tag instead
        //Of a ninja tag. The power ups should all activate the same afterall.
        else if (other.tag == "PowerUp")
        {
            PowerUpBehavior Ability = other.GetComponent<PowerUpBehavior>();
            if (Ability)
            {
                GetComponent<PowerUpBehavior>().CurrentPowerUp = Ability.CurrentPowerUp;
                Activate();
                Destroy(other.gameObject);
            }
        }
    }
}