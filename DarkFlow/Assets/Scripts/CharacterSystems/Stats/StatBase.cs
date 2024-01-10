using UnityEngine;

[CreateAssetMenu(fileName = "NewStat", menuName = "Stats/BaseStat")]
public class StatBase : ScriptableObject
{
    public string statName;
    public Sprite icon;
    public float value;
    public Color barColor;
}
