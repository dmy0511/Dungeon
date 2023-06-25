using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed = 2.0f;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    float hp = 5.0f;
    public Image[] hpImage;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        
        if(inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Big_Zombie")
        {
            hp -= 0.5f;
            HpImgUpdate();
            if (hp <= 0.0f) //사망처리
            {
                Die();
            }
        }

        //초록 물약을 사용하면 체력 1 회복
        //hp += 1.0f;
        //if (5.0f < hp)
        //    hp = 5.0f;
        //HpImgUpdate();
    }

    public void IncreaseSpeed()
    {
        speed += 0.2f;
    }

    void Die()
    {
        SceneManager.LoadScene("Gameover");
    }

    void HpImgUpdate()
    {
        float a_CacHp = 0.0f;
        for (int ii = 0; ii < hpImage.Length; ii++)
        {
            a_CacHp = hp - (float)ii;
            if (a_CacHp < 0.0f)
                a_CacHp = 0.0f;

            if (1.0f < a_CacHp)
                a_CacHp = 1.0f;

            if (0.45f < a_CacHp && a_CacHp < 0.55f)
                a_CacHp = 0.445f;

            hpImage[ii].fillAmount = a_CacHp;
        }
    }
}
