using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject personaje2;

    // Use this for initialization
    void Start() {
        personaje2 = GameObject.Find("personaje");
    }

    void estaVivoPersonajeODentroDeCamara()
    {
        if (personaje2 != null)
        {
            transform.position = new Vector3(transform.position.x, personaje2.transform.position.y + 1.3f, transform.position.z);
        }

    }


	// Update is called once per frame
	void Update () {
        estaVivoPersonajeODentroDeCamara();

    }
}
