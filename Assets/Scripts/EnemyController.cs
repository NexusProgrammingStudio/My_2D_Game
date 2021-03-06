using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool mustPatrol;
    public Rigidbody2D rb;
    public float WalkSpeed;
    public Transform groundCheckPos;
    private bool mustTurn;
    public LayerMask groundLayer;

    void Start()
    {
        mustPatrol = true;
        WalkSpeed = 200f;

    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
	{
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector3(WalkSpeed * Time.fixedDeltaTime,0 ,0);
	}

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        WalkSpeed *= -1;
        mustPatrol = true;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
}
