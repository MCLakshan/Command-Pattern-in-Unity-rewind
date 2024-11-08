public class MoveBackAction : ActionBase {

    public MoveBackAction(Unit unit) : base(unit) { }

    public override void Execute() {
        Unit.MoveBack();
    }

    public override void Undo() {
        Unit.MoveFront();
    }
}