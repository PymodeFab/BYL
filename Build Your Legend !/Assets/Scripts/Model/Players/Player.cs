using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Player class which represents the model of all players available in the game
 * Author : DOMPEY Fabien
 * Date : 05/10/2021
 * Version : 0.1.0
 */

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject
{
    public new string name;

    public int age;

    public string inGameName;

    public int salary;

    public int monetaryValue;

    public Mood mood;

    public Nationality nat;

    public Status s;

    public PlayerRole role;

    public int agression;

    public int outplay;

    public int vision;

    public int objective_control;

    public int selfishness;

    public int experience;

    public int comm;

    public int farming;

    public int positioning;

    public int consistency;

    private int potential;

    public Player(string name,string ign, int age, int salary,int monetary,Mood m,Nationality n, Status s,PlayerRole p,int agression,int outplay,int vision,int objective,int self,
        int exp,int comm,int farm,int pos,int cons)
    {
        if(!name.Equals(null) && !ign.Equals(null) && age > 16 && age < 40 && salary > 1 && salary < 1000000000 && monetary > 1 && monetary < 1000000000 && !m.Equals(null)
            && !n.Equals(null) && !s.Equals(null) && ProveCara(agression) && ProveCara(outplay) && ProveCara(vision) && ProveCara(objective) && ProveCara(self) 
             && ProveCara(exp) && ProveCara(comm) && ProveCara(farm) && ProveCara(pos) && ProveCara(cons) && !p.Equals(null))
        {
            this.name = name;
            this.inGameName = ign;
            this.age = age;
            this.salary = salary;
            this.monetaryValue = monetary;
            this.mood = m;
            this.nat = n;
            this.role = p;
            this.s = s;
            this.agression = agression;
            this.outplay = outplay;
            this.vision = vision;
            this.objective_control = objective;
            this.selfishness = self;
            this.experience = exp;
            this.comm = comm;
            this.farming = farm;
            this.positioning = pos;
            this.consistency = cons;
            SetPotential();

        }
        else
        {
            throw new System.ArgumentException("Illegal Arguments");
        }

    }

    private bool ProveCara(int cara)
    {
        return cara > 0 && cara < 100;
    }

    /** Method to access the potential of a player
     * return the final potential of the player
     */
    public int GetPotential()
    {
        return potential;
    }
    /*
     * Method to determine the set potential of a player
     */
    private void SetPotential()
    {
        /* int modif = 0;
         System.Random rnd = new System.Random();
         int current = GetBaseScore();
         if(age > 20)
         {
             modif *= -1;
         }
         else
         {

         }*/
        potential = 99;
    }
    public int GetBaseScore()
    {
        int results = 0;
        switch (role)
        {
            case PlayerRole.TopLaner:
                results = (int)(3*agression+3*outplay+1*vision+objective_control+3*(100-selfishness)+2*experience+2*comm+2*farming+positioning) / 18;
                break;
            case PlayerRole.Jungler:
                results = (int)(2 * agression + 2 * outplay + 3 * vision + 3 * objective_control + 2 * BetterSelfish() + experience + 3 * comm + farming + positioning) / 18;
                break;
            case PlayerRole.MidLaner:
                results = (int)(3 * agression + 3 * outplay + 2 * vision + objective_control + 2 * BetterSelfish() + 2 * experience + comm + 2 * farming + 2 * positioning) / 18;
                break;
            case PlayerRole.BotLaner:
                results = (int)(agression + 3 * outplay + vision + objective_control + 4 * selfishness + 2 * experience + comm + 3 * farming + 2 *positioning) / 18;
                break;
            case PlayerRole.Support:
                results = (int)(2 * agression + 2 * outplay + 4 * vision + 2* objective_control + 3 * (100 - selfishness) + experience + 3 * comm + 0 * farming + positioning) / 18;
                break;

        }
        return results;
    }

    private int BetterSelfish() => selfishness > 100-selfishness ? selfishness : 100 -selfishness;

    /* Method to access the current Score of a player based on his score and his mood
     * 
     */
    public int GetCurrentScore()
    {
        int score = GetBaseScore();
        switch (mood)
        {
            case Mood.Horrendous:
                score = (int)(score* 0.8);
                break;
            case Mood.Bad:
                score = (int)(score * 0.9);
                break;
            case Mood.Normal:
                score = (int)(score * 1);
                break;
            case Mood.Good:
                score = (int)(score * 1.1);
                break;
            case Mood.Superb:
                score = (int)(score * 1.2);
                break;
        }
        if(score > 99)
        {
            score = 99;
        }else if(score < 1)
        {
            score = 1;
        }
        return score;

    }


}
