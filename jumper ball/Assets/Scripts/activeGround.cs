using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class activeGround : MonoBehaviour {

    private float posX;
    private float posY;
    private float posZ;
    private float currentTime; 
    
    // Use this for initialization
    void Start() {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
	}

    private void MoveGround()
    {
        transform.position = new Vector2(this.transform.position.x + 2.5f * Time.deltaTime, this.transform.position.y);
        
        if (transform.position.x > posX + 25f)
        {
            transform.position = new Vector3(posX, posY, posZ);
        }
    }


    // Update is called once per frame
    void Update () {
        MoveGround();
    }
}
