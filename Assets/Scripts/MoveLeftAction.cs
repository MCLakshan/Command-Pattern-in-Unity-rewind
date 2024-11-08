public class MoveLeftAction : ActionBase {

    public MoveLeftAction(Unit unit) : base(unit) { }

    public override void Execute() {
        Unit.MoveLeft();
    }

    public override void Undo() {
        Unit.MoveRight();
    }
}