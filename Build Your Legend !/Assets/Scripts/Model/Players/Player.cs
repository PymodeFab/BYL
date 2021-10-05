using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Player class which represents the model of all players available in the game
 * Author : DOMPEY Fabien
 * Date : 05/10/2021
 * Version : 0.1.0
 */

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public abstract class Player : ScriptableObject
{
    public new string name;

    public int age;

    public string inGameName;

    public int salary;

    public int monetaryValue;

    public Mood mood;

    public Nationality nat;

    public Status s;

    public int agression;

    public int outplay;

    public int vision;

    public int objective_control;

    public int selfishness;

    public int game_plan;

    public int experience;

    public int comm;

    public int farming;

    public int positioning;

    public int consistency;

    public Player(string name,string ign, int age, int salary,int monetary,Mood m,Nationality n, Status s,int agression,int outplay,int vision,int objective,int self,
        int game,int exp,int comm,int farm,int pos,int cons)
    {
        if(!name.Equals(null) && !ign.Equals(null) && age > 16 && age < 40 && salary > 1 && salary < 1000000000 && monetary > 1 && monetary < 1000000000 && !m.Equals(null)
            && !n.Equals(null) && !s.Equals(null) && proveCara(agression) && proveCara(outplay) && proveCara(vision) && proveCara(objective) && proveCara(self) 
            && proveCara(game) && proveCara(exp) && proveCara(comm) && proveCara(farm) && proveCara(pos) && proveCara(cons))
        {
            this.name = name;
            this.inGameName = ign;
            this.age = age;
            this.salary = salary;
            this.monetaryValue = monetary;
            this.mood = m;
            this.nat = n;
            this.s = s;
            this.agression = agression;
            this.outplay = outplay;
            this.vision = vision;
            this.objective_control = objective;
            this.selfishness = self;
            this.game_plan = game;
            this.experience = exp;
            this.comm = comm;
            this.farming = farm;
            this.positioning = pos;
            this.consistency = cons;

        }
        else
        {
            throw new System.ArgumentException("Illegal Arguments");
        }

    }

    private bool proveCara(int cara)
    {
        return cara > 0 && cara < 100;
    }


}
