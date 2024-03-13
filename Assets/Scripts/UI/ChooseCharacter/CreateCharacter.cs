using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CharacterClass
{
    None,
    Archer,
    Swordman,
    Wizard,
    Knight
}
public enum CharacterGender
{
    None,
    Male,
    Female
}
public class CreateCharacter : MonoBehaviour
{
    //chon class
    public CharacterClass characterClass;
    private bool onClickChooseClass;
    [SerializeField] private GameObject chooseClassArcher;
    [SerializeField] private GameObject chooseClassSword;
    [SerializeField] private GameObject chooseClassWizard;
    [SerializeField] private GameObject chooseClassKnight;
    //chon gender
    public CharacterGender characterGender;
    private bool onClickChooseGender;
    [SerializeField] private GameObject chooseMale;
    [SerializeField] private GameObject chooseFemale;

    //show characters
    public CharacterDatabase characterDatabase;
    [SerializeField] private GameObject[] listChar;
    [SerializeField] private GameObject lockShowList;

    //chon character
    public int characterId;
    public bool showCharacter;
    //character database


    void Start()
    {
        characterId = -1;
        characterGender = CharacterGender.None;
        characterClass = CharacterClass.None;
        lockShowList.SetActive(true);
        HideCharacter();

    }

    // Update is called once per frame
    void Update()
    {
        if (onClickChooseClass)
        {
            OnClassChoosed();
        }
        if (onClickChooseGender)
        {
            OnGenderChoosed();
        }
        if(characterGender != CharacterGender.None && characterClass != CharacterClass.None)
        {
            if (showCharacter)
            {
                lockShowList.SetActive(false);
                ShowCharaacters();
                showCharacter = false;
            }
            SelectCharacter();
        }

    }
    #region chon class
    public void ChooseClassArcher()
    {
        characterClass = CharacterClass.Archer;
        onClickChooseClass = true;
    }
    public void ChooseClassSwordMan()
    {
        characterClass = CharacterClass.Swordman;
        onClickChooseClass = true;
    }
    public void ChooseClassWizard()
    {
        characterClass = CharacterClass.Wizard;
        onClickChooseClass = true;
    }
    public void ChooseClassKnight()
    {
        characterClass = CharacterClass.Knight;
        onClickChooseClass = true;
    }
    public void OnClassChoosed()
    {
        chooseClassArcher.GetComponent<OnChooseClass>().onClassChoosed = false;
        chooseClassSword.GetComponent<OnChooseClass>().onClassChoosed = false;
        chooseClassWizard.GetComponent<OnChooseClass>().onClassChoosed = false;
        chooseClassKnight.GetComponent<OnChooseClass>().onClassChoosed = false;
        switch (characterClass)
        {
            case CharacterClass.Archer:
                chooseClassArcher.GetComponent<OnChooseClass>().onClassChoosed = true;
                break;
            case CharacterClass.Swordman:
                chooseClassSword.GetComponent<OnChooseClass>().onClassChoosed = true;
                break;
            case CharacterClass.Wizard:
                chooseClassWizard.GetComponent<OnChooseClass>().onClassChoosed = true;
                break;
            case CharacterClass.Knight:
                chooseClassKnight.GetComponent<OnChooseClass>().onClassChoosed = true;
                break;
            default:
                break;
        }
        showCharacter = true;
        onClickChooseClass = false;
    }
    #endregion
    #region chon gender
    public void ChooseGenderMale()
    {
        characterGender = CharacterGender.Male;
        onClickChooseGender = true;
    }
    public void ChooseGenderFemale()
    {
        characterGender = CharacterGender.Female;
        onClickChooseGender = true;
    }
    public void OnGenderChoosed()
    {
        chooseMale.GetComponent<OnChooseClass>().onClassChoosed = false;
        chooseFemale.GetComponent<OnChooseClass>().onClassChoosed = false;
        switch (characterGender)
        {
            case CharacterGender.Male:
                chooseMale.GetComponent<OnChooseClass>().onClassChoosed = true;
                break;
            case CharacterGender.Female:
                chooseFemale.GetComponent<OnChooseClass>().onClassChoosed = true;
                break;
            default: break;
        }
        showCharacter = true;
        onClickChooseGender = false;
    }
    #endregion
    #region show character
    public void ShowCharaacters()
    {

        for (int pos = 0; pos < 4; pos++)
        {
            listChar[pos].SetActive(false);
        }
        int i = 0;
        for (int j = 0; j < characterDatabase.CharacterCount; j++)
        {
            Characters characters = characterDatabase.GetCharacters(j);
            var _characterSprite = characters.sprite;
            var _characterGender = characters.gender;
            var _characterClass = characters.characterClass;
            var _characterName = characters.name;
            var _characterId = characters.id;
            var _characterActiveStatus = characters.activeStatus;
            if (_characterGender == characterGender && _characterClass == characterClass)
            {
                listChar[i].GetComponent<Image>().sprite = _characterSprite;
                listChar[i].GetComponent<CharacterSeleced>().id = _characterId;
                listChar[i].GetComponent<CharacterSeleced>().characterActive = _characterActiveStatus;
                listChar[i].SetActive(true);
                i++;
            }
        }
    }
    private void HideCharacter()
    {
        for (int pos = 0; pos < listChar.Length; pos++)
        {
            listChar[pos].SetActive(false);
        }
    }
    #endregion
    #region chon character
    public void SelectCharacter()
    {
        for(int i = 0; i < listChar.Length; i++)
        {
            var _id = listChar[i].GetComponent<CharacterSeleced>().id;
            if (_id == characterId)
            {
                listChar[i].GetComponent<CharacterSeleced>().onChoosed = true;
            }
            else
            {
                listChar[i].GetComponent<CharacterSeleced>().onChoosed = false;
            }
        }
    }

    public void PlayButton()
    {
        SaveSystem.SaveCharacterID(this);
        SceneManager.LoadScene("MainScene");

        SceneManager.LoadScene("MapVillage", LoadSceneMode.Additive);
    }
    #endregion
}
