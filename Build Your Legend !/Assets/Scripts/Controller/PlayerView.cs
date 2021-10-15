using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
public Text _name;
public Text _bd;
public Text _ign;
public Text _salary;
public Text _value;
public Image _sprite;
public Image _flag;
public Image _role;
    private Individual i;


    // Start is called before the first frame update
    void Start()
    {
        LookAtRandomPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookAtRandomPlayer()
    {
        i = DataHolder.GetRandomPlayer();
        _name.text = i.Name;
        _bd.text = i.BirthdayToString;
        _ign.text = i.IGN;
        _salary.text = i.Salary.ToString() + " $";
        _value.text = i.MonetaryValue.ToString() + " $";
        _sprite.sprite = i.Sprite;
        _flag.sprite = DataHolder.GetSpriteFromNationality(i.Nationality);
        _role.sprite = DataHolder.GetSpriteFromRole(i.Role);

    }
}
