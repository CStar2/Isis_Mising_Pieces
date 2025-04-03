using UnityEngine;

public class PlayerInputHandler : InputHandler
{
    private void Update()
    {
        OnInput?.Invoke(new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        //Fire1 es el click del mouse
        if (Input.GetKey(KeyCode.Space))
        {
            OnShoot?.Invoke();
            Debug.Log("Spell. Desde el jugador");
        }
        
        

    }
}
