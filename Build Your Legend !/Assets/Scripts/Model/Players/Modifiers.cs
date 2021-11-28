using System;
using System.Collections.Generic;

internal class Modifiers
{
    private PlayerRole role;
    private List<double> _mods;

    public Modifiers(PlayerRole role)
    {
        this.role = role;
        GenerateModifiers();
    }

    //Agression,Outplay,Vision,ObjectiveControl,Experience,Comm,Farming,Positioning,Consistency
    private void GenerateModifiers()
    {
        _mods = new List<double>();
        double[] add = new double[9];
        switch (role)
        {
            case PlayerRole.TopLaner:
               add = new double[9] { 3, 3, 1, 1, 2, 2, 2, 1, 3};
                break;
            case PlayerRole.Jungler:
                add = new double[9] { 2, 2, 3, 3, 1, 3, 1, 1, 2};
                break;
            case PlayerRole.MidLaner:
                add = new double[9] { 3, 3, 2, 1, 2, 2, 2, 2, 2};
                break;
            case PlayerRole.BotLaner:
                add = new double[9] { 1, 3, 1, 1, 2, 1, 3, 3, 2};
                break;
            case PlayerRole.Support:
                add = new double[9] { 2, 2, 4, 2, 1, 3, 0, 1, 2};
                break;
        }
        _mods.AddRange(add);
        
    }

    public List<double> Mods { get => _mods;}

    public double Total()
    {
        double result = 0;
        foreach(double i in _mods)
        {
            result += i;
        }
        return result;
    }
}