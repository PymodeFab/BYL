using System;
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

    public DateTime birthday;

    [SerializeField] private string birthdayDate;

    public Individual(string name, string ign, int age,DateTime bd,int salary,int monetary, Nationality nat)
    {
        if(!name.Equals(null) && !ign.Equals(null) && age > 16 && age < 50 && !bd.Equals(null) && salary > 1 && salary < 100000000 && monetary > 1 && monetary < 100000000 && !nat.Equals(null))
        {
            this.nat = nat;
            this.name = name;
            this.inGameName = ign;
            this.salary = salary;
            this.monetaryValue = monetary;
            this.age = age;
            this.birthday = bd;
        }
        else
        {
            throw new System.ArgumentException("Illegal Arguments");
        }
    }

    public void RefreshBirthday()
    {
        if (birthday.Equals(null) || birthday.Equals(new DateTime(1,1,1)))
        {
            string[] subs = birthdayDate.Split('.');
            birthday = new DateTime(Int32.Parse(subs[2]),Int32.Parse(subs[1]),Int32.Parse(subs[0]));
        }
    }
}
