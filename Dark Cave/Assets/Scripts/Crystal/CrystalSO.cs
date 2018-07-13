using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CrystalSizes
{
    Tiny = 1,
    Small = 2,
    Meduim = 4,
    Large = 8
};

public enum CrystalColor
{
    Red,
    Green,
    Blue,
    Black,
    White
};

[CreateAssetMenu(menuName = "Crystal")]
public class CrystalSO : ScriptableObject
{
    public CrystalSizes size;
    public CrystalColor color;

    public Sprite sprite;

    //Will use later when animations start comming in
    //public Animation animation;

    public int basePower;

    private int power;

    private void OnEnable()
    {
        power = basePower * (int)size;
    }
}
