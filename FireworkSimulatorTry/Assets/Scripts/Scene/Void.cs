using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{

    public LayerMask whatIsFirework;
    public float checkRadius;
    private void FixedUpdate()
    {
       bool firework = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsFirework);

        if (firework)
        {
            //take health
            Gamemanager.instance.TakeHealth();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
