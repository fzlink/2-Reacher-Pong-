using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlacer : MonoBehaviour
{
    [SerializeField] private Transform LeftPong;
    [SerializeField] private Transform RightPong;

    private void Awake()
    {
        PlacePongs();
    }

    private void PlacePongs()
    {
        var camera = Camera.main;
        var cameraRect = camera.rect;
        var max = cameraRect.max;
        var min = cameraRect.min;
        
        max = camera.ViewportToWorldPoint(max);
        min = camera.ViewportToWorldPoint(min);
        
        var leftPongCollider = LeftPong.GetComponentInChildren<Collider2D>();
        var rightPongCollider = RightPong.GetComponentInChildren<Collider2D>();

        var leftPongWidth = leftPongCollider.bounds.extents.x;
        var rightPongWidth = rightPongCollider.bounds.extents.x;

        LeftPong.transform.position = new Vector2 (min.x + leftPongWidth, 0);
        RightPong.transform.position = new Vector2 (max.x - rightPongWidth, 0);
    }
}
