using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOUGE;

namespace DIALOUGE
{
public class TestDialogueFiles : MonoBehaviour
{
    [SerializeField] private TextAsset fileToRead = null;

    void Start()
    {
        StartConversation();
    }
      
    void StartConversation()
    {
        
    List<string> lines = FileManager.ReadTextAsset(fileToRead);

       //foreach (string line in lines)
       //{
        //if (string.IsNullOrWhiteSpace(line))
           // continue;
        //DIALOUGE_LINE dl = DialougeParser.Parse(line);

        //for(int i = 0; i < dl.commands.commands.Count; i++)
        //{
            //DL_COMMAND_DATA.Command command = dl.commands.commands[i];
           // Debug.Log($"Command [{i}] '{command.name}' has arguments [{string.Join(", ", command.arguments)}]");
        //}
      // }
        DialougeSystem.instance.Say(lines);
    }
}
}