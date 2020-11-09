using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectStates : ScriptableObject
{
    public List<ObjectData> ObjectStatesList = new List<ObjectData>();
}

[System.Serializable]
public class ObjectData
{
    public string Name = string.Empty;
    public int Hp = 0;
}
