using UnityEngine;

public class PlayerInputHandler : InputHandler
{
    private void Update()
    {
        OnInput?.Invoke(new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        //Fire1 es el click del mouse
        if (Input.GetButtonDown("Fire1"))
        {
            OnShoot?.Invoke();
            Debug.Log("Shoot1. Desde el jugador");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            OnThrowMachete?.Invoke();
           
        }
        

    }
}
