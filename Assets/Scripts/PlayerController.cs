using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ActionRecorder actionRecorder;
    [SerializeField] private Unit PlayerUnit;


    void Update()
    {
        // Move the player to the front
        if(Input.GetKeyDown(KeyCode.W)) { 
            var action = new MoveFrontAction(PlayerUnit);
            //action.Execute();
            actionRecorder.Record(action);

            //GetComponent<Unit>().MoveFront();
        }

        // Move the player to the back
        if (Input.GetKeyDown(KeyCode.S)) {
            var action = new MoveBackAction(PlayerUnit);
            actionRecorder.Record(action);
            //GetComponent<Unit>().MoveBack();
        }

        // Move the player to the left
        if (Input.GetKeyDown(KeyCode.A)) {
            var action = new MoveLeftAction(PlayerUnit);
            actionRecorder.Record(action);
            //GetComponent<Unit>().MoveLeft();
        }

        // Move the player to the right
        if (Input.GetKeyDown(KeyCode.D)) {
            var action = new MoveRightAction(PlayerUnit);
            actionRecorder.Record(action);
            //GetComponent<Unit>().MoveRight();
        }

        // Rewind the player's action
        if (Input.GetKeyDown(KeyCode.R)) {
            actionRecorder.Rewind();
        }
    }
}
