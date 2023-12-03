using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMD_DatabaseExtension_Example : CMD_DatabaseExtension
{
    new public static void Extend(CommandDatabase database)
    {
        //Add command with no parameters
        database.AddCommand("print", new Action(PrintDefaultMessage));
        database.AddCommand("print_lp", new Action<string>(PrintUsermessage));
        database.AddCommand("print_mp", new Action<string[]>(PrintLines));
    }

    private static void PrintDefaultMessage()
    {
        Debug.Log("Printing a default message to console.");
    }

    private static void PrintUsermessage(string message)
    {
        Debug.Log($"User Message: '{message}'");
    }

    private static void PrintLines(string[] lines)
    {
        int i = 1;
        foreach(string line in lines)
        {
            Debug.Log($"{i++}. '{line}'");
        }
    }
}
