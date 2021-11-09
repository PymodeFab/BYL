using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Region/Major Region", fileName = "New Region")]
public class MajorRegion : Region
{
    [SerializeField] private List<MinorRegion> _minors;
    public MajorRegion(string name, List<Competition> compet, Sprite logo,List<MinorRegion> reg) : base(name, compet, logo)
    {
        if (!reg.Equals(default))
        {
            this._minors = new List<MinorRegion>(reg);
        }
        else
        {
            throw new System.ArgumentException();
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        foreach(MinorRegion m in _minors)
        {
            m.Initialize();
        }
    }

    public List<MinorRegion> Minors { get => _minors;  }
}
