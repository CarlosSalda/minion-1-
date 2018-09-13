using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionsBall : MonoBehaviour {

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Power Up")
        {
            Destroy(collision.gameObject);
        }
    }

    private void BaloonPowerUP(Collider2D collision)
    {

        if (collision.gameObject.name == "baloon")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
