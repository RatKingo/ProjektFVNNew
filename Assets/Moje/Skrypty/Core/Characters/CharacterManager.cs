using DIALOUGE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager instance { get; private set; }
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();

        private CharacterConfigSO config => DialougeSystem.instance.config.characterConfigurationAsset;

        private void Awake()
        {
            instance = this;
        }

        public CharacterConfigData GetCharacterConfig(string characterName)
        {
            return config.GetConfig(characterName);
        }

        public Character GetCharacter(string characterName, bool createIfDoesExist = false)
        {
            if(characters.ContainsKey(characterName.ToLower()))
                return characters[characterName.ToLower()];
            else if (createIfDoesExist)
                return CreateCharacter(characterName);

                return null;
        }

        public Character CreateCharacter(string characterName)
        {
            if (characters.ContainsKey(characterName.ToLower()))
            {
                Debug.LogWarning($"A Character called '{characterName}' already exists. Did not create the character");
                return null;
            }
            CHARACTER_INFO info = GetCharacterInfo(characterName);
            Character character = CreateCharacterFromInfo(info);
            if(character != null)
            {
            characters.Add(characterName.ToLower(), character);
            }

            return character;
        }

        private CHARACTER_INFO GetCharacterInfo(string characterName)
        {
            CHARACTER_INFO result = new CHARACTER_INFO();

            result.name = characterName;

            result.config = config.GetConfig(characterName);

            return result;
        }

        private Character CreateCharacterFromInfo(CHARACTER_INFO info)
        {
          CharacterConfigData config = info.config;
            
            switch(info.config.characterType)
            {
                case Character.CharacterType.Text:
                    return new Character_Text(info.name, config);
                
                 case Character.CharacterType.Sprite:
                 case Character.CharacterType.SpriteSheet:
                    return new Character_Sprite(info.name, config);
                
                default:
                    return null;
            }
        }


        private class CHARACTER_INFO
        {
            public string name = "";

            public CharacterConfigData config = null;
        }
    }
}