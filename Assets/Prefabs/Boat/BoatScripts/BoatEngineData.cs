using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class BoatEngineData : ScriptableObject
{
    [SerializeField]
    internal int engineSpeed;
    [SerializeField]
    internal float engineFuelAmount;

}
