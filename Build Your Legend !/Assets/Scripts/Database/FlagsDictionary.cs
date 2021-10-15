using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New flag dico",menuName ="Dictionary/Flags")]
public class FlagsDictionary : ScriptableObject
{
    public List<Nationality> nationalities;
    public List<Sprite> sprites;

    public Sprite GetSpriteFromNationality(Nationality n)
    {
        return sprites[nationalities.FindIndex(x => x == n)];
    }
}
