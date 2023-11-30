using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOUGE
{
public class DIALOUGE_LINE

{
    public DL_SPEAKER_DATA speaker;
    public DL_DIALOGUE_DATA dialogue;
    public string commands;

    public bool hasSpeaker => speaker != null;
    public bool hasDialogue => dialogue.hasDialogue;
    public bool hasCommands => commands != string.Empty;

    public DIALOUGE_LINE(string speaker, string dialogue, string commands)
    {
        this.speaker = (string.IsNullOrWhiteSpace(speaker) ? null : new DL_SPEAKER_DATA(speaker));
        this.dialogue = new DL_DIALOGUE_DATA(dialogue);
        this.commands = commands;
    }
}
}