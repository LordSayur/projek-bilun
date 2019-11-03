using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "ItemData", menuName = "ItemData" )]
public class ItemData : ScriptableObject
{
    public AttributeType attributeType = AttributeType.None;
    public TargetType targetType = TargetType.Self;
    public float changeValue = 0f;
    public float duration = 0f;
}

public enum AttributeType
{
    None,
    Speed,
    Invert
}

public enum TargetType
{
    Self,
    All,
    AllExceptSelf
}
