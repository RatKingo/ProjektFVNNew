using DIALOUGE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING 
{
public class TestParsing : MonoBehaviour
{
    void Start()
    {
        SendFileToParse();
    }
      

    void SendFileToParse()
    {
        List<string> lines = FileManager.ReadTextAsset("testFile");

        foreach(string line in lines)
        {
            if(line == string.Empty)
                continue;

            DIALOUGE_LINE dl = DialougeParser.Parse(line);
        }
    }
}
}