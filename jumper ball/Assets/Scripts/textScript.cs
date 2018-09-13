using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour {

    public static int pointScore;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}

    void Update()
    {
        text.text = "SCORE :" + pointScore;
    }


}
