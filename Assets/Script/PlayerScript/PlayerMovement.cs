using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 30f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] float stepSpeed = 5f;
    Rigidbody2D rb;
    Vector3 playerPos;
    float screenEdgeX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

        screenEdgeX = (Camera.main.orthographicSize * Camera.main.aspect) + 0.37f;

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (rb.linearVelocityY <= 0 && collision.GetContact(0).normal.y > 0.5f)
        {
            rb.linearVelocityY = jumpSpeed;
        }
    }


    void Update()
    {

        rb.linearVelocityX = Mathf.MoveTowards(rb.linearVelocityX, InputManager.Instance.direction.x * moveSpeed, stepSpeed);

        if (Mathf.Abs(transform.position.x) > screenEdgeX)
        {
            playerPos = rb.position;
            playerPos.x = playerPos.x > 0 ? -screenEdgeX : screenEdgeX;
            rb.position = playerPos;
        }
    }
}
