using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Rigidbody2D rigid;
    public SpriteRenderer render;
    public Transform trans;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(InputManager.Instance.Movement.x, 0).normalized;

        if (direction.x < 0f)
        {
            // 왼쪽 키를 누른 경우엔 왼쪽 즉 Vector2.left 로 이동합니다
            // Vector2.left 는 Vector2(-1f, 0f) 와 같습니다
            direction = Vector2.left * moveSpeed;
            render.flipX = true;
        }
        else if (direction.x > 0f)
        {
            direction = Vector2.right * moveSpeed;
            render.flipX = false;
        }
        direction.y = rigid.velocity.y;
        rigid.velocity = direction;

    }
}