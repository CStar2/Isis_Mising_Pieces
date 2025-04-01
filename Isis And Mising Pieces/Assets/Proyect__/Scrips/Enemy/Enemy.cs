using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Life;

    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void GetDamage(float damage)
    {
        Life -= damage;
        Animator.SetTrigger("Damage");

        if (Life <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Animator.SetTrigger("Death");
        Destroy(gameObject);
    }
}
