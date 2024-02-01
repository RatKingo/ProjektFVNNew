using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOUGE;
using TMPro;


namespace TESTING
{
public class TestCharacters : MonoBehaviour
{
    public TMP_FontAsset tempFont;

    private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);
    void Start()
    {
        //Character Ronnie = CharacterManager.instance.CreateCharacter("Ronnie");
        //Character ronnie = CharacterManager.instance.CreateCharacter("Ronnie");
        //Character Shark = CharacterManager.instance.CreateCharacter("Shark");
        StartCoroutine(Test());

    }

    IEnumerator Test()
    {
        Character Ronnie = CreateCharacter("Ronnie as Generic");

        Ronnie.Show();

        Ronnie.SetDialogueFont(tempFont);
        Ronnie.SetNameFont(tempFont);

        yield return Ronnie.Say("Mam dosc codziennie to samo, szarosc.");

        yield return null;
    }

    void Update()
    {

    }
}
}