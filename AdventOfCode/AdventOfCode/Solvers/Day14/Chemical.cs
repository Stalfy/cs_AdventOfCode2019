namespace AdventOfCode.Solvers.Day14 {
  public class Chemical {
    public int Units { get; set; }
    public string Name { get; set; }

    public Chemical(int units, string name) {
      Units = units;
      Name = name;
    }

    public override string ToString() {
      return string.Concat(Units, " ", Name);
    }
  }
}
