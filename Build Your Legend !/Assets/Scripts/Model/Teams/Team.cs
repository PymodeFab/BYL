using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Team class representing every team available in the game
 * Author : DOMPEY Fabien
 * Date : 05/10/2021
 * Version : 0.1.0
 * 
 */
[CreateAssetMenu(fileName ="New Team",menuName ="Team")]
public class Team : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private Nationality _nat;

    [SerializeField] private int _funds;

    [SerializeField] private int _salaryFunds;

    [SerializeField]  private List<Individual> recruits;

    private List<Player> _activeTeam;

    private List<Event> _eventsChosen;

    public string Name { get => _name; set => _name = value; }
    public Nationality Nat { get => _nat; set => _nat = value; }
    public int Funds { get => _funds; set => _funds = value; }
    public int SalaryFunds { get => _salaryFunds; set => _salaryFunds = value; }
    public List<Player> ActiveTeam { get => new List<Player>(_activeTeam);}
    public List<Event> EventsChosen { get => new List<Event>(_eventsChosen); set => _eventsChosen = value; }

    public Team(string name,Nationality nat, int funds, int salaryFunds)
    {
        if(!name.Equals(null) && !nat.Equals(null) && funds > 1 && salaryFunds > 1)
        {
            this._name = name;
            this._nat = nat;
            this._funds = funds;
            this._salaryFunds = salaryFunds;
            recruits = new List<Individual>();
            _activeTeam = new List<Player>();
            Initialize();
        }
        else
        {
            throw new System.ArgumentException("Illegal Arguments");
        }
    }

    public void Initialize()
    {
        _eventsChosen = new List<Event>();
        foreach(Player p in GetPlayers())
        {
            p.Initialize();
        }
    }

    public void Recruit(Individual i)
    {
        if(!recruits.Contains(i) && recruits.Count < 11 && (!(i is Coach) || (i is Coach && NoCoach())))
        {
            recruits.Add(i);
        }
    }

    private bool NoCoach()
    {
        foreach(Individual i in recruits)
        {
            if(i is Coach)
            {
                return false;
            }
        }
        return true;
    }

    /*
* Method to get access to all players recruited in the team
* can return an empty list
*/
    public List<Player> GetPlayers()
    {
        List<Player> players = new List<Player>();
        foreach(Individual i in recruits)
        {
            if(i is Player)
            {
                players.Add((Player)i);
            }
        }
        return players;
    }
    /*
     * Method to get access to the coach recruited in the team
     * Can return null
     */
    public Coach GetCoach()
    {
        Coach c = null;
        foreach(Individual i in recruits)
        {
            if(i is Coach)
            {
                c = (Coach)i;
            }
        }
        return c;
    }

    public void SetPlayerMainTeam(Player p)
    {
        if (recruits.Contains(p))
        {
            if(!_activeTeam.Find(x => x.Role == p.Role).Equals(null))
            {
                _activeTeam.Remove(_activeTeam.Find(x => x.Role == p.Role));
            }
            if(_activeTeam.Count < 5)
            {
                _activeTeam.Add(p);
            }
        }
    }

    public Player GetPlayerByRole(PlayerRole p)
    {
        return _activeTeam.Find(x => x.Role == p);
    }

    public List<Player> GetPlayersByRoles(List<PlayerRole> roles)
    {
        List<Player> players = new List<Player>();
        Player tmp;
        foreach(PlayerRole pr in roles)
        {
            tmp = players.Find(x => x.Role == pr);
            if (!tmp.Equals(null))
            {
                players.Add(tmp);
            }
        }
        return players;
    }

    /*
     * Method to calculate the synergy of the team
     * The synergy represents bonus points given to the team during the game
     * TODO : Determine how
     * Up to 10 points given
     * Marks/10
     */
    public int Synergy()
    {
        int syn = 0;
        return syn;
    }
}
