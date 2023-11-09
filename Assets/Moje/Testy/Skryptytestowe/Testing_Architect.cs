using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOUGE;

namespace TESTING
{
public class Testing_Architect : MonoBehaviour
{
    DialougeSystem ds;
    TextArchitect architect;

    string[] lines = new string[5]
    {
        "Yo, maybe wanna go check out my bronysona?",
        "Haha just kidding yo",
        "...Unless?",
        "Anyway let me show you my hot wheels collection",
        "*Jesse takes off his shoes and around 20 hotwheels fall out*",
    };

    void Start()
    {
        ds = DialougeSystem.instance;
        architect = new TextArchitect(ds.dialougeContainer.dialougeText);
        architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        architect.speed = 0.5f;
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (architect.isBuilding)
            {
                if(!architect.hurryUp)
                architect.hurryUp = true;
                else
                architect.ForceComplete();
            }
            else
        architect.Build(lines[Random.Range(0, lines.Length)]);
        }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
        architect.Append(lines[Random.Range(0, lines.Length)]);
        }

    }
}
}
