using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class WildlifeTracker : MonoBehaviour
{
    [System.Serializable]
    public class Wildlife
    {
        public string name;
        public Vector3 location; // Position in the game world
        public bool isDangerous; // Flag for dangerous wildlife
    }

    public List<Wildlife> nearbyWildlife; // List to store detected wildlife

    void Update()
    {
        // Here you would update the list based on game logic, e.g., player location, wildlife behavior
        // This is a placeholder for your game's specific logic
    }

    // Additional methods can be added for detecting, adding, or removing wildlife from the list
}