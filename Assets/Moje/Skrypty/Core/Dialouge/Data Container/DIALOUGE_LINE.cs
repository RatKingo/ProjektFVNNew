using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOUGE
{
public class DIALOUGE_LINE

{
    public DL_SPEAKER_DATA speaker;
    public DL_DIALOGUE_DATA dialogue;
    public DL_COMMAND_DATA commands;

    public bool hasSpeaker => speaker != null;
    public bool hasDialogue => dialogue != null;
    public bool hasCommands => commands != null;

    public DIALOUGE_LINE(string speaker, string dialogue, string commands)
    {
        this.speaker = (string.IsNullOrWhiteSpace(speaker) ? null : new DL_SPEAKER_DATA(speaker));
        this.dialogue = (string.IsNullOrWhiteSpace(dialogue) ? null : new DL_DIALOGUE_DATA(dialogue));
        this.commands = (string.IsNullOrWhiteSpace(commands) ? null : new DL_COMMAND_DATA(commands));
    }
}
}