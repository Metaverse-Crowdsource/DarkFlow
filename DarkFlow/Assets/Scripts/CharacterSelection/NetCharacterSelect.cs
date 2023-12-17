using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class NetCharacterSelect : NetworkBehaviour
    {
        [SerializeField] private GameObject characterSelectDisplay = default;
        [SerializeField] private Transform characterPreviewParent = default;
       
      
        [SerializeField] private Character[] characters = default;

        private int currentCharacterIndex = 0;

        private List<GameObject> characterInstances = new List<GameObject>();

        public override void OnStartClient()
        {
            if (characterPreviewParent.childCount == 0)
            {
                foreach (var character in characters)
                {
                    GameObject characterInstance =
                        Instantiate(character.CharacterPreviewPrefab, characterPreviewParent);

                    characterInstance.SetActive(false);

                    characterInstances.Add(characterInstance);
                }
            }

            characterInstances[currentCharacterIndex].SetActive(true);
            

            characterSelectDisplay.SetActive(true);
        }


        public void Right()
        {
            characterInstances[currentCharacterIndex].SetActive(false);

            currentCharacterIndex = (currentCharacterIndex + 1) % characterInstances.Count;

            characterInstances[currentCharacterIndex].SetActive(true);
            
        }

        public void Left()
        {
            characterInstances[currentCharacterIndex].SetActive(false);

            currentCharacterIndex--;
            if (currentCharacterIndex < 0)
            {
                currentCharacterIndex += characterInstances.Count;
            }

            characterInstances[currentCharacterIndex].SetActive(true);
            
        }
    
        // this 
        public void Select()
        {
            CmdSelect(currentCharacterIndex);
            characterSelectDisplay.SetActive(false);
        
        }

        [Command(requiresAuthority = false)]
        
        public void CmdSelect(int characterIndex, NetworkConnectionToClient sender = null)
        {
            GameObject characterInstance = Instantiate(characters[characterIndex].GameplayCharacterPrefab);
            NetworkServer.Spawn(characterInstance, sender);

            //SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

    
    
    
    
    
    
    
    }

