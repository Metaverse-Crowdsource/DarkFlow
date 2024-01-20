using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NPC : MonoBehaviour
{
    [Header("NPC")]
    [SerializeField] private string npcName; // NPC will get their name - GameObject will not carry NPC's exact name.
    [SerializeField] private string desc; // NPC description - This is their 'Inspect' or 'Examine' text.
    [Space]

    [Header("Interactive")]
    [SerializeField] private bool isHostile = false;
    [TextArea(4, 10)]
    public string NPCText; // Public so that it can be changed by any other script that needs to reference it. Example: The player kills a friend, now this NPC isn't so friendly.
    [SerializeField] private GameObject dropOnDeath;

    [Header("Script References")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Health health; // We'll need this later. Probably write an AI script to work with this specifically.
    [SerializeField] private TextMeshProUGUI npcNameBox;
    [SerializeField] private TextMeshProUGUI npcChatBox;

    private bool canTalk = false;

    private void Start()
    {
        npcNameBox.text = "";
        npcChatBox.text = "";
        if (isHostile)
        {
            health.InitializeHealth(); // Only hostile NPCs get health for now.
        }
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            OnTalk();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canTalk = false;
        npcNameBox.text = "";
        npcChatBox.text = "";
    }

    private void OnDeath()
    {
        var dItem = Instantiate(dropOnDeath);
        dItem.transform.position = transform.position;
    }

    private void OnTalk()
    {
        if (canTalk)
        {
            npcNameBox.text = npcName;
            npcChatBox.text = NPCText;
        }
    }
}
