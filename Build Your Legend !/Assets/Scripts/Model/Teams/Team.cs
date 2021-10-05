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
    public new string name;

    public Nationality nat;

    public int funds;

    public int salaryFunds;

    public Individual[] recruits;

    public Team(string name,Nationality nat, int funds, int salaryFunds)
    {
        if(!name.Equals(null) && !nat.Equals(null) && funds > 1 && salaryFunds > 1)
        {
            this.name = name;
            this.nat = nat;
            this.funds = funds;
            this.salaryFunds = salaryFunds;
        }
        else
        {
            throw new System.ArgumentException("Illegal Arguments");
        }
    }

    /*
     * Method to get access to all players recruited in the team
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
}
