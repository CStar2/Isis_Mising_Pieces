using UnityEngine;

public class Doggie : MonoBehaviour
{
    [SerializeField] public Transform player;

    [SerializeField] private float distance;

    public Vector3 StartPoint;

    private Animator animator;

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        animator = GetComponent<Animator>();
        StartPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("distancia", distance);

    }

    public void rotate(Vector3 desired)
    {
        if (transform.position.x < desired.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }
}
