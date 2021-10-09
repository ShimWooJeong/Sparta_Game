using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    public BoxCollider2D col1;
    public BoxCollider2D col2;
    public SpriteRenderer render;

    void OnDamage()
    {
        col1.enabled = false;
        col2.enabled = false;//enavled => 컴포넌트의 체크 박스
        render.color = new Color(1, 1, 1, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            OnDamage();
        }
    }
}
