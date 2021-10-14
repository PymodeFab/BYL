using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Database<T> : ScriptableObject
{
    public List<T> data;
}
