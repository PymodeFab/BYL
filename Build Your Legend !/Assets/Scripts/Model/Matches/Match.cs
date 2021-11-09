using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Class representing every match between two teams in any competition
 * Author : DOMPEY Fabien
 * Date : 08/11/2021
 * Version : 0.1.0
 */
public abstract class Match
{
    protected string _name;
    protected Team _team1;
    protected Team _team2;
    protected List<Event> _poolEvents;
    protected GameState _state;
    protected int _pointsT1;
    protected int _pointsT2;
    protected List<Event> _eventsDrawn;
    protected Dictionary<Event, Team> _results;

    public Team Team1 { get => _team1;}

    public Team Team2 { get => _team2; }

    public List<Event> GameEvents { get => _poolEvents; }

    public GameState GameState { get => _state; set => _state = value; }

    public int PointsTeam1 { get => _pointsT1; }

    public int PointsTeam2 { get => _pointsT2; }

    public Match(Team t1,Team t2)
    {
        if(!t1.Equals(null) && !t2.Equals(null) && NoCommonEvents(t1,t2))
        {
            this._name = t1.Name + " VS " + t2.Name;
            this._team1 = t1;
            this._team2 = t2;
            Reset();
        }
        else
        {
            throw new System.ArgumentException();
        }
    }

    private bool NoCommonEvents(Team t1, Team t2)
    {
        foreach (Event e in t1.EventsChosen)
        {
            if (t2.EventsChosen.Contains(e))
            {
                return false;
            }
        }
        foreach(Event e in t2.EventsChosen)
        {
            if (t1.EventsChosen.Contains(e))
            {
                return false;
            }
        }
            return true;
        
    }

    protected void Reset()
    {
        this._poolEvents = EventsManager.GenerateEvents(_team1.EventsChosen, _team2.EventsChosen);
        this._eventsDrawn = new List<Event>();
        _state = GameState.GENERATING_EVENTS;
        _pointsT1 = _team1.Synergy();
        _pointsT2 = _team2.Synergy();
    }

    public virtual Team GenerateMatch()
    {
        Event e = null;
        Team t = null;
        while(_pointsT1 < 50 && _pointsT2 < 50)
        {
            e = _poolEvents[UnityEngine.Random.Range(0, _poolEvents.Count)];
            _eventsDrawn.Add(e);
            t = GetTeamForEvent(e);
            t = t.Equals(_team2) ? e.DoEvent(t, _team1) : e.DoEvent(t, _team2);

            if (t.Equals(_team1))
            {
                _pointsT1 += e.Points;
            }
            else
            {
                _pointsT2 += e.Points;
            }
        }
        _state = GameState.PRINTING_RESULTS;
        return _pointsT1 >= 50 ? _team1 : _team2;
    }

    private Team GetTeamForEvent(Event e)
    {
        if (_team1.EventsChosen.Contains(e))
        {
            return _team1;
        }
        else if(_team2.EventsChosen.Contains(e))
        {
            return _team2;
        }
        else
        {
            return _pointsT1 > _pointsT2 ? _team1 : _team2;
        }
    }
}
