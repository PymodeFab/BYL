using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Coach",menuName ="Recruit/Coach")]
public class Coach : Individual
{
    public Coach(string name, string ign,DateTime bd, int salary, int monetary, Nationality nat,Sprite sp) : base(name, ign,bd, salary, monetary, nat,sp,PlayerRole.Coach)
    {
    }
}
