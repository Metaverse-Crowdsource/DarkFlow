using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
    //public GameObject[] characterPrefabs;	
	//public Transform spawnPoint;
	
	public SkinnedMeshRenderer skinnedMeshRenderer;
	public Mesh[] meshToChange;
	public Material[] materialToChange;

	void Start()
	{
		int selectedCharacter = PlayerPrefs.GetInt("selectedCharacterIndex");
		
		//GameObject prefab = characterPrefabs[selectedCharacter];
		//Instantiate(prefab, spawnPoint.position, Quaternion.identity);
		
		 skinnedMeshRenderer.sharedMesh = meshToChange[selectedCharacter];
		 skinnedMeshRenderer.material = materialToChange[selectedCharacter];
      



	}

}
