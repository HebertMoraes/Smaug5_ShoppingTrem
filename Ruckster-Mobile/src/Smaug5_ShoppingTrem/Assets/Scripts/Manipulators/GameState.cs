using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum states{
        Running,
        Paused,
        GameOver    
    }
    public states currentState;
    
}
