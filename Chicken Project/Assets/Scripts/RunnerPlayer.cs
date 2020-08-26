using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayer : MonoBehaviour
{
    public RunnerController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RunnerBonus>())
        {
            RunnerBonus runnerBonus = other.GetComponent<RunnerBonus>();
            runnerBonus.autoVelocity = false;
            runnerBonus.enemiesVelocity = 0;
            Destroy(runnerBonus.GetComponent<Rigidbody>());
            runnerBonus.transform.SetParent(null);
            runnerBonus.GetComponent<Animation>().Play("RunnerBonusGrab");
            //Destroy(runnerBonus);
            controller.UpdateCurrentPoints(other.GetComponent<RunnerBonus>().pointsValue);
        }
    }
}
