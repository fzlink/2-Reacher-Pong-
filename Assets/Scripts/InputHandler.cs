using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public enum Player
    {
        Player1,
        Player2
    }
    
    [SerializeField] private GameModeHandler GameModeHandler;

    private Action InputChecker;
    public Action<Player,PongMovement> InputTriggered;

    [SerializeField] private KeyboardInput Player1Controls;
    [SerializeField] private KeyboardInput Player2Controls;

    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main;
        
        switch (GameModeHandler.GetInputType())
        {
            case GameModeHandler.InputType.Keyboard:
                InputChecker = CheckKeyboardKey;
                break;
            case GameModeHandler.InputType.MouseAxis:
                InputChecker = CheckMouseAxis;
                break;
            case GameModeHandler.InputType.MouseAndKeyboard:
                InputChecker += CheckKeyboardKey;
                InputChecker += CheckMouseAxis;
                break;
        }
    }

    void Update()
    {
        InputChecker?.Invoke();
    }

    private void CheckMouseAxis()
    {
        if (Input.GetMouseButton(0))
        {
            var y = _camera.ScreenToWorldPoint(Input.mousePosition).y;
            InputTriggered(Player.Player1, new PongMovement(y));
        }
    }

    private void CheckKeyboardKey()
    {
        var player1Up = Input.GetKey(Player1Controls.Up);
        var player2Up = Input.GetKey(Player2Controls.Up);
        var player1Down = Input.GetKey(Player1Controls.Down);
        var player2Down = Input.GetKey(Player2Controls.Down);

        if (player1Up)
        {
            InputTriggered(Player.Player1, new PongMovement(Vector2.up));
        }
        else if (player1Down)
        {
            InputTriggered(Player.Player1, new PongMovement(Vector2.down));
        }

        if (player2Up)
        {
            InputTriggered(Player.Player2, new PongMovement(Vector2.up));
        }
        else if (player2Down)
        {
            InputTriggered(Player.Player2, new PongMovement(Vector2.down));
        }
    }

    [Serializable]
    private class KeyboardInput
    {
        public KeyCode Up;
        public KeyCode Down;
    }

    public class PongMovement
    {
        public float ToYPosition;
        public Vector2? Direction;

        public PongMovement(float toYPosition)
        {
            ToYPosition = toYPosition;
            Direction = null;
        }

        public PongMovement(Vector2 direction)
        {
            Direction = direction;
        }
    }
}
