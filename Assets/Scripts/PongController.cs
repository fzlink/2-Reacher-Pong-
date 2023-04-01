using System;
using UnityEngine;

public abstract class PongController : MonoBehaviour
{
    [SerializeField] private float GoSpeed;
    [SerializeField] private float FollowSpeed;

    [SerializeField] private Collider2D Collider;

    private float maxY;
    private float minY;

    private float pongDivisionMargin;
    
    protected virtual void Start()
    {
        var margin = Collider.bounds.extents.y;
        var rect = Camera.main.rect;
        var max = Camera.main.ViewportToWorldPoint(rect.max);
        var min = Camera.main.ViewportToWorldPoint(rect.min);
        
        maxY = max.y - margin;
        minY = min.y + margin;
        pongDivisionMargin = Collider.bounds.size.y / 3;
    }

    protected void Move(Vector2? direction)
    {
        var speed = direction.Value.y * GoSpeed;
        transform.position += new Vector3(0, speed) * Time.deltaTime;
        ClampMovement();
    }

    protected void MoveTo(float yPosition)
    {
        transform.position = Vector2.Lerp((Vector2)transform.position, new Vector2(transform.position.x, yPosition),
            FollowSpeed * Time.deltaTime);
        ClampMovement();
    }

    private void ClampMovement()
    {
        var clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        var ball = collision.collider.gameObject.GetComponentInParent<BallController>();
        if (ball != null)
        {
            var point = collision.GetContact(0).point;
            var direction = point - (Vector2) transform.position;
            var xSign = direction.x < 0 ? -1f : 1f;
            if (point.y < transform.position.y - (pongDivisionMargin/2))
            {
                ball.ThrowBall(new Vector2(xSign, -1f), 10f);
                Debug.Log("Bottom Collision");
            }
            else if(point.y > transform.position.y + (pongDivisionMargin/2))
            {
                ball.ThrowBall(new Vector2(xSign, 1f), 10f);
                Debug.Log("Upper Collision");
            }
            else
            {
                ball.ThrowBall(direction, 10f);
                Debug.Log("Middle Collision");
            }
        }
    }
}
