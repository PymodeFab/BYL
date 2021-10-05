using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Coach",menuName ="Recruit/Coach")]
public class Coach : Individual
{
    public Coach(string name, string ign, int age, int salary, int monetary, Nationality nat) : base(name, ign, age, salary, monetary, nat)
    {
    }
}
