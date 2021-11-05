using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float jumpHeight;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private int jumpCount = 0;
    private int limitJumpCount = 1;

    private void Start()
    {
        audioSource.volume = SoundManager.I.Volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance == null)
        {
            return;
        }

        if (InputManager.Instance.IsJump)
        {
            if (jumpCount < limitJumpCount)
            {
                jumpCount = jumpCount + 1;
                rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            audioSource.clip = audioClip;
            audioSource.Play();

            EnemySaurus saurus = collision.gameObject.GetComponent<EnemySaurus>();
            saurus.OnDamage();
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "ground")
        {
            jumpCount = 0;
            InputManager.Instance.ClearJumpFlag();
        }
        Debug.Log("Enter");
    }
}