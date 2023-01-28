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
    IEnumerator Gethurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
