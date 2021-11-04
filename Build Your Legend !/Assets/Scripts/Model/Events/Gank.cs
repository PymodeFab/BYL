using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Event",menuName = "Event/Team Event/Fight")]
public class Gank : TeamEvent
{
    public Gank(string name, int points, string description, GameStage gs, List<PlayerRole> roles, List<PlayerRole> userRoles) : base(name, points, description, gs, roles, userRoles)
    {
    }

    protected override bool RollEvent(Team user, Team target)
    {
        int objective = 1;
        int totalTeam1 = 0;
        int totalTeam2 = 0;
        foreach(Player p in user.GetPlayersByRoles(RolesUser))
        {
            totalTeam1 += p.BaseAgression + p.BaseCommunication + p.BaseOutplay;
        }
        foreach(Player p in target.GetPlayersByRoles(TargetsRoles))
        {
            totalTeam2 += p.BaseVision + p.BaseOutplay + p.BasePositioning;
        }
        totalTeam1 = totalTeam1 / (3 * RolesUser.Count);
        totalTeam2 = totalTeam2 / (3 * TargetsRoles.Count);

        if (totalTeam1 > totalTeam2)
        {
            objective += 1;
        }
        return Random.Range(0,objective) != 0;
    }
}
