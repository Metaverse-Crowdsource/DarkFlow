using UnityEngine;

   [CreateAssetMenu(fileName = "New Character", menuName = "Character")]
    public class Character : ScriptableObject
    {
        [SerializeField] private string characterName = default;
        [SerializeField] private GameObject characterPreviewPrefab = default;
        [SerializeField] private GameObject gameplayCharacterPrefab = default;

        public string CharacterName => characterName;
        public GameObject CharacterPreviewPrefab => characterPreviewPrefab;
        public GameObject GameplayCharacterPrefab => gameplayCharacterPrefab;
    }

