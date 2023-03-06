using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private Transform UpperWall;
    [SerializeField] private Transform LowerWall;
    
    private void Start()
    {
        var camera = Camera.main;
        var cameraRect = camera.rect;
        var max = cameraRect.max;
        var min = cameraRect.min;

        var upperWallCollider = UpperWall.GetComponent<Collider2D>();
        var lowerWallCollider = LowerWall.GetComponent<Collider2D>();

        var upperColliderHeight = upperWallCollider.bounds.extents.y;
        var lowerColliderHeight = lowerWallCollider.bounds.extents.y;
        
        max = camera.ViewportToWorldPoint(max);
        min = camera.ViewportToWorldPoint(min);
        UpperWall.localScale = new Vector2(max.x - min.x, UpperWall.localScale.y);
        LowerWall.localScale = new Vector2(max.x - min.x, LowerWall.localScale.y);

        UpperWall.position = new Vector2(0, max.y + upperColliderHeight);
        LowerWall.position = new Vector2(0, min.y - lowerColliderHeight);
    }
}
