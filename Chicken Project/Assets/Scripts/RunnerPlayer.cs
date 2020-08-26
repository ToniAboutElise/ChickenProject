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
            controller.UpdateCurrentPoints(other.GetComponent<RunnerBonus>().pointsValue);
        }
    }
}
