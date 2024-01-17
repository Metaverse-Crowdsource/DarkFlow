using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class QuestObjectiveTracker : MonoBehaviour
{
    [System.Serializable]
    public class Quest
    {
        public string title;
        public string description;
        public bool isCompleted;
        public List<Objective> objectives; // Smaller objectives within the quest
    }

    [System.Serializable]
    public class Objective
    {
        public string description;
        public bool isCompleted;
    }

    public List<Quest> activeQuests; // List to store active quests

    void Update()
    {
        // Here you would update the status of quests and their objectives
        // This is a placeholder for your game's specific logic
        // For example, checking if objectives are completed, updating quest status, etc.
    }

    // Additional methods can be added to manage quests and objectives
}