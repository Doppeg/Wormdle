using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum WormStats   //plan for stats is to use the following formula            Statistic = base + bonus + Growth * (Level-1) * (0.7025+0.0175*(Level-1))
{
    Area,//base size of dig area
    AreaGrowth,
    Strength,//base power of digs
    StrengthGrowth,
    Speed,//base frequency of digs
    SpeedGrowth

}
public enum WormTraits  //synergies             temp placeholder ones
{
    Blank,
    Earth,
    Fire,
    Water,
    Air
}

[Serializable]
public class WormValueContainer     //for stats
{
    public float value;
    public WormStats stats;
    public WormValueContainer(float value, WormStats stats)
    {
        this.value = value;
        this.stats = stats;
    }
}

[Serializable]
public class WormValueBlock     //for stats
{
    private const int WormStatsCount = 6;
    public List<WormValueContainer> values;
    public void InitWorm()
    {
        values = new List<WormValueContainer>();
        for (int i = 0; i < WormStatsCount; i++)
        {
            values.Add(new WormValueContainer(0f, (WormStats)i));
        }
    }
}

[Serializable]
public class WormTraitContainer     //for traits
{
    public WormTraits traits;
    public WormTraitContainer(WormTraits traits)
    {
        this.traits = traits;
    }
}

[Serializable]
public class WormTraitBlock     //for traits
{
    private const int WormTraitCount = 3;
    public List<WormTraitContainer> traits;
    public void InitWorm()
    {
        traits = new List<WormTraitContainer>();
        for (int i = 0; i < WormTraitCount; i++)
        {
            traits.Add(new WormTraitContainer((WormTraits)0));
        }
    }
}

[CreateAssetMenu(menuName = "Data/Worm")]
public class WormData : ScriptableObject
{
    public string wormName;
    public WormValueBlock stats;
    public WormTraitBlock traits;
    [ContextMenu("Init")]
    public void init()
    {
        stats = new WormValueBlock();
        stats.InitWorm();
        traits = new WormTraitBlock();
        traits.InitWorm();
    }
}