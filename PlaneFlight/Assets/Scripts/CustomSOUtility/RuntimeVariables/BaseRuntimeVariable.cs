using System;
using UnityEngine;

public class BaseRuntimeVariable<T> : ScriptableObject, ISerializationCallbackReceiver
{
    public T InitialValue;
    
    public T RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }
}
