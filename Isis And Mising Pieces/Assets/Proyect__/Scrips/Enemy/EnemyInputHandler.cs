using UnityEngine;
using UnityEngine.Windows;

public class EnemyInputHandler : InputHandler
{
    [SerializeField] private Vector2 input;
    private Vector2 check = Vector2.down;
    private void Update()
    {
        OnInput?.Invoke(input);
        if(input == check)
        {
            OnShoot?.Invoke();
        }
       
        
    }
}
