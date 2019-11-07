using UnityEngine;

public class Boy : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(1, 100)]
    public int jump = 5;
    Rigidbody Rb;      //剛體
    AudioSource Audio; //音效
    bool IsGround = true;//是否在地面上
    private void Update()
    {
        Move();
        Rb = GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    public void Jump()
    {
        if (IsGround == true)//在地面上才能跳躍
        {
            Rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            Audio.Play();
            IsGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "地板")
        {
            print("地面上");
            IsGround = true;
        }
    }
}
