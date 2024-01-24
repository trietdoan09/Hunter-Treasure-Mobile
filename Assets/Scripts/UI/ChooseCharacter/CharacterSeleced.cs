using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSeleced : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public bool characterActive;
    public bool onChoosed;
    public GameObject blockCharacter;
    public GameObject selectedCharacter;
    CreateCharacter createCharacter;
    void Start()
    {
        createCharacter = FindObjectOfType<CreateCharacter>();
        selectedCharacter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        IsSelected();
    }
    public void IsSelected()
    {
        blockCharacter.SetActive(!characterActive);
        if (onChoosed)
        {
            if (characterActive)
            {
                selectedCharacter.SetActive(true);
            }
        }
        else
        {
            selectedCharacter.SetActive(false);
        }
    }
    public void SelectedCharacter()
    {
        createCharacter.characterId = id;
    }
}
