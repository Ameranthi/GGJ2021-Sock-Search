using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1;
    public float jumpForce = 1;

    private Rigidbody2D _rigidbody2D;
    public int counter = 0;

    public int startHealth = 3;

    private void Start()
    {
       _rigidbody2D = GetComponent<Rigidbody2D>();
       PlayerStats.HealthStats = startHealth;
       print(PlayerStats.HealthStats.ToString());

    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
	    transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Socks"))
        {
            Destroy(collision.gameObject);

            PlayerStats.Points++;
            counter = PlayerStats.Points;

            print(PlayerStats.Points.ToString());
        }
        else if (collision.CompareTag("Level2"))
        {
            SceneManager.LoadScene("Level2");
        }
        else if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Win");
        }
        else if (collision.CompareTag(("Enemy")))
        {
            PlayerStats.HealthStats--;
            print(PlayerStats.HealthStats.ToString());
            if (PlayerStats.HealthStats == 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
}
