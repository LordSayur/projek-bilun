using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{    
    public void Pick(Item item)
    {
        if (item is IUsable)
        {
            IUsable useable = (IUsable)item;
            useable.Use(this);
        }
    }
}
