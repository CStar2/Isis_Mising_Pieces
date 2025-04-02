using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRadio;
    [SerializeField] private float Attackdamage;

   

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

    }

    private void Attack()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, AttackRadio);
        foreach (Collider2D collitions in objects)
        {
            if (collitions.CompareTag("Enemy"))
            {
                collitions.transform.GetComponent<Enemy>().GetDamage(Attackdamage);
            }
        }

    }

   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackController.position, AttackRadio);
    }
}
