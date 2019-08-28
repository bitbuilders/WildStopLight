using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightColor
{
    GREEN = 0,
    YELLOW = 1,
    RED = 2
}

public interface LightFollower
{
    void ReactToColor(LightColor lightColor, float percent = -1.0f);
}
