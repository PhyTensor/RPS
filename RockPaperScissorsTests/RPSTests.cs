using RockPaperScissorsLib.Enums;
using RockPaperScissorsLib.GameManagers;
using RockPaperScissorsLib.Players;

namespace RockPaperScissorsTests.Tests;

[TestFixture]
public class RPSTests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void RockBeatsScissors()
    {
        GameManager gm = new GameManager(
            new ForcedPlayer(Choice.Rock),
            new ForcedPlayer(Choice.Scissors)
        );

        /*Assert.AreEqual(RoundResult.Player1Win, gm.PlayRound());*/
        Assert.That(gm.PlayRound(), Is.EqualTo(RoundResult.Player1Win));
    }

    [TestCase(Choice.Rock, Choice.Scissors)]
    [TestCase(Choice.Scissors, Choice.Paper)]
    [TestCase(Choice.Paper, Choice.Rock)]
    public void Player1AlwaysWins_ReturnTrue(Choice choice1, Choice choice2)
    {
        GameManager gm = new GameManager(new ForcedPlayer(choice1), new ForcedPlayer(choice2));

        Assert.That(gm.PlayRound(), Is.EqualTo(RoundResult.Player1Win));
    }
}

