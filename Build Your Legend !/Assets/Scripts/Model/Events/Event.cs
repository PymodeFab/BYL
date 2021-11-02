using System;
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

    [SerializeField] private List<PlayerRole> _targetsRoles;

    private EventState _state;

    // Getters
    public string Name { get => _name; }
    public int Points { get => _points;  }
    public string Description { get => _description; }
    public GameStage Gamestage { get => _gamestage; }
    public EventState State { get => _state; }
    public List<PlayerRole> TargetsRoles { get => new List<PlayerRole>(_targetsRoles);}

    public Event(string name, int points,string description, GameStage gs, List<PlayerRole> roles)
    {
        if (!name.Equals(default) && !roles.Equals(default) && points > 0 && points < 75 && !description.Equals(default) && !gs.Equals(null))
        {
            this._name = name;
            this._description = description;
            this._points = points;
            this._gamestage = gs;
            this._targetsRoles = new List<PlayerRole>(roles);
            Initialize();
        }
        else
        {
            throw new System.ArgumentException();
        }
    }

    //Reset the event
    public void Initialize()
    {
        _state = EventState.READY;
    }

    //The event is run but it does his own thing by asking his children to do it instead. Change the state of the event
    public void DoEvent(Team user, Team target,List<Event> pool)
    {
        _state = this.RollEvent(user,target,pool) ? EventState.SUCCEEDED : EventState.FAILED;
    }

    protected abstract bool RollEvent(Team user, Team target, List<Event> pool);
}
