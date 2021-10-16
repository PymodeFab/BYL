using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    /*Individual View
     */
    public Text _name;
    public Text _bd;
    public Text _ign;
    public Text _salary;
    public Text _value;
    public Image _sprite;
    public Image _flag;
    public Image _role;


    private Player i;
    public Text _score;
    public Text playerSearch;

    /* Stats view
     */
    public Gradient grad;
    public Text _agre;
    public Image fill_agre;
    public Slider slid_agre;

    public Text _vis;
    public Image fill_vis;
    public Slider slid_vis;

    public Text _out;
    public Image fill_out;
    public Slider slid_out;

    public Text _obj;
    public Image fill_obj;
    public Slider slid_obj;

    public Text _self;
    public Image fill_self;
    public Slider slid_self;

    public Text _exp;
    public Image fill_exp;
    public Slider slid_exp;

    public Text _farm;
    public Image fill_farm;
    public Slider slid_farm;

    public Text _com;
    public Image fill_com;
    public Slider slid_com;

    public Text _pos;
    public Image fill_pos;
    public Slider slid_pos;

    public Text _cons;
    public Image fill_cons;
    public Slider slid_cons;

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
        UpdateGraphics();

    }

    public void ViewSelectPlayer()
    {
        i = DataHolder.GetPlayerByIGN(playerSearch.text);
        if(i != null)
        {
            UpdateGraphics();
        }
        else
        {
            ErrorBoxView.Show();
        }
        
    }

    private void UpdateGraphics()
    {

        _name.text = i.Name;
        _bd.text = i.BirthdayToString;
        _ign.text = i.IGN;
        _salary.text = i.Salary.ToString() + " $";
        _value.text = i.MonetaryValue.ToString() + " $";
        _sprite.sprite = i.Sprite;
        _flag.sprite = DataHolder.GetSpriteFromNationality(i.Nationality);
        _role.sprite = DataHolder.GetSpriteFromRole(i.Role);
        _score.text = i.GetBaseScore().ToString();
        UpdateStatistics();
    }

    private void UpdateStatistics()
    {
        _agre.text = i.BaseAgression.ToString();
        _vis.text = i.BaseVision.ToString();
        _out.text = i.BaseOutplay.ToString();
        _obj.text = i.BaseObjectiveControl.ToString();
        _com.text = i.BaseCommunication.ToString();
        _farm.text = i.BaseFarming.ToString();
        _pos.text = i.BasePositioning.ToString();
        _cons.text = i.Consistency.ToString();
        _self.text = i.BaseSelfishness.ToString();
        _exp.text = i.BaseExperience.ToString();

        slid_agre.value = i.BaseAgression;
        slid_cons.value = i.Consistency;
        slid_vis.value = i.BaseVision;
        slid_out.value = i.BaseOutplay;
        slid_obj.value = i.BaseObjectiveControl;
        slid_com.value = i.BaseCommunication;
        slid_farm.value = i.BaseFarming;
        slid_pos.value = i.BasePositioning;
        slid_self.value = i.BaseSelfishness;
        slid_exp.value = i.BaseExperience;

        fill_agre.color = grad.Evaluate(slid_agre.normalizedValue);
        fill_vis.color = grad.Evaluate(slid_vis.normalizedValue);
        fill_out.color = grad.Evaluate(slid_out.normalizedValue);
        fill_obj.color = grad.Evaluate(slid_obj.normalizedValue);
        fill_com.color = grad.Evaluate(slid_com.normalizedValue);
        fill_farm.color = grad.Evaluate(slid_farm.normalizedValue);
        fill_pos.color = grad.Evaluate(slid_pos.normalizedValue);
        fill_self.color = grad.Evaluate(slid_self.normalizedValue);
        fill_exp.color = grad.Evaluate(slid_exp.normalizedValue);
        fill_cons.color = grad.Evaluate(slid_cons.normalizedValue);
    }
}
