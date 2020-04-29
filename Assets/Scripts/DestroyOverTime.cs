using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    public float lifeTime;  //How long the obejct lasts for

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Count down from lifeTime to 0
        lifeTime = lifeTime - Time.deltaTime;

        //When it gets to 0, delete the obejct from the world
        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }

        //Debug.Log(Time.deltaTime);
    }
}
