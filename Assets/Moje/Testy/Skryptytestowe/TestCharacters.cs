using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;

namespace TESTING
{
public class TestCharacters : MonoBehaviour
{
    void Start()
    {
        Character FishByte = CharacterManager.instance.CreateCharacter("FishByte");
    }

    
}
}