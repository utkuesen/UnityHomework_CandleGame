using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgraderProperties : MonoBehaviour
{
    public enum UpgraderTypes {adder, multiplier, subtractor, divider}
    public UpgraderTypes upgraderType = UpgraderTypes.adder;
    public float upgraderValue = 0.1f;
    public bool isEffected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
