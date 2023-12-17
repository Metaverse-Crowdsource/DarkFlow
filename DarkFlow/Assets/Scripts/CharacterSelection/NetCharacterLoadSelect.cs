using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NetCharacterLoadSelect : NetworkBehaviour
{

        [SerializeField] 
        private Character[] characters = default;
        private int currentCharacterIndex = 0;
        
        public override void OnStartClient()
        {
           base.OnStartAuthority();
           currentCharacterIndex = PlayerPrefs.GetInt("selectedCharacterIndex");
           CmdSelect(currentCharacterIndex);
           
        }

        //[Command(requiresAuthority = false)]
        public void CmdSelect(int currentCharacterIndex, NetworkConnectionToClient sender = null)
        {
            GameObject characterInstance = Instantiate(characters[currentCharacterIndex].GameplayCharacterPrefab);
            //NetworkServer.Spawn(characterInstance, sender);
            NetworkServer.AddPlayerForConnection(sender, characterInstance);

           
        }








}