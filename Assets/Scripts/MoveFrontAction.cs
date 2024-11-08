// This is the MoveFrontAction class, which is derived from the ActionBase class.
// It contains the Execute and Undo methods that are called when the action is executed and undone, respectively.
// The MoveFrontAction class is used to move a unit forward,
// and it overrides the Execute and Undo methods to implement this functionality.
// The MoveFrontAction class takes a Unit object as a parameter in its constructor and stores it in the Unit property.
// The Execute method calls the MoveFront method of the Unit object,
// and the Undo method calls the MoveBack method of the Unit object.
// This class is used to encapsulate the logic for moving a unit forward in a separate class,
// making it easier to manage and maintain the code.

public class MoveFrontAction : ActionBase {

    public MoveFrontAction(Unit unit) : base(unit) { }

    public override void Execute() {
        Unit.MoveFront();
    }

    public override void Undo() {
        Unit.MoveBack();
    }
}