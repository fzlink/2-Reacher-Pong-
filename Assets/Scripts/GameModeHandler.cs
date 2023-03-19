using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeHandler : MonoBehaviour
{
    public enum InputType
    {
        MouseAxis = 0,
        Keyboard = 1,
        MouseAndKeyboard = 2
    }


    [SerializeField] private InputType inputType;

    public InputType GetInputType()
    {
        return inputType;
    }
    
    
    
}
