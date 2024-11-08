using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for recording and rewinding the player's actions.
public class ActionRecorder : MonoBehaviour
{
    private readonly Stack<ActionBase> actions = new Stack<ActionBase>();

    // Record the player's action
    public void Record(ActionBase action) {

        // Push the action onto the stack
        actions.Push(action);

        // Execute the action
        action.Execute();
    }

    // Rewind the player's action
    public void Rewind() {

        // Check if there are any actions to rewind
        var action = actions.Pop();

        // Undo the action
        action.Undo();
    }
}
