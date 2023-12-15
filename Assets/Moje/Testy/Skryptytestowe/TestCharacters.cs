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
    void Start()
    {
        
        //Character Milka = CharacterManager.instance.CreateCharacter("Milka");
        //Character Ronnie = CharacterManager.instance.CreateCharacter("Ronnie");
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        Character FishByte = CharacterManager.instance.CreateCharacter("FishByte");
        Character Milka = CharacterManager.instance.CreateCharacter("Milka");

        List<string> lines = new List<string>()
        {
            "\"Hello!\"",
            "\"You look like a snack.\"",
            "\"Tasty {a} One.\"",
            "\"I could eat you up.\""
        };
        yield return FishByte.Say(lines);

        FishByte.SetNameColor(Color.yellow);
        FishByte.SetDialogueColor(Color.green);
        FishByte.SetNameFont(tempFont);
        FishByte.SetDialogueFont(tempFont);

        yield return FishByte.Say(lines);

        FishByte.ResetConfigurtaionData();

        yield return FishByte.Say(lines);

        lines = new List<string>()
        {
            "\"Want to taste our new blend? {c} It's called Blondie\"",
            "\"It's selling real..{wa 1} well!\""
        };
        yield return Milka.Say(lines);

        Debug.Log("Finished");
    }

    void Update()
    {

    }
}
}