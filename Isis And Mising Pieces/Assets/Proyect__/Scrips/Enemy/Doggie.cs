using UnityEngine;

public class Doggie : MonoBehaviour
{
    [SerializeField] public Transform player;

    [SerializeField] private float distance;

    public Vector3 StartPoint;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRadio;
    [SerializeField] private float Attackdamage;


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

        Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, AttackRadio);
        foreach (Collider2D collitions in objects)
        {
            if (collitions.CompareTag("Player"))
            {
                collitions.transform.GetComponent<LifePlayer>().Playerdamage(Attackdamage);

            }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackController.position, AttackRadio);
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
