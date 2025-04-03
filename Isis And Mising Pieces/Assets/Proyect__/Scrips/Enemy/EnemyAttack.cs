using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRadio;
    [SerializeField] private float Attackdamage;


    private void Attack()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(AttackController.position, AttackRadio);
        foreach (Collider2D collitions in objects)
        {
            if (collitions.CompareTag("Player"))
            {
                collitions.transform.GetComponent<Enemy>().GetDamage(Attackdamage);

            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackController.position, AttackRadio);
    }

}
