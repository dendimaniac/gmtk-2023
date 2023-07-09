using System;
using UnityEngine;

public class PoliceCarMovement : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask roadObstaclesMask;
    [SerializeField] private float horizontalSpeed = 7f;
    [SerializeField] private float verticalSpeed = 10f;
    private float rayLength = 5f;

    private void Update()
    {
        var size = boxCollider.size;
        var left = transform.position + new Vector3(-size.x / 2, size.y / 2);
        var middle = transform.position + new Vector3(0, size.y / 2);
        var right = transform.position + new Vector3(size.x / 2, size.y / 2);

        var leftHit = Physics2D.Raycast(left, Vector2.up, rayLength, roadObstaclesMask);
        var middleHit = Physics2D.Raycast(middle, Vector2.up, rayLength, roadObstaclesMask);
        var rightHit = Physics2D.Raycast(right, Vector2.up, rayLength, roadObstaclesMask);

        float moveX = 0;
        if (middleHit)
        {
            moveX = 1;
        }
        if (leftHit && middleHit && rightHit)
        {
            moveX = 1;
        }
        else if (leftHit && middleHit)
        {
            moveX = 1;
        }
        else if (rightHit && middleHit)
        {
            moveX = -1;
        }
        else if (leftHit)
        {
            moveX = 1;
        }
        else if (rightHit)
        {
            moveX = -1;
        }
        else
        {
            var robber = FindObjectOfType<RobberMovement>();
            if (robber != null)
            {
                float distanceApart = robber.transform.position.x - transform.position.x;
                moveX = 0.1f*distanceApart;
            }
        }

        var movement = Time.deltaTime * (horizontalSpeed * new Vector3(moveX, 0, 0f).normalized + verticalSpeed * Vector3.up);
        transform.position += movement;
    }

    private void OnDrawGizmos()
    {
        var size = boxCollider.size;
        var left = transform.position + new Vector3(-size.x / 2, size.y / 2);
        var middle = transform.position + new Vector3(0, size.y / 2);
        var right = transform.position + new Vector3(size.x / 2, size.y / 2);
        
        Gizmos.color = Color.black;
        Gizmos.DrawLine(left, left + new Vector3(0, rayLength));
        Gizmos.DrawLine(middle, middle + new Vector3(0, rayLength));
        Gizmos.DrawLine(right, right + new Vector3(0, rayLength));
    }
}