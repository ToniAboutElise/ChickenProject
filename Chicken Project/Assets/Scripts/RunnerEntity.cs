using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEntity : MonoBehaviour
{
    public Rigidbody rb;
    public float enemiesVelocity = 10;

    protected void AutomaticVelocity()
    {
        rb.velocity = Vector3.forward * -enemiesVelocity;
    }

    void Update()
    {
        AutomaticVelocity();
    }
}
