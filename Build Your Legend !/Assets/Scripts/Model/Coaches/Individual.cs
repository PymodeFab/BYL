using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class Individual : ScriptableObject
{
    [SerializeField] private readonly string _name;

    private int _age;

    [SerializeField] private readonly Sprite _sprite;

    [SerializeField] private string _inGameName;

    [SerializeField] private int _salary;

    [SerializeField] private int _monetaryValue;

    [SerializeField] private Nationality _nat;

    private DateTime _birthday;

    [SerializeField] private readonly string _birthdayDate;

    public string BirthdayToString { get => _birthdayDate; }

    public string Name { get => _name; }

    public string IGN { get => _inGameName; set => _inGameName = value; }

    public int Salary { get => _salary; set => _salary = value; }

    public int MonetaryValue { get => _monetaryValue; set => _monetaryValue = value; }

    public int Age { get => _age; }

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
            SetAge();
        }
        else
        {
            throw new System.ArgumentException("Illegal Arguments");
        }
    }
#if UNITY_EDITOR
    public void RefreshBirthday()
    {
        if (_birthday.Equals(null) || _birthday.Equals(DateTime.MinValue))
        {
            string[] subs = _birthdayDate.Split('.');
            _birthday = new DateTime(Int32.Parse(subs[2]),Int32.Parse(subs[1]),Int32.Parse(subs[0]));
            
        }
        SetAge();
    }

    public void SetAge()
    {
        TimeSpan t = DateTime.Now - _birthday;
        _age = (int)t.Days / 365;
    }
#endif
}
