using NUnit.Framework;

using System.Collections.Generic;

using AdventOfCode.Solvers.Day14;

namespace AdventOfCode.Tests {
  public class NanofactoryTests {

    [Test]
    public void TestParseReactionSingleInput() {
      string entry = "32 ORE => 28 A";
      Nanofactory n = new Nanofactory();

      Reaction reaction = n.ParseReaction(entry);

      Assert.That(reaction, Is.Not.EqualTo(null));
      Assert.That(reaction.Inputs.Count, Is.EqualTo(1));
      Assert.That(reaction.Inputs[0].Units, Is.EqualTo(32));
      Assert.That(reaction.Inputs[0].Name, Is.EqualTo("ORE"));
      Assert.That(reaction.Output.Units, Is.EqualTo(28));
      Assert.That(reaction.Output.Name, Is.EqualTo("A"));
    }

    [Test]
    public void TestParseReactionMultipleInputs() {
      string entry = "1 A, 2 B, 3 C => 4 D";
      Nanofactory n = new Nanofactory();
      Reaction reaction = n.ParseReaction(entry);

      Assert.That(reaction, Is.Not.EqualTo(null));
      Assert.That(reaction.Inputs.Count, Is.EqualTo(3));
      Assert.That(reaction.Inputs[0].Units, Is.EqualTo(1));
      Assert.That(reaction.Inputs[0].Name, Is.EqualTo("A"));
      Assert.That(reaction.Inputs[1].Units, Is.EqualTo(2));
      Assert.That(reaction.Inputs[1].Name, Is.EqualTo("B"));
      Assert.That(reaction.Inputs[2].Units, Is.EqualTo(3));
      Assert.That(reaction.Inputs[2].Name, Is.EqualTo("C"));
      Assert.That(reaction.Output.Units, Is.EqualTo(4));
      Assert.That(reaction.Output.Name, Is.EqualTo("D"));
    }

    [Test]
    public void TestParseInput() {
      string[] input = new string[] { "1 A => 1 B", "1 C, 1 D => 1 E" };
      Nanofactory n = new Nanofactory();
      List<Reaction> reactions = n.ParseInput(input);
      Assert.That(reactions.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestCombineInputs() {
      List<Chemical> inputs = new List<Chemical>();
      inputs.Add(new Chemical(1, "A"));
      inputs.Add(new Chemical(2, "A"));

      Reaction reaction = new Reaction(inputs, null);
      Nanofactory n = new Nanofactory();
      n.CombineInputs(reaction);

      Assert.That(reaction.Inputs.Count, Is.EqualTo(1));
      Assert.That(reaction.Inputs[0].Units, Is.EqualTo(3));
    }

    [Test]
    public void TestCombineReactions() {
      List<Chemical> inA = new List<Chemical>() { new Chemical(28, "A") };
      Chemical outA = new Chemical(1, "FUEL");
      Reaction a = new Reaction(inA, outA);

      List<Chemical> inB = new List<Chemical>() { new Chemical(10, "ORE") };
      Chemical outB = new Chemical(10, "A");
      Reaction b = new Reaction(inB, outB);

      Nanofactory n = new Nanofactory();
      n.CombineReactions(a, b);
      Assert.That(a.Inputs[0].Units, Is.EqualTo(30));
      Assert.That(a.Inputs[0].Name, Is.EqualTo("ORE"));
    }

    [Test]
    public void TestCanCombine() {
      List<Chemical> inA = new List<Chemical>() { new Chemical(28, "A") };
      Chemical outA = new Chemical(1, "FUEL");
      Reaction a = new Reaction(inA, outA);

      List<Chemical> inB = new List<Chemical>() { new Chemical(10, "ORE") };
      Chemical outB = new Chemical(10, "A");
      Reaction b = new Reaction(inB, outB);

      Nanofactory n = new Nanofactory();
      Assert.That(n.CanCombine(b, a), Is.EqualTo(false));
      Assert.That(n.CanCombine(a, b), Is.EqualTo(true));
    }

    [Test]
    public void TestCountDependencies() {
      List<Chemical> inA = new List<Chemical>() { new Chemical(1, "C") };
      Chemical outA = new Chemical(1, "A");
      Reaction a = new Reaction(inA, outA);

      List<Chemical> inB = new List<Chemical>() { new Chemical(1, "C") };
      Chemical outB = new Chemical(1, "B");
      Reaction b = new Reaction(inB, outB);

      List<Chemical> inC = new List<Chemical>() { new Chemical(1, "ORE") };
      Chemical outC = new Chemical(1, "C");
      Reaction c = new Reaction(inC, outC);

      List<Reaction> reactions = new List<Reaction>();
      reactions.Add(a);
      reactions.Add(b);
      reactions.Add(c);

      Nanofactory n = new Nanofactory();
      Assert.That(n.CountDependencies(a, reactions), Is.EqualTo(0));
      Assert.That(n.CountDependencies(b, reactions), Is.EqualTo(0));
      Assert.That(n.CountDependencies(c, reactions), Is.EqualTo(2));
    }
  }
}
