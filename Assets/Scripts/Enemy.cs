using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; //�ӵ�
    public float attackRange; //���ݹ���(1.5�� 1ĭ)
    public Rigidbody2D target; //��ǥ

    private Rigidbody2D rigid;
    private SpriteRenderer spriter;
    private Vector2 originalPosition;   //���� �ڸ��� ���ư���

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

