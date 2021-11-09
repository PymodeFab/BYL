using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Region : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private List<Competition> _competitions;
    [SerializeField] private Sprite _logo;

    public Region(string name,List<Competition> compet,Sprite logo)
    {
        if(!name.Equals(default) && !compet.Equals(default) && !logo.Equals(default))
        {
            this._name = name;
            this._competitions = new List<Competition>(compet);
            this._logo = logo;
            Initialize();
        }
        else
        {
            throw new System.ArgumentException();
        }
    }

    public virtual void Initialize()
    {
        foreach(Competition c in _competitions)
        {
            c.Initialize();
        }
    }

    public string Name { get => _name; set => _name = value; }
    public List<Competition> Competitions { get => _competitions; set => _competitions = value; }
    public Sprite Logo { get => _logo; set => _logo = value; }
}
