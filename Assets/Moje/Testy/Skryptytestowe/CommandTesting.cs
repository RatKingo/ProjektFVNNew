using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using COMMANDS;

public class CommandTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Running());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CommandManager.instance.Execute("moveCharDemo", "left");
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            CommandManager.instance.Execute("moveCharDemo", "right");
    }

    IEnumerator Running()
    {
        yield return CommandManager.instance.Execute("print");
        yield return CommandManager.instance.Execute("print_lp", "Bombaa!");
        yield return CommandManager.instance.Execute("print_mp", "line1", "line2", "line3");

        yield return CommandManager.instance.Execute("lambda");
        yield return CommandManager.instance.Execute("lambda_lp", "Bum Lambda!");
        yield return CommandManager.instance.Execute("lambda_mp", "lamb1", "lamb2", "lamb3");

        yield return CommandManager.instance.Execute("process");
        yield return CommandManager.instance.Execute("process_lp", "3");
        yield return CommandManager.instance.Execute("process_mp", "ProcesLine 1", "ProcesLine 2", "ProcesLine 3");
    }
}
