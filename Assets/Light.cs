using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Light
{
    public Type Next { get; protected set; }
    abstract public Light Do(LightBrain brain);
}
