using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingEnemyController : MonoBehaviour
{

    private SpriteRenderer sr;
    public LayerMask WhoICanSee;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {

            // Do a raycast to know if I can directly see the player.
            Vector2 dir = other.transform.position - transform.position;
            float dist = Vector2.Distance(transform.position, other.transform.position);
            RaycastHit2D result = Physics2D.Raycast(transform.position, dir, dist, WhoICanSee);

            // If the raycast result is the same as the one entering the cone,
            // it means I have seen the player.
            if (result.collider == other)
                sr.color = new Color32(255, 180, 180, 255);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Ensure that the leaving object is the player,
        // otherwise other objects firing this function will affect my line of sight.
        if (other.name == "Player")
            sr.color = new Color32(255, 255, 255, 255);
    }
}
