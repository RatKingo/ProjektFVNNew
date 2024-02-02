using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMMANDS
{
public class CommandDatabase
{
    private Dictionary<string, Delegate> database = new Dictionary<string, Delegate>();

    public bool hasCommand(string commandName) => database.ContainsKey(commandName);

    public void AddCommand(string commandName, Delegate command)
{
    if (database.ContainsKey(commandName))
    {
        // Handle the case where the command already exists
        Debug.LogWarning($"Command '{commandName}' already exists. Overwriting...");
        database[commandName] = command; // Optionally overwrite the existing command
    }
    else
    {
        database.Add(commandName, command);
    }
}

    public Delegate GetCommand(string commandName)
    {
         if (!database.ContainsKey(commandName))
        {
            Debug.LogError($"Command '{commandName}' does not exist in the database!");
            return null;
        }
        
        return database[commandName];
    }
}
}