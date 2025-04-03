using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [SerializeField] protected UnityEvent<Vector2> OnInput;
    [SerializeField] protected UnityEvent OnShoot;
    [SerializeField] protected UnityEvent OnEnemyShoot;
    [SerializeField] protected UnityEvent OnEnemyAttack;
    [SerializeField] protected UnityEvent OnThrowMachete;
}
