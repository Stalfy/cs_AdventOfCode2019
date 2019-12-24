namespace AdventOfCode.Solvers.Day14 {
  public class Chemical {
    public long Units { get; set; }
    public string Name { get; set; }

    public Chemical(long units, string name) {
      Units = units;
      Name = name;
    }

    public override string ToString() {
      return string.Concat(Units, " ", Name);
    }
  }
}
