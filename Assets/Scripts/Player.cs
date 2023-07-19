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

    float hp = 3.0f;
    public Image[] hpImage;
    
    private bool isColliding = false;
    private float collisionTimer = 0.0f;
    private float collisionInterval = 0.5f;

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
        if (collision.gameObject.CompareTag("Big_Zombie"))
        {
            if (!isColliding)
            {
                hp -= 0.5f;
                HpImgUpdate();
                if (hp <= 0.0f)
                {
                    Die();
                }
                isColliding = true;
            }
        }
        else if (collision.gameObject.CompareTag("Big_Demon"))
        {
            if (!isColliding)
            {
                hp -= 1.0f;
                HpImgUpdate();
                if (hp <= 0.0f)
                {
                    Die();
                }
                isColliding = true;
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Big_Zombie"))
        {
            collisionTimer += Time.deltaTime;
            if (collisionTimer >= collisionInterval)
            {
                hp -= 0.5f;
                HpImgUpdate();
                if (hp <= 0.0f)
                {
                    Die();
                }
                collisionTimer = 0.0f;
            }
        }
        else if (collision.gameObject.CompareTag("Big_Demon"))
        {
            collisionTimer += Time.deltaTime;
            if (collisionTimer >= collisionInterval)
            {
                hp -= 1.0f;
                HpImgUpdate();
                if (hp <= 0.0f)
                {
                    Die();
                }
                collisionTimer = 0.0f;
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Big_Zombie"))
        {
            isColliding = false;
            collisionTimer = 0.0f;
        }
        else if (collision.gameObject.CompareTag("Big_Demon"))
        {
            isColliding = false;
            collisionTimer = 0.0f;
        }
    }

    public void IncreaseSpeed()
    {
        speed += 0.2f;
    }

    public void HealHp()
    {
        hp += 1.0f;
        if (3.0f < hp)
            hp = 3.0f;
        HpImgUpdate();
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
