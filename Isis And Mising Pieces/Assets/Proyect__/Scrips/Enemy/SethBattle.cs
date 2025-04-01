using UnityEngine;

public class SethBattle : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform jugador;



    [SerializeField] private float Life;

    // [SerializeField] private LifeBar lifebar;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;

        if (Life <= 0)
        {
            animator.SetTrigger("Death");
            Death();
        }

    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
