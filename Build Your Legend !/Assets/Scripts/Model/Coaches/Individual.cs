using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public abstract class Individual : ScriptableObject
{
    [SerializeField] protected  string _name;

    [SerializeField] protected  Sprite _sprite;

    [SerializeField] protected string _inGameName;

    [SerializeField] protected int _salary;

    [SerializeField] protected int _monetaryValue;

    [SerializeField] protected Nationality _nat;

    protected DateTime _birthday;

    [SerializeField] protected  string _birthdayDate;

    public string BirthdayToString { get => _birthdayDate; }

    public string Name { get => _name; }

    public string IGN { get => _inGameName; set => _inGameName = value; }

    public int Salary { get => _salary; set => _salary = value; }

    public int MonetaryValue { get => _monetaryValue; set => _monetaryValue = value; }

    public Sprite Sprite { get => _sprite; }

    public Nationality Nationality { get => _nat; set => _nat = value; }

    public Individual(string name, string ign,DateTime bd,int salary,int monetary, Nationality nat,Sprite sp)
    {
        if(!name.Equals(null) && !ign.Equals(null) && !bd.Equals(null) && salary > 1 && salary < 100000000 && monetary > 1 && monetary < 100000000 && !nat.Equals(null) && !sp.Equals(null))
        {
            this._nat = nat;
            this._name = name;
            this._inGameName = ign;
            this._salary = salary;
            this._monetaryValue = monetary;
            this._birthday = bd;
            _birthdayDate = "";
            _sprite = sp;
        }
        else
        {
            throw new System.ArgumentException("Illegal Arguments");
        }
    }

    /*Really important method to call when using an edited player
     */
    public void RefreshBirthday()
    {
        Debug.Log("Called birthday");
            string[] subs = Regex.Split(_birthdayDate, @"/");
            _birthday = new DateTime(Int32.Parse(subs[2]),Int32.Parse(subs[1]),Int32.Parse(subs[0]));
        Debug.Log(_birthday.Year);
            
    }
    public int CalculateAge(DateTime refe)
    {
        int age;
        Debug.Log(_birthday.ToString());
        age = refe.Year - _birthday.Year;
        if (refe.Month < _birthday.Month || (refe.Month == _birthday.Month && refe.Day < _birthday.Day))
            age--;
        return age;
    }
}
