using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireworkScriptableDataObject", menuName = "Custom/Firework Scriptable Data Object", order = 1)]
public class FireworkData : ScriptableObject
{
    public GameObject fireworkVfx;
    public float launchForceUpMax;
    public float launchForceUpMin;
    public float launchForceLeft;
    public float launchForceRight;
    public float tapTimer;

    

}
