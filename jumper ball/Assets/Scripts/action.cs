using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action : MonoBehaviour {

    private SpriteRenderer ground;
    private float currentTime;
    private float posX;
    private float posY;
    private float posZ;
    private float tiempoReaparicion;

    // Use this for initialization
    void Start() {
        ground = gameObject.GetComponent<SpriteRenderer>();
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ground.name == "lazyGround")
        {
            StartCoroutine(TirarLazyGround(ground));
        }
    }



    IEnumerator TirarLazyGround(SpriteRenderer ground)
    {
        while (currentTime < 2.5f)
        {
            yield return new WaitForSeconds(0.1f);
            currentTime += 0.1f;
        }
        transform.position = new Vector3(posX + 70f, posY, posZ);
        StartCoroutine(ReaparecerLazyGround());
    }


    IEnumerator ReaparecerLazyGround()
    {
        while (tiempoReaparicion < 1.5f)
        {
            yield return new WaitForSeconds(0.1f);
            tiempoReaparicion += 0.1f;
        }
        transform.position = new Vector3(posX, posY, posZ);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
