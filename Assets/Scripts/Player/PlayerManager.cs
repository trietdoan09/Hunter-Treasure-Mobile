using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    [SerializeField] private string nameCharacter;
    [SerializeField] private CharacterGender genderCharacter;
    [SerializeField] private CharacterClass characterClass;

    [SerializeField] private CharacterDatabase characterDatabase;
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        // Get the Animator component attached to the game object
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        id = 7;
        //LoadData();
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadCharacterID();
        id = data.characterID;
    }
    private void SpawnPlayer()
    {
        //var Player = Instantiate(spawnPlayer[id]);
        //Player.transform.position = gameObject.transform.position;
        Characters characters = characterDatabase.GetCharacters(id);
        gameObject.GetComponent<SpriteRenderer>().sprite = characters.sprite;
        nameCharacter = characters.name;
        genderCharacter = characters.gender;
        characterClass = characters.characterClass;
        animator.runtimeAnimatorController = characters.animatorController;
    }
}
