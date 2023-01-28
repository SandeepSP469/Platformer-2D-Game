using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform[] patrolpoints;
    public float movespeed;
    public int patroldestination;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
            playercontroller.KillPlayer();
        }
    }

    private void Update()
    {
        if(patroldestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[0].position, movespeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolpoints[0].position) < 0.2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                patroldestination = 1;
            }
        }

        if (patroldestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[1].position, movespeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolpoints[1].position) < 0.2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                patroldestination = 0;
            }
        }
    }
}
