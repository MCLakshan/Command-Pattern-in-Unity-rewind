public class MoveRightAction : ActionBase {

    public MoveRightAction(Unit unit) : base(unit) { }

    public override void Execute() {
        Unit.MoveRight();
    }

    public override void Undo() {
        Unit.MoveLeft();
    }
}