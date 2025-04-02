using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public Animator WalkAnimation;
    private GameObject player;
  


    public void Move(Vector2 input)
    {
        transform.Translate(input.x * speed * Time.deltaTime,
            input.y * speed * Time.deltaTime, 0);


    }

    private void rotate()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
  
}
