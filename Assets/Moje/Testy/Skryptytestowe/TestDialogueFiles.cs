using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOUGE
{
public class TestDialogueFiles : MonoBehaviour
{
    void Start()
    {
        StartConversation();
    }
      
    void StartConversation()
    {
        List<string> lines = FileManager.ReadTextAsset("testFile");

        DialougeSystem.instance.Say(lines);
    }
}
}