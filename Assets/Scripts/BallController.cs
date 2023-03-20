using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RB;
    
    [SerializeField] private float initThrowSpeed;
    
    private void Start()
    {
        var initDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-0.25f, 0.25f)).normalized;
        ThrowBall(initDirection, initThrowSpeed);
    }

    private void ThrowBall(Vector2 direction, float speed)
    {
        RB.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    public float GetYPosition()
    {
        return RB.position.y;
    }
}
