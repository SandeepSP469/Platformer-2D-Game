using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytwo : MonoBehaviour
{
    public Transform[] patrolpoints;
    public float movespeed;
    public int patroldestination;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
                playercontroller.KillPlayer();
            }
            else
            {
                StartCoroutine(Gethurt());
            }
        }
    }

    private void Update()
    {
        if(patroldestination == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[2].position, movespeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolpoints[2].position) < 0.2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                patroldestination = 3;
            }
        }

        if (patroldestination == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[3].position, movespeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolpoints[3].position) < 0.2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                patroldestination = 2;
            }
        }
    }
    IEnumerator Gethurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
