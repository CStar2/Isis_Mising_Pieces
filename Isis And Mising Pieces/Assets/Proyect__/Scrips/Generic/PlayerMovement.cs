using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public Animator WalkAnimation;

    public void PlayerMove(Vector2 input)
    {
        transform.Translate(input.x * speed * Time.deltaTime, 0,
            0);
    }
}
