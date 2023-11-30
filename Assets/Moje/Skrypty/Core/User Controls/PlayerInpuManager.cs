using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOUGE
{
public class PlayerInpuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            PromptAdvance();
        
    }

    public void PromptAdvance()
    {
        DialougeSystem.instance.OnUserPrompt_Next();
    }


}
}