using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Region/Minor Region", fileName = "New Region")]
public class MinorRegion : Region
{
    public MinorRegion(string name, List<Competition> compet, Sprite logo) : base(name, compet, logo)
    {
    }
}
