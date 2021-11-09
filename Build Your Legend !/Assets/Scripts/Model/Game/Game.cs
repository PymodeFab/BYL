using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Each game created by the real player behind the screen
 * Author : DOMPEY Fabien
 * Date : 09/11/2021
 * Version : 0.1.0
 */
public class Game
{
    private User _user;
    private Difficulty _diff;
    private List<MajorRegion> _data;
    private List<Player> _freeAgents;

    public Game(User u,Difficulty diff,List<MajorRegion> data,List<Player> agents)
    {
        if(!u.Equals(default) && !data.Equals(default) && !agents.Equals(default))
        {
            this._user = u;
            this._diff = diff;
            this._data = new List<MajorRegion>(data);
            this._freeAgents = new List<Player>(agents);
        }
        else
        {
            throw new System.ArgumentException();
        }
    }

    public User User { get => _user;}
    public Difficulty Diff { get => _diff; set => _diff = value; }
    public List<MajorRegion> Data { get => _data; }
    public List<Player> FreeAgents { get => _freeAgents; }
}
