using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimerObject
{
    public float timer = 0f;

    public delegate void ExecutableAction();
    public ExecutableAction action;
}
