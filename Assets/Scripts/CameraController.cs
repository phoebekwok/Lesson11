﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;   // the object that the camera will follow
    public float followAhead;

    private Vector3 targetPosition;

    public float smoothing;

    public bool followTarget;   //Whether following our target or not

	// Use this for initialization
	void Start () {
        followTarget = true;    //At the start of the game, camera follows player
    }
	
	// Update is called once per frame
	void Update () {
        if (followTarget)
        {
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

            // this moves the camera to ahead of the player
            if (target.transform.localScale.x > 0.0f)
            {
                targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
            }
            else
            {
                targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
            }

            // transform.position = targetPosition;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
	}
}
