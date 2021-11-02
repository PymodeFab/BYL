using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Events linked to a team play against an objective
 */
public abstract class TeamEvent : Event
{
    [SerializeField] private List<PlayerRole> _rolesUser;
    public TeamEvent(string name, int points, string description, GameStage gs,List<PlayerRole> roles,List<PlayerRole> userRoles) : base(name, points, description, gs,roles)
    {
        this._rolesUser = new List<PlayerRole>(userRoles);
    }

    public List<PlayerRole> RolesUser { get => new List<PlayerRole>(_rolesUser); }
}
