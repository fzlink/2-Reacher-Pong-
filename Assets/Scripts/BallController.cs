using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RB;
    
    [SerializeField] private float initThrowSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private InvisibilityDetector InvisibilityDetector;

    private Vector3[] initVectors = new Vector3[]
    {
        new Vector3(-1f,0.5f),
        Vector3.left,
        new Vector3(-1f, -0.5f),
        new Vector3(1f, 0.5f),
        Vector3.right,
        new Vector3(1f, -0.5f)
    };
    
    private void Start()
    {
        InvisibilityDetector.Detector_OnInvisible += RestartBall;
        Init();
    }

    private void Init()
    {
        transform.position = Vector3.zero;
        RB.velocity = Vector2.zero;
        var initDirection = initVectors[UnityEngine.Random.Range(0, initVectors.Length)].normalized;
        ThrowBall(initDirection, initThrowSpeed);
    }

    private void RestartBall()
    {
        Init();
    }

    public void ThrowBall(Vector2 direction, float speed)
    {
        RB.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (RB.velocity.magnitude > maxSpeed)
        {
            Vector3 velocity = RB.velocity.normalized * maxSpeed;
            RB.velocity = velocity;
        }
    }

    public float GetYPosition()
    {
        return RB.position.y;
    }
}
