using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    public float baseMoveSpeed = 5f;

    public float BoxColliderOffset => boxCollider.size.y / 2;
    private float _currentSpeed;

    private void Awake()
    {
        _currentSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        var position = transform.position;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = Time.deltaTime * _currentSpeed * new Vector3(moveX, moveY, 0f).normalized;
        var movementPosition = position + movement;
        transform.position = movementPosition;
    }

    public void UpdateSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        _currentSpeed = baseMoveSpeed;
    }
}
