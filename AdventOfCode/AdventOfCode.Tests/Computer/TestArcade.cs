using NUnit.Framework;

using System.Drawing;

using AdventOfCode.Computer;

namespace AdventOfCode.Tests {
  public class ArcadeTests {
    [Test]
    public void TestUpdateMaxX() {
      Arcade a = new Arcade(new long[1]);
      Point p = new Point(4, 0);
      a.UpdateTile(p, (int) Arcade.Tile.Wall);

      Assert.That(a.MaxX, Is.EqualTo(4));
    }

    [Test]
    public void TestUpdateMaxY() {
      Arcade a = new Arcade(new long[1]);
      Point p = new Point(0, 4);
      a.UpdateTile(p, (int) Arcade.Tile.Wall);

      Assert.That(a.MaxY, Is.EqualTo(4));
    }

    [Test]
    public void TestInsertTile() {
      Arcade a = new Arcade(new long[1]);
      Point p = new Point(0, 4);
      a.UpdateTile(p, (int) Arcade.Tile.Wall);

      Assert.That(a.Tiles.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestUpdateTile() {
      Arcade a = new Arcade(new long[1]);
      Point p = new Point(0, 4);
      a.UpdateTile(p, (int) Arcade.Tile.Wall);
      a.UpdateTile(p, (int) Arcade.Tile.Empty);

      Assert.That(a.Tiles.Count, Is.EqualTo(1));
      Assert.That(a.Tiles[p], Is.EqualTo(Arcade.Tile.Empty));
    }

    [Test]
    public void TestCountTilesOfType() {
      Arcade a = new Arcade(new long[1]);
      a.UpdateTile(new Point(0, 4), (int) Arcade.Tile.Wall);
      a.UpdateTile(new Point(1, 4), (int) Arcade.Tile.Wall);
      a.UpdateTile(new Point(2, 4), (int) Arcade.Tile.Wall);
      a.UpdateTile(new Point(3, 4), (int) Arcade.Tile.Empty);
      a.UpdateTile(new Point(4, 4), (int) Arcade.Tile.Empty);

      Assert.That(a.CountTilesOfType(Arcade.Tile.Wall), Is.EqualTo(3));
      Assert.That(a.CountTilesOfType(Arcade.Tile.Empty), Is.EqualTo(2));
      Assert.That(a.CountTilesOfType(Arcade.Tile.Ball), Is.EqualTo(0));
    }

    [Test]
    public void TestGetVisualRepresentation() {
      Arcade a = new Arcade(new long[1]);
      a.UpdateTile(new Point(0, 0), (int) Arcade.Tile.Empty);
      a.UpdateTile(new Point(1, 0), (int) Arcade.Tile.Wall);
      a.UpdateTile(new Point(2, 0), (int) Arcade.Tile.Block);
      a.UpdateTile(new Point(3, 0), (int) Arcade.Tile.HorizontalPaddle);
      a.UpdateTile(new Point(4, 0), (int) Arcade.Tile.Ball);

      Assert.That(a.GetVisualRepresentation(), Is.EqualTo(".+#~O\n"));
    }
  }
}
