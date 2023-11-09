using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DIALOUGE
{
public class ConversationManager 
{
    private DialougeSystem dialogueSystem => DialougeSystem.instance;

    private Coroutine process = null;
    public bool isRunning => process != null;

    public void StartConversation(List<string> conversation)
    {
        StopConversation();

        process = dialogueSystem.StartCoroutine(RunningConversation(conversation));

    }

    public void StopConversation()
    {
        if (!isRunning)
            return;

        dialogueSystem.StopCoroutine(process);
        process = null;
    }

    IEnumerator RunningConversation(List<string> conversation)
    {
        for(int i = 0; i < conversation.Count; i++)
            if (string.IsNullOrWhiteSpace(conversation[i]))
                continue;
            DIALOUGE_LINE line = DialougeParser.Parse(conversation[i]);

            if(line.hasDialogue)
                yield return Line_RunDialogue(line);
            
            if(line.hasCommands)
                yield return Line_RunCommands(line);
    }
    IEnumerator Line_RunDialogue(DIALOUGE_LINE line)
    {
    
    }

  IEnumerator Line_RunCommands(DIALOUGE_LINE line)
    {
    
    }
}
  
}
