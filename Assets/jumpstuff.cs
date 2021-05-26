using UnityEngine;

public class jumpstuff : MonoBehaviour
{
    public Animator animator;
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
        
        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.01)
        {
            _rigidbody.AddForce(new Vector2(0,JumpForce), ForceMode2D.Impulse);
        }

    }
}
