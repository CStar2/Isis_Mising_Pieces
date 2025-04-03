using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [SerializeField] protected UnityEvent<Vector2> OnInput;
    [SerializeField] protected UnityEvent OnShoot;
  
}
