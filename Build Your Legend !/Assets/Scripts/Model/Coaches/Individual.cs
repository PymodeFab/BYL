using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Individual : ScriptableObject
{
    public new string name;

    public int age;

    public string inGameName;

    public int salary;

    public int monetaryValue;

    public Nationality nat;

    public Individual(string name, string ign, int age,int salary,int monetary, Nationality nat)
    {
        if(!name.Equals(null) && !ign.Equals(null) && age > 16 && age < 50 && salary > 1 && salary < 100000000 && monetary > 1 && monetary < 100000000 && !nat.Equals(null))
        {
            this.nat = nat;
            this.name = name;
            this.inGameName = ign;
            this.salary = salary;
            this.monetaryValue = monetary;
            this.age = age;
        }
        else
        {
            throw new System.ArgumentException("Illegal Arguments");
        }
    }
}
