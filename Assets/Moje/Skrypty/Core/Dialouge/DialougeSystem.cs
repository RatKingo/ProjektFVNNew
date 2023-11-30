using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOUGE
{
public class DialougeSystem : MonoBehaviour
{
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

    public void ShowSpeakerName(string speakerName = "") 
    {
        if (speakerName.ToLower() != "narrator")
        dialougeContainer.nameContainer.Show(speakerName);
        else 
        HideSpeakerName();

    }

    public void HideSpeakerName() => dialougeContainer.nameContainer.Hide();


    public void Say(string speaker, string dialogue)
    {
        List<string> conversation = new List<string>() {$"{speaker} \"{dialogue}\""};
        Say(conversation);
    }

    public void Say(List<string> conversation)
    {
        conversationManager.StartConversation(conversation);

    }

}
}