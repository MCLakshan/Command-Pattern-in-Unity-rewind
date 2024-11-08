// This class is the base class for all actions that can be executed by a unit.
// It contains the Execute and Undo methods that must be implemented by all derived classes.
// The Execute method is called when the action is executed, and the Undo method is called when the action is undone.
// The Unit property is a reference to the unit that is executing the action. This class is abstract

public abstract class ActionBase {
    protected readonly Unit Unit;

    protected ActionBase(Unit unit) {
        Unit = unit;
    }

    public abstract void Execute();

    public abstract void Undo();
}