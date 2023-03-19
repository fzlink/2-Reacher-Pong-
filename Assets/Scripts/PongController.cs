using System;
using UnityEngine;

public abstract class PongController : MonoBehaviour
{
    [SerializeField] private float GoSpeed;
    [SerializeField] private float FollowSpeed;

    [SerializeField] private Collider2D Collider;

    private float maxY;
    private float minY;
    
    protected virtual void Start()
    {
        var margin = Collider.bounds.extents.y;
        var rect = Camera.main.rect;
        var max = Camera.main.ViewportToWorldPoint(rect.max);
        var min = Camera.main.ViewportToWorldPoint(rect.min);
        
        maxY = max.y - margin;
        minY = min.y + margin;
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

}
