using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New roles dico", menuName = "Dictionary/Roles")]
public class RolesDictionary : ScriptableObject
{
    public List<PlayerRole> roles;
    public List<Sprite> sprites;

    public Sprite GetSpriteFromRole(PlayerRole p)
    {
        return sprites[roles.FindIndex(x => x == p)];
    }
}
