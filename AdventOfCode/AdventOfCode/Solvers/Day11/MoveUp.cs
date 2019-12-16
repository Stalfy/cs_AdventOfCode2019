namespace AdventOfCode.Solvers.Day11 {
  public class MoveUp : Move {
    public void Move(ref int x, ref int y) {
      y -= 1;
    }
  }
}
