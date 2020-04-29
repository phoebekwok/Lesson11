using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform leftPoint;
    public Transform rightPoint;

    public float moveSpeed;

    private Rigidbody2D enemyRigidbody;

    public bool movingRight;

    // Use this for initialization
    void Start () {
        enemyRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight && (transform.position.x > rightPoint.position.x))
        {
            movingRight = false;
        }

        if (!movingRight && (transform.position.x < leftPoint.position.x))
        {
            movingRight = true;
        }

        if (movingRight)
        {
            enemyRigidbody.velocity = new Vector2(moveSpeed, enemyRigidbody.velocity.y);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(-moveSpeed, enemyRigidbody.velocity.y);
        }
    }
}
