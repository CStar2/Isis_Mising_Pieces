using UnityEngine;

public class SethBattle : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform player;


    [SerializeField] private float distance;

    public Vector3 StartPoint;

    [SerializeField] private float Life;

    private EnemyAttack EnemyAttack;

    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRadio;
    [SerializeField] private float Attackdamage;

    // [SerializeField] private LifeBar lifebar;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("Distance", distance);

        Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, AttackRadio);
        foreach (Collider2D collitions in objects)
        {
            if (collitions.CompareTag("Player"))
            {
                collitions.transform.GetComponent<LifePlayer>().Playerdamage(Attackdamage);

            }
            
        }

    }

    public void GetDamage(float damage)
    {
        Life -= damage;
        

        if (Life <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
        }

    }

  

    //private void SeePlayer()
    //{
    //    if (player.position.x > transform.position.x && !Right) 
    //    {
    //        Right = !Right;
    //        transform.
    //    }
    //}
}
