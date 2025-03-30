using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public Animator WalkAnimation;

    public void Move(Vector2 input)
    {
        transform.Translate(input.x * speed * Time.deltaTime,
            input.y * speed * Time.deltaTime, 0);
    }
}
