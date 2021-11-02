using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Events linked with any mechanical play or individual play
 */
public abstract class IndividualEvent : Event
{
    [SerializeField] private PlayerRole _roleUser;

    protected IndividualEvent(string name, int points, string description, GameStage gs,List<PlayerRole> roles,PlayerRole roleUser) : base(name, points, description, gs,roles)
    {
        this._roleUser = roleUser;
    }

    public PlayerRole RoleUser { get => _roleUser;}
}
