using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Player class which represents the model of all players available in the game
 * Author : DOMPEY Fabien
 * Date : 05/10/2021
 * Version : 0.1.0
 */

[CreateAssetMenu(fileName = "New Player", menuName = "Recruit/Player")]
public class Player : Individual
{

    public Mood mood;

    public Status s;

    public PlayerRole role;

    [SerializeField] private int agression;

    [SerializeField] private int outplay;

    [SerializeField] private int vision;

    [SerializeField] private int objective_control;

    [SerializeField] private int selfishness;

    [SerializeField] private int experience;

    [SerializeField] private int comm;

    [SerializeField] private int farming;

    [SerializeField] private int positioning;

    [SerializeField] private int consistency;

    

    private int potential;

    public Player(string name,string ign, int age, DateTime bd, int salary,int monetary,Mood m,Nationality n, Status s,PlayerRole p,int agression,int outplay,int vision,int objective,int self,
        int exp,int comm,int farm,int pos,int cons) : base(name,ign,age,bd,salary,monetary,n)
    {
        if( !m.Equals(null) && !s.Equals(null) && ProveCara(agression) && ProveCara(outplay) && ProveCara(vision) && ProveCara(objective) && ProveCara(self) 
             && ProveCara(exp) && ProveCara(comm) && ProveCara(farm) && ProveCara(pos) && ProveCara(cons) && !p.Equals(null))
        {
            this.mood = m;
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
         int score = GetBaseScore();
         System.Random rnd = new System.Random();
         int result = rnd.Next(1, 100);
         if(age < 20)
         {
            if(result < 75)
            {
                potential = 70 + rnd.Next(1, 9);
            }else if(result < 95)
            {
                potential = 80 + rnd.Next(1, 9);
            }
            else
            {
                potential = 90 + rnd.Next(1, 9);
            }
            if(potential < score)
            {
                potential = score + rnd.Next(5, 20);
            }
            if(potential > 99)
            {
                potential = 99;
            }
         }
         else
         {
            potential = score - rnd.Next(1, 20);
            if(potential < 1)
            {
                potential = 1;
            }
         }

    }

    /*Method to refresh the potential of a player
     * 
     */
    public void RefreshPotential()
    {
        SetPotential();
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
        int score = (int)(GetBaseScore() * CoeffMood());
        if(score > 99)
        {
            score = 99;
        }else if(score < 1)
        {
            score = 1;
        }
        return score;

    }

    private double CoeffMood()
    {
        switch (mood)
        {
            case Mood.Horrendous: return 0.9;
            case Mood.Bad: return 0.95;
            case Mood.Normal: return 1;
            case Mood.Good: return 1.05;
            case Mood.Superb: return 1.1;
        }
        return 0;
    }

    /** Getters and setters of the private fields
     * 
     */
    public int GetCurrentAgression()
    {
        return (int)(agression * CoeffMood());
    }
    public int GetCurrentVision()
    {
        return (int)(vision * CoeffMood());
    }
    public int GetCurrentOutplay()
    {
        return (int)(outplay * CoeffMood());
    }
    public int GetCurrentSelfishness()
    {
        return (int)(selfishness * CoeffMood());
    }
    public int GetCurrentObjectiveControl()
    {
        return (int)(objective_control * CoeffMood());
    }
    public int GetCurrentFarming()
    {
        return (int)(farming * CoeffMood());
    }
    public int GetCurrentPositioning()
    {
        return (int)(positioning * CoeffMood());
    }
    public int GetCurrentExperience()
    {
        return (int)(experience * CoeffMood());
    }
    public void TrainAgression(int mod)
    {
        if(mod > 0)
        {
            if(mod + agression <= potential)
            {
                agression += mod;
            }
        }
        else
        {
            if(agression - mod >= potential)
            {
                agression -= mod;
            }
        }
    }
    public void TrainVision(int mod)
    {
        if (mod > 0)
        {
            if (mod + vision <= potential)
            {
                vision += mod;
            }
        }
        else
        {
            if (vision - mod >= potential)
            {
                vision -= mod;
            }
        }
    }
    public void TrainFarming(int mod)
    {
        if (mod > 0)
        {
            if (mod + farming <= potential)
            {
                farming += mod;
            }
        }
        else
        {
            if (farming - mod >= potential)
            {
                farming -= mod;
            }
        }
    }
    public void TrainObjectiveControl(int mod)
    {
        if (mod > 0)
        {
            if (mod + objective_control <= potential)
            {
                objective_control += mod;
            }
        }
        else
        {
            if (objective_control - mod >= potential)
            {
                objective_control -= mod;
            }
        }
    }
    public void TrainOutplay(int mod)
    {
        if (mod > 0)
        {
            if (mod + outplay <= potential)
            {
                outplay += mod;
            }
        }
        else
        {
            if (outplay - mod >= potential)
            {
                outplay -= mod;
            }
        }
    }
    public void TrainPositioning(int mod)
    {
        if (mod > 0)
        {
            if (mod + positioning <= potential)
            {
                positioning += mod;
            }
        }
        else
        {
            if (positioning - mod >= potential)
            {
                positioning -= mod;
            }
        }
    }
    public void TrainExperience(int mod)
    {
        if (mod > 0)
        {
            if (mod + experience <= potential)
            {
                experience += mod;
            }
        }
        else
        {
            if (experience - mod >= potential)
            {
                experience -= mod;
            }
        }
    }
    public void TrainComm(int mod)
    {
        if (mod > 0)
        {
            if (mod + comm <= potential)
            {
                comm += mod;
            }
        }
        else
        {
            if (comm - mod >= potential)
            {
                comm -= mod;
            }
        }
    }
    public void TrainSelfishness(int mod)
    {
        if (mod > 0)
        {
            if (mod + selfishness <= potential)
            {
                selfishness += mod;
            }
        }
        else
        {
            if (selfishness - mod >= potential)
            {
                selfishness -= mod;
            }
        }
    }
    public void TrainConsistency(int mod)
    {
        if (mod > 0)
        {
            if (mod + consistency <= potential)
            {
                consistency += mod;
            }
        }
        else
        {
            if (consistency - mod >= potential)
            {
                consistency -= mod;
            }
        }
    }
}
