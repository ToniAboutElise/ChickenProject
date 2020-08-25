using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MonoBehaviour
{
    public Rigidbody rb;

    protected void AutomaticVelocity()
    {
        rb.velocity = Vector3.forward * -10;
    }

    void Update()
    {
        AutomaticVelocity();
    }
}
