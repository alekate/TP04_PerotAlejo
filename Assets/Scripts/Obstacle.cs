using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 7f;
    private float leftBoundary = -10f;
    private float rightSpawnX = 10f;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < leftBoundary)
        {
            gameObject.SetActive(false);
        }

        if (player.GetComponent<PlayerController>().isDead == true)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 7;
        }
        
    }

    public void Reposition(Vector3 newPosition)
    {
        transform.position = newPosition;
        gameObject.SetActive(true);
    }
}