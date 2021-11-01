using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class which represents every event that could happen during a game between two teams
 * Author : DOMPEY Fabien
 * Date : 01/11/2021
 * Version : 0.1.0
 */
public abstract class Event : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private int _points;

    [SerializeField] private string _description;

    [SerializeField] private GameStage _gamestage;

    [SerializeField] private bool _succeeded;

    public string Name { get => _name; }
    public int Points { get => _points;  }
    public string Description { get => _description; }
    public GameStage Gamestage { get => _gamestage; }
    public bool Succeeded { get => _succeeded; }

    public Event(string name, int points,string description, GameStage gs)
    {
        if (!name.Equals(default) && points > 0 && points < 75 && !description.Equals(default) && !gs.Equals(null))
        {
            this._name = name;
            this._description = description;
            this._points = points;
            this._gamestage = gs;
            _succeeded = false;
        }
        else
        {
            throw new System.ArgumentException();
        }
    }
    public void Reset()
    {
        _succeeded = false;
    }

    public virtual void DoEvent(Team teamUser, Team teamTarget)
    {
        this.DoEvent(teamUser, teamTarget);
    }
}
