using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PongController
{
    [SerializeField] private BallController Ball;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(MovementDecider());
    }

    private IEnumerator MovementDecider()
    {
        float timer = 0f;

        while (true)
        {
            while (timer < 2f)
            {
                MoveTo(Ball.GetYPosition());
                timer += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.25f);
            timer = 0f;
        }
    }
    
    
}
