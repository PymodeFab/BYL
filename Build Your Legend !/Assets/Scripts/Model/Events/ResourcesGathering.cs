using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event/Individual Event/Resources Gathering")]
public class ResourcesGathering : IndividualEvent
{
    public ResourcesGathering(string name, int points, string description, GameStage gs, List<PlayerRole> roles, PlayerRole roleUser) : base(name, points, description, gs, roles, roleUser)
    {
    }

    protected override bool RollEvent(Team user, Team target)
    {
        int objective = 1;
        int total1 = 0;
        int total2 = 0;
        
        Player p = user.GetPlayerByRole(RoleUser);
        Player opponent = target.GetPlayerByRole(RoleUser);
        total1 = (p.BaseFarming + p.BasePositioning) / (2);
        total2 = (p.BaseAgression + p.BaseOutplay) / (2);
        if(total1 > total2)
        {
            objective += 1;
        }
        int roll = Random.Range(0, objective);
        return roll != 0;

    }
}
