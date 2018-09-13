using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointScript : MonoBehaviour {

    // Use this for initialization

    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && gameObject.tag == "point")
        {
            Destroy(gameObject);
            textScript.pointScore ++;
        }

        if (collision.gameObject.tag == "player" && gameObject.tag == "pointx2")
        {
            Destroy(gameObject);
            textScript.pointScore += 2;
        }
    }

}
