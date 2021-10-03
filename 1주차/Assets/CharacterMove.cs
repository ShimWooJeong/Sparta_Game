using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D rigid;
    public float moveSpeed;

    void Update()
    {
        // 기본 방향은 0 입니다.
        // Vector2.zero 는 Vector2(0f, 0f) 와 같습니다
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 왼쪽 키를 누른 경우엔 왼쪽 즉 Vector2.left 로 이동합니다
            // Vector2.left 는 Vector2(-1f, 0f) 와 같습니다
            direction = Vector2.left * moveSpeed;
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right * moveSpeed;
        }
        rigid.velocity = direction;

    }
}
