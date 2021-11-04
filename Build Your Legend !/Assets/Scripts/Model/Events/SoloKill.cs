using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Event",menuName ="Event/Individual Event/Solo Kill")]
public class SoloKill : IndividualEvent
{
    public SoloKill(string name, int points, string description, GameStage gs, List<PlayerRole> roles, PlayerRole roleUser) : base(name, points, description, gs, roles, roleUser)
    {
    }

    protected override bool RollEvent(Team user, Team target)
    {
        int objective = 1;
        Player ours = user.GetPlayerByRole(RoleUser);
        Player oppo = target.GetPlayerByRole(RoleUser);
        int total1 = (ours.BaseAgression+ours.BaseOutplay) / (2);
        int total2 = (oppo.BaseOutplay+oppo.BaseExperience+oppo.BasePositioning) / (3);
        objective += (total1 > total2) ? 1 : 0;
        return Random.Range(0, objective) != 0;
    }
}
