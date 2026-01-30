using System.Net.Http.Headers;
using EgzaminPróbny;

namespace TestProject
{
    [TestClass]
    public sealed class BoardGameManagerTest
    {
        [TestMethod]
        public void CalculatReward_HighAvg_Test()
        {
            //Arrange
            var tp1 = new TournamentPlayer("XD", "XD", EnumLeague.Gold);
            tp1.AddScores(new double[] { 9.5, 8.0, 9.0, 10.0, 9.5, 10.0 });

            var expectedReward = BoardGamePlayer.BasePrice + TournamentPlayer.BonusPrice;

            //Act
            var actualReward = tp1.CalculateReward();

            //Assert
            Assert.AreEqual(expectedReward, actualReward);
        }

        [TestMethod]
        public void AddScoreBelowRangeArgumentOutOfRangeException()
        {
            //Arrange
            var tp1 = new BoardGamePlayer("XD", "XD");
            var scores = new double[] { -3.00,  9.5, 8.0, -9.0, 10.0, 9.5, 10.0 };

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tp1.AddScores(scores));
        }
    }
}
