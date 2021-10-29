using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float jumpHeight;

    public AudioSource audioSource;
    public AudioClip clip;


    public int cnt; // 점프 횟수

    bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && cnt < 2) //점프를 두 번 이상 하지 못 하게 조건을 걸음
        {
            //GetKey는 업데이트 문에 계속 들어옴, 키를 입력할 때 꾸욱 누르고 있으면 계속 true를 반환
            //GetKeyDown은 키가 입력을 받을 때 true, 눌러져 있을 떄는 false를 반환
            cnt += 1; // 점프를 했을 떄 점프 횟수 추가
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            audioSource.clip = clip;
            audioSource.Play();
            audioSource.volume = SoundManager.I.Volume;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            cnt = 0;
        }else if(other.gameObject.tag == "enemy")
        {
            EnemySaurus enemy = other.gameObject.GetComponent<EnemySaurus>();
            enemy.OnDamage();
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

    }
}
