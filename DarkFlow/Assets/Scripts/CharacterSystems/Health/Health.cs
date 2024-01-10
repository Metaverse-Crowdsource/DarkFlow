using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Netcode;

public class Health: NetworkBehaviour
{
    // ***Network Checks*** All network calls and references are made in the Limb script and anything calling to this Class. This prevents unneccessary checks on our part.

    // ***At this spot*** I need to make a reference to any other Transforms we may need to call upon for references. Ex: Animators, Armors, Augmentations, UI, etc.

    private float healthMain; // Our primary Health, enough hits to everything else and we bleed out.
    private float healthMax; // The maximum Health allowed. This value allows it to be upgraded.
    private float staminaMain; // See above, but with Stamina.
    private float staminaMax; // Self explanatory.
    private float adrenaline; // Adrenaline drive, given during moments of low health for those "Oh shit" moments.
    private float cyberHealth; // Seperate from healthMain, this variable controls overall mental health - Get low enough, physical damage may occur! Warranty not included.
    private float armorHealth; // Probably just gonna Transform.GetComponent this from the actual armor item. Might make this to each limb as well. For now, mundane stuff!

    public enum BodyPart
    {
        Head,
        Chest,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg
    }

    public enum Toxicity // I'm running this as an enum for now, it may be split in to seperate variables - Just did this so I can possibly have other factors later.
    {
        Bio,
        Psych,
        Radiation
    }


    private Dictionary<BodyPart, float> bodyPartHealth = new Dictionary<BodyPart, float>();
    private Dictionary<Toxicity, float> toxicBar = new Dictionary<Toxicity, float>(); // This will be our dictionary for the toxicity meters.

    // Augmentations will be in another MonoBehavior, I don't feel like including them in this one, mainly for sake of compile and run time. - Sona

    private void Start()
    {
        InitializeHealth();
        Debug.Log("Health behavior on " + this.gameObject + " has been activated."); // I just like knowing the script is functioning.
    }

    public void InitializeHealth() // Bodypart floats are counted as a 1-100 float value. They can be increased, but it will need to be handled outside the script for cleanliness.
    {
//        if (!isLocalPlayer) return;

        bodyPartHealth[BodyPart.Head] = 100f;
        bodyPartHealth[BodyPart.Chest] = 100f;
        bodyPartHealth[BodyPart.LeftArm] = 100f;
        bodyPartHealth[BodyPart.RightArm] = 100f;
        bodyPartHealth[BodyPart.LeftLeg] = 100f;
        bodyPartHealth[BodyPart.RightLeg] = 100f;
    }

    public void InitializeToxicBar() // Load the meters up and zero them out, we'll get the values later from the server.
    {
 //       if (!isLocalPlayer) return;

        toxicBar[Toxicity.Bio] = 0f;
        toxicBar[Toxicity.Psych] = 0f;
        toxicBar[Toxicity.Radiation] = 0f;
    }

    public void DamageArmor(float D) // Private so that this function must be special called by a referencing script. I'll network this soon to test for lag.
    {
        if (D <= 0) return;
        else
        {
            armorHealth -= D;
            if(armorHealth <= 0)
            {
                armorHealth = 0;
                Debug.Log("Armor on " + this.gameObject + " has been destroyed beyond repair!");
            }
        }
    }

    public void DamagePlayer(float D, BodyPart bodyPart) // D to call for the damage float, X will probably reference a body part in the future.
    {
        if(bodyPartHealth.ContainsKey(bodyPart))
        {
            if(D > 0)
            {
                bodyPartHealth[bodyPart] -= D;
                healthMain -= D / bodyPartHealth[bodyPart] * 2;
            }
        }
        PlayerStatus();
    }

    private void PlayerStatus() // Let's check on player's status, their limbs, etc.
    {
        // To further elaborate, healing and whatnot can be handled by an item's script - and it can reference this one.
        // Right now, none of these check for the armor status - Which, I'll probably give them a bonus to health from the armor anyway. Maybe.

        if (bodyPartHealth.ContainsKey(BodyPart.Head) && bodyPartHealth[BodyPart.Head] <= 0) // Let's be honest. Head Health being 0 means they are dead.
        {
            Debug.Log("Should get your head looked at, it's missing!");
        }
        if (bodyPartHealth.ContainsKey(BodyPart.LeftLeg) && bodyPartHealth[BodyPart.LeftLeg] <= 0)
        {
            Debug.Log("My leg!");
        }
        if (bodyPartHealth.ContainsKey(BodyPart.LeftArm) && bodyPartHealth[BodyPart.LeftArm] <= 0)
        {
            Debug.Log("Look! No hands!");
        }
        if (bodyPartHealth.ContainsKey(BodyPart.RightArm) && bodyPartHealth[BodyPart.RightArm] <= 0)
        {
            Debug.Log("Look! No hands!");
        }
        if (bodyPartHealth.ContainsKey(BodyPart.RightLeg) && bodyPartHealth[BodyPart.RightLeg] <= 0)
        {
            Debug.Log("My leg!");
        }
        InitializeHealth();

    }
}
