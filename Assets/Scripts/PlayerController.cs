using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : PongController
{
    [SerializeField] private InputHandler InputHandler;
    protected override void Start()
    {
        base.Start();
        InputHandler.InputTriggered += InputHandler_InputTriggered;
    }

    private void InputHandler_InputTriggered(InputHandler.Player playerType, InputHandler.PongMovement movement)
    {
        if (movement.Direction != null)
            Move(movement.Direction);
        else
            MoveTo(movement.ToYPosition);
    }
}
