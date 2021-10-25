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

    public Status s;

    [SerializeField] private PlayerStyle _playStyle;

    private Modifiers _mods;

    [SerializeField] private int _agression;

    [SerializeField] private int _outplay;

    [SerializeField] private int _vision;

    [SerializeField] private int _objective_control;

    [SerializeField] private int _experience;

    [SerializeField] private int _comm;

    [SerializeField] private int _farming;

    [SerializeField] private int _positioning;

    [SerializeField] private int _consistency;

    /*
     * Getters of the base score of each caracteristics
     * 
     */
    public int BaseAgression { get => _agression;  }

    public int BaseOutplay { get => _outplay; }

    public int BaseVision { get => _vision; }

    public int BaseObjectiveControl { get => _objective_control; }

    public int BaseExperience { get => _experience; }

    public int BaseCommunication { get => _comm; }

    public int BaseFarming { get => _farming; }

    public int BasePositioning { get => _positioning; }

    public int Consistency { get => _consistency; }

    public PlayerStyle PlayStyle { get => _playStyle; set => _playStyle = value; }

    private DiceRoll _roll;

    private System.Random _rnd;

    private int potential;

    public Player(string name,string ign, DateTime bd, int salary,int monetary,Sprite sp,Nationality n,PlayerStyle ps, Status s,PlayerRole p,int _agression,int _outplay,int _vision,int objective,
        int exp,int _comm,int farm,int pos,int cons) : base(name,ign,bd,salary,monetary,n,sp,p)
    {
        if(!s.Equals(null) && !ps.Equals(null) && ProveCara(_agression) && ProveCara(_outplay) && ProveCara(_vision) && ProveCara(objective)
             && ProveCara(exp) && ProveCara(_comm) && ProveCara(farm) && ProveCara(pos) && ProveCara(cons) && !p.Equals(PlayerRole.Coach))
        {
            this.s = s;
            this._agression = _agression;
            this._outplay = _outplay;
            this._vision = _vision;
            this._objective_control = objective;
            this._experience = exp;
            this._comm = _comm;
            this._farming = farm;
            this._positioning = pos;
            this._consistency = cons;
            _playStyle = ps;
            _roll = DiceRoll.NONE;
            Initialize();
            

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
         int result =_rnd.Next(1, 100);
         if(CalculateAge(DateTime.Now) < 20)
         {
            if(result < 75)
            {
                potential = 70 +_rnd.Next(1, 9);
            }else if(result < 95)
            {
                potential = 80 +_rnd.Next(1, 9);
            }
            else
            {
                potential = 90 +_rnd.Next(1, 9);
            }
            if(potential < score)
            {
                potential = score +_rnd.Next(5, 20);
            }
            if(potential > 99)
            {
                potential = 99;
            }
         }
         else
         {
            potential = score -_rnd.Next(1, 20);
            if(potential < 1)
            {
                potential = 1;
            }
         }

    }

    /*Method to refresh the potential of a player
     * Really important for the edited players
     */
    public override void Initialize()
    {

        base.Initialize();
        _mods = new Modifiers(role);
        _rnd = new System.Random();
        SetPotential();
    }
   
 public int GetBaseScore()
    {
        int sum = (int)((_mods.Mods[0] * _agression) + (_mods.Mods[1] * _outplay) + (_mods.Mods[2] * _vision) + (_mods.Mods[3] * _objective_control) + (_mods.Mods[4] * _experience) + (_mods.Mods[5] * _comm)
            + (_mods.Mods[6] * _farming) + (_mods.Mods[7] * _positioning) + (_mods.Mods[8] * _consistency));
        int total = (int)_mods.Total();
        return sum / total;
    }
    /* Method to access the current Score of a player based on his score and his mood
     * 
     */
    public int GetCurrentScore()
    {
        int score = (int)(GetBaseScore() + CoeffConsist());
        if(score > 99)
        {
            score = 99;
        }else if(score < 1)
        {
            score = 1;
        }
        return score;

    }

    /* Roll a dice to see if the player is ready for the game ahead
     * based on his consistency score
     */
    public void RollConsistencyGame()
    {
        int dice = _rnd.Next(1, 100);

        if (dice < 6)
        {
            _roll = DiceRoll.CRITICAL_SUCCESS;
        }
        else if (dice > 95)
        {
            _roll = DiceRoll.CRITICAL_FAILURE;
        }
        else if (dice < Consistency)
        {
            _roll = DiceRoll.SUCCESS;
        }
        else
        {
            _roll = DiceRoll.FAILURE;
        }
    }

    //Reset the roll for the next game
    public void EndGame()
    {
        _roll = DiceRoll.NONE;
    }

    /* Determine the bonus or malus to add to each caracteristics asked by events in the game depending of its consistency and its roll
     */
    private int CoeffConsist()
    {
        int result = 0;
        if(_roll.Equals(DiceRoll.CRITICAL_FAILURE) || _roll.Equals(DiceRoll.CRITICAL_SUCCESS))
        {
            if (_playStyle.Equals(PlayerStyle.Agressive))
            {
                result = _rnd.Next(5, 10);
            }
            else
            {
                result = _rnd.Next(1, 5);
            }
        }
        else if (_roll.Equals(DiceRoll.FAILURE)||_roll.Equals(DiceRoll.SUCCESS))
        {
            if (_playStyle.Equals(PlayerStyle.Agressive))
            {
                result = _rnd.Next(1, 10);
            }
            else
            {
                result = _rnd.Next(1, 5);
            }
        }
        result = (_roll.Equals(DiceRoll.CRITICAL_FAILURE) || _roll.Equals(DiceRoll.FAILURE)) ? result * -1 : result + 1;
        return result;
    }

    /** Getters and setters of the private fields
     * 
     */
    public int GetCurrentAgression()
    {
        return ((int)(_mods.Mods[0]*_agression)) + CoeffConsist();
    }
    public int GetCurrentOutplay()
    {
        return ((int)(_mods.Mods[1] * _outplay)) + CoeffConsist();
    }
    public int GetCurrentVision()
    {
        return ((int)(_mods.Mods[2] * _vision)) + CoeffConsist();
    }
    public int GetCurrentObjectiveControl()
    {
        return ((int)(_mods.Mods[3] * _objective_control)) + CoeffConsist();
    }
    public int GetCurrentExperience()
    {
        return ((int)(_mods.Mods[4] * _experience)) + CoeffConsist();
    }

    public int GetCurrentComm()
    {
        return ((int)(_mods.Mods[5] * _comm)) + CoeffConsist();
    }
    public int GetCurrentFarming()
    {
        return ((int)(_mods.Mods[6] * _farming)) + CoeffConsist();
    }
    public int GetCurrentPositioning()
    {
        return ((int)(_mods.Mods[7] * _positioning)) + CoeffConsist();
    }
    public int GetCurrentConsist()
    {
        return ((int)(_mods.Mods[8] * _consistency)) + CoeffConsist();
    }

    public void TrainAgression(int mod)
    {
        if(mod > 0)
        {
            if(mod + _agression <= potential)
            {
                _agression += mod;
            }
        }
        else
        {
            if(_agression - mod >= potential)
            {
                _agression -= mod;
            }
        }
    }
    public void TrainVision(int mod)
    {
        if (mod > 0)
        {
            if (mod + _vision <= potential)
            {
                _vision += mod;
            }
        }
        else
        {
            if (_vision - mod >= potential)
            {
                _vision -= mod;
            }
        }
    }
    public void TrainFarming(int mod)
    {
        if (mod > 0)
        {
            if (mod + _farming <= potential)
            {
                _farming += mod;
            }
        }
        else
        {
            if (_farming - mod >= potential)
            {
                _farming -= mod;
            }
        }
    }
    public void TrainObjectiveControl(int mod)
    {
        if (mod > 0)
        {
            if (mod + _objective_control <= potential)
            {
                _objective_control += mod;
            }
        }
        else
        {
            if (_objective_control - mod >= potential)
            {
                _objective_control -= mod;
            }
        }
    }
    public void TrainOutplay(int mod)
    {
        if (mod > 0)
        {
            if (mod + _outplay <= potential)
            {
                _outplay += mod;
            }
        }
        else
        {
            if (_outplay - mod >= potential)
            {
                _outplay -= mod;
            }
        }
    }
    public void TrainPositioning(int mod)
    {
        if (mod > 0)
        {
            if (mod + _positioning <= potential)
            {
                _positioning += mod;
            }
        }
        else
        {
            if (_positioning - mod >= potential)
            {
                _positioning -= mod;
            }
        }
    }
    public void TrainExperience(int mod)
    {
        if (mod > 0)
        {
            if (mod + _experience <= potential)
            {
                _experience += mod;
            }
        }
        else
        {
            if (_experience - mod >= potential)
            {
                _experience -= mod;
            }
        }
    }
    public void TrainComm(int mod)
    {
        if (mod > 0)
        {
            if (mod + _comm <= potential)
            {
                _comm += mod;
            }
        }
        else
        {
            if (_comm - mod >= potential)
            {
                _comm -= mod;
            }
        }
    }
    public void TrainConsistency(int mod)
    {
        if (mod > 0)
        {
            if (mod + _consistency <= potential)
            {
                _consistency += mod;
            }
        }
        else
        {
            if (_consistency - mod >= potential)
            {
                _consistency -= mod;
            }
        }
    }
}
