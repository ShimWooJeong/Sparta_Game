using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaurus : MonoBehaviour
{
    public Rigidbody2D rigid;
    public SpriteRenderer render;
    public float moveSpeed;
    bool isLeft = true;
    bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (isLeft){
            rigid.velocity = Vector2.left * moveSpeed;
            render.flipX = false;
        }
        else
        {
            rigid.velocity = Vector2.right * moveSpeed;
            render.flipX = true;
        }
    }
    //public은 외부에서 접근이 가능
    public void OnDamage()
    {
        BoxCollider2D col = gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false;
        render.color = new Color(1, 1, 1, 0.5f);
        rigid.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
        isDead = true;
    }
    //private는 외부에서 접근이 불가능, 내부에서만 사용 가능
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            isLeft = !isLeft; // 반대값 할당
        }
    }
}
