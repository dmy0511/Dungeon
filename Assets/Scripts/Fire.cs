using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float range = 10.0f;
    public float pushForce = 10.0f;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Big_Zombie"))
            {
                Vector2 awayDirection = collider.transform.position - transform.position;
                Vector2 pushVector = awayDirection.normalized * pushForce;
                collider.transform.Translate(pushVector * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
