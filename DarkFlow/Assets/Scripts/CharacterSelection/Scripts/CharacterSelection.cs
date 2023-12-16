using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public int selectedCharacterIndex = 0;
	//public string selectedCharacterName = "";

	public void NextCharacter()
	{
		characters[selectedCharacterIndex].SetActive(false);
		selectedCharacterIndex = (selectedCharacterIndex + 1) % characters.Length;
		characters[selectedCharacterIndex].SetActive(true);
		
		//selectedCharacterName = characters[selectedCharacterIndex].name;
		
		//Debug.Log(selectedCharacterName);
	}

	public void PreviousCharacter()
	{
		characters[selectedCharacterIndex].SetActive(false);
		selectedCharacterIndex--;
		if (selectedCharacterIndex < 0)
		{
			selectedCharacterIndex += characters.Length;
		}
		characters[selectedCharacterIndex].SetActive(true);
	}

	public void StartGame()
	{
		PlayerPrefs.SetInt("selectedCharacterIndex", selectedCharacterIndex);
		//PlayerPrefs.SetString("selectedCharacterName", selectedCharacterName);
		
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
}
