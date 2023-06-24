using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; //속도
    public float attackRange; //공격범위(1.5당 1칸)
    public Rigidbody2D target; //목표

    private Rigidbody2D rigid;
    private SpriteRenderer spriter;
    private Vector2 originalPosition;   //원래 자리로 돌아가게

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        originalPosition = rigid.position;
    }

    void FixedUpdate()
    {
        Vector2 dirVec = target.position - rigid.position;

        if (dirVec.magnitude <= attackRange)
        {
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector2.zero;
        }
        else
        {
            Vector2 returnVec = originalPosition - rigid.position;
            Vector2 nextVec = returnVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector2.zero;
        }
    }

    void LateUpdate()
    {
        if (Vector2.Distance(target.position, rigid.position) <= attackRange)
        {
            spriter.flipX = target.position.x < rigid.position.x;
        }
    }
}

