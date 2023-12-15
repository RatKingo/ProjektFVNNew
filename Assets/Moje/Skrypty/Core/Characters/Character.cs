using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOUGE;
using TMPro;

namespace CHARACTERS
{
    public abstract class Character
    {
        public string name = "";
        public string displayName = "";
        public RectTransform root = null;
        public CharacterConfigData config;

        public DialougeSystem dialogueSystem => DialougeSystem.instance;

        public Character(string name, CharacterConfigData config)
        {
            this.name = name;
            displayName = name;
            this.config = config;
        }

        public Coroutine Say(string dialogue) => Say(new List<string> {dialogue});
        public Coroutine Say(List<string> dialogue)
        {
            dialogueSystem.ShowSpeakerName(displayName);
            UpdateTextCustomizationsOnScreen();
            return dialogueSystem.Say(dialogue);
        }
        public void SetNameFont(TMP_FontAsset font) => config.nameFont = font;

        public void SetDialogueFont(TMP_FontAsset font) => config.dialogueFont = font;

        public void SetNameColor(Color color) => config.nameColor = color;

        public void SetDialogueColor(Color color) => config.dialogueColor = color;

        public void ResetConfigurtaionData() => config = CharacterManager.instance.GetCharacterConfig(name);

        public void UpdateTextCustomizationsOnScreen() => dialogueSystem.ApplySpeakerDataToDialogueContainer(config);


        public enum CharacterType
        {
            Text,
            Sprite,
            SpriteSheet,
        }
    }
}