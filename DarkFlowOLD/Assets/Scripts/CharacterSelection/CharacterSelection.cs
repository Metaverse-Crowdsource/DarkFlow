using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public int selectedCharacterIndex = 0;

	public void NextCharacter()
	{
		characters[selectedCharacterIndex].SetActive(false);
		selectedCharacterIndex = (selectedCharacterIndex + 1) % characters.Length;
		characters[selectedCharacterIndex].SetActive(true);
		
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
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
}
