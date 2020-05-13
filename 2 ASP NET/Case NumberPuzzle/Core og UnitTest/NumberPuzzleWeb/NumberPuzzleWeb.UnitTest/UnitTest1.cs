using NUnit.Framework;

namespace NumberPuzzleWeb.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestIsNotSolved()
        {
            var gameModel = new GameModel(new[] { 1, 2, 3, 4, 5, 6, 7, 0, 8 });
            Assert.AreEqual(false, gameModel.IsSolved):
        }
        [Test]
        public void TestIsNotSolved()
        {
            var gameModel = new GameModel(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 });
            Assert.AreEqual(false, gameModel.IsSolved):
        }
    }
}