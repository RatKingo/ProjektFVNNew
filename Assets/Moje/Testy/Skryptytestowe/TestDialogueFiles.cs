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

        for (int i = 0; i < lines.Count; i++)
        {
            string line = lines[0];

            if(string.IsNullOrWhiteSpace(line))
                continue;
            
            DIALOUGE_LINE dl = DialougeParser.Parse(line);

            Debug.Log($"{dl.speaker.name} as [{(dl.speaker.castName != string.Empty ? dl.speaker.castName : dl.speaker.name)}]at {dl.speaker.castPosition}");

            List<(int l, string ex)> expr = dl.speaker.CastExpressions;
            for (int c = 0; c <expr.Count; c++)
            {
                Debug.Log($"[Layer[{expr[c].l}] = '{expr[c].ex}']");
            }
        }
        DialougeSystem.instance.Say(lines);
    }
}
}