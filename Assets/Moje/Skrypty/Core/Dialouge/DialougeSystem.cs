using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CHARACTERS;

namespace DIALOUGE
{
public class DialougeSystem : MonoBehaviour
{
    [SerializeField] private DialogueSystemConfigurationSO _config;
    public DialogueSystemConfigurationSO config => _config;

    public DialougeContainer dialougeContainer = new DialougeContainer();
    private ConversationManager  conversationManager;
    private TextArchitect architect;
    
    public static DialougeSystem instance {get; private set;}

    public delegate void DialougeSystemEvent();
    public event DialougeSystemEvent onUserPrompt_Next;

    public bool isRunningConversation => conversationManager.isRunning;

    private void Awake()
    {
        if (instance == null)
            {
                instance = this;
                Initialize();
            }
        else 
            DestroyImmediate(gameObject);
    }

    bool _initialized = false;

    private void Initialize()
    {
        if(_initialized)
            return;

        architect = new TextArchitect(dialougeContainer.dialougeText);
        conversationManager = new ConversationManager(architect);
    }

    public void OnUserPrompt_Next()
    {
        onUserPrompt_Next?.Invoke();
    }

    public void ApplySpeakerDataToDialogueContainer(string speakerName)
    {
        Character character = CharacterManager.instance.GetCharacter(speakerName);
        CharacterConfigData config = character != null ? character.config : CharacterManager.instance.GetCharacterConfig(speakerName);

        ApplySpeakerDataToDialogueContainer(config);
    }

    public void ApplySpeakerDataToDialogueContainer(CharacterConfigData config)
    {
        dialougeContainer.SetDialogueColor(config.dialogueColor);
        dialougeContainer.SetDialogueFont(config.dialogueFont);
        dialougeContainer.nameContainer.SetNameColor(config.nameColor);
        dialougeContainer.nameContainer.SetNameFont(config.nameFont);

    }

    public void ShowSpeakerName(string speakerName = "") 
    {
        if (speakerName.ToLower() != "narrator")
            dialougeContainer.nameContainer.Show(speakerName);
        else 
            HideSpeakerName();
    }

    public void HideSpeakerName() => dialougeContainer.nameContainer.Hide();

    public Coroutine Say(string speaker, string dialogue)
    {
        List<string> conversation = new List<string>() {$"{speaker} \"{dialogue}\""};
        return Say(conversation);
    }

    public Coroutine Say(List<string> conversation)
    {
        return conversationManager.StartConversation(conversation);
    }
}
}