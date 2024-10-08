using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InitialGameData", menuName = "Player/Data", order = 1)]
public class InitialGameData : ScriptableObject
{
    [Header("PlayerInput")]
    public KeyCode jump0 = KeyCode.Space;
    public KeyCode jump1 = KeyCode.UpArrow;
    public KeyCode jump2 = KeyCode.W;
    public KeyCode pause = KeyCode.P;

    [Header("JumpHight")]
    public float jumpForce = 400f;

}
