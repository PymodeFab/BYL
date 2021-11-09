using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Competition",fileName ="New Competition")]
public class Competition : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private List<Team> _teams;
    [SerializeField] private Sprite _logo;

    public Competition(string name,List<Team> t,Sprite logo)
    {
        if(!name.Equals(default) && !t.Equals(default) && !logo.Equals(default))
        {
            this._name = name;
            this._teams = new List<Team>(t);
            this._logo = logo;
            Initialize();
        }
        else
        {
            throw new System.ArgumentException();
        }
    }

    public string Name { get => _name; set => _name = value; }
    public List<Team> Teams { get => _teams; }
    public Sprite Logo { get => _logo; set => _logo = value; }

    public void Initialize()
    {
        foreach(Team t in _teams)
        {
            t.Initialize();
        }
    }

}