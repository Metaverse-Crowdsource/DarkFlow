using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class limbHealth : Health  // This script is meant to be on the LIMBS of the character. NOT the main body.
                                  // THE LIMBS. HEAD, CHEST, ARMS, LEGS
                                  // Yes, upper and lower, where the colliders will be.
{
    [SerializeField] BodyPart bodyPart;

    public void Damage(float dmg) 
    {
        Debug.Log("Damage called at " + dmg);
        DamagePlayer(dmg, bodyPart); 
    }
}
