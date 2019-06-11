using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    public class Tennis
    {
        private string _partScore;
        private string _partScore2;
        private string _scoreResult;

        public Tennis(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
        }

        public string Player1Name { get; }

        public int Player1PointCount { get; set; }
        public string Player2Name { get; }

        public int Player2PointCount { get; set; }

        public void CountScoreResult()
        {
            PointCase();
            if (IsEqual())
            {
                IsDeuce();
            }
            else
            {
                Point2Case();
                if (IsGamePoint())
                {
                    IsWin();
                }
            }
        }

        public bool IsDeuce()
        {
            if (Player1PointCount >= 3)
            {
                _partScore = "";
                _partScore2 = "Deuce";
                return true;
            }

            return false;
        }

        public bool IsEqual()
        {
            if (Player1PointCount == Player2PointCount)
            {
                _partScore2 = " All";
                return true;
            }

            return false;
        }

        public bool IsGamePoint()
        {
            var result = false;
            if (Player2PointCount > 3 || Player1PointCount > 3)
            {
                if (Math.Abs(Player1PointCount - Player2PointCount) >= 1)
                {
                    string playerName;
                    if (Player1PointCount > Player2PointCount)
                    {
                        playerName = Player1Name;
                    }
                    else
                    {
                        playerName = Player2Name;
                    }
                    _partScore = playerName;
                    _partScore2 = " Adv";
                    result = true;
                }
            }

            return result;
        }

        public void Point2Case()
        {
            switch (Player2PointCount)
            {
                case 0:
                    _partScore2 = " Love";
                    break;

                case 1:
                    _partScore2 = " Fifteen";
                    break;

                case 2:
                    _partScore2 = " Thirty";
                    break;

                case 3:
                    _partScore2 = " Forty";
                    break;

                default:
                    _partScore2 = "";
                    break;
            }
        }

        public void PointCase()
        {
            switch (Player1PointCount)
            {
                case 0:
                    _partScore = "Love";
                    break;

                case 1:
                    _partScore = "Fifteen";
                    break;

                case 2:
                    _partScore = "Thirty";
                    break;

                case 3:
                    _partScore = "Forty";
                    break;

                default:
                    _partScore = "";
                    break;
            }
        }

        public string Score()
        {
            CountScoreResult();
            _scoreResult = _partScore + _partScore2;
            return _scoreResult;
        }

        public void SetPointCount(int point1, int point2)
        {
            Player1PointCount = point1;
            Player2PointCount = point2;
        }

        private bool IsWin()
        {
            var result = false;
            if (Math.Abs(Player1PointCount - Player2PointCount) >= 2)
            {
                string playerName;
                if (Player1PointCount > Player2PointCount)
                {
                    playerName = Player1Name;
                    result = true;
                }
                else
                {
                    playerName = Player2Name;
                }
                _partScore = playerName;
                _partScore2 = " Win";
            }

            return result;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        private readonly Tennis _tennis = new Tennis("Sherry", "April");

        [TestMethod]
        public void Deuce()
        {
            _tennis.SetPointCount(3, 3);
            var score = _tennis.Score();
            Assert.AreEqual("Deuce", score);
        }

        [TestMethod]
        public void Fifteen_All()
        {
            _tennis.SetPointCount(1, 1);
            var score = _tennis.Score();
            Assert.AreEqual("Fifteen All", score);
        }

        [TestMethod]
        public void Fifteen_Forty()
        {
            _tennis.SetPointCount(1, 3);
            var score = _tennis.Score();
            Assert.AreEqual("Fifteen Forty", score);
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            _tennis.SetPointCount(1, 0);
            var score = _tennis.Score();
            Assert.AreEqual("Fifteen Love", score);
        }

        [TestMethod]
        public void Fifteen_Thirty()
        {
            _tennis.SetPointCount(1, 2);
            var score = _tennis.Score();
            Assert.AreEqual("Fifteen Thirty", score);
        }

        [TestMethod]
        public void Forty_Fifteen()
        {
            _tennis.SetPointCount(3, 1);
            var score = _tennis.Score();
            Assert.AreEqual("Forty Fifteen", score);
        }

        [TestMethod]
        public void Forty_Love()
        {
            _tennis.SetPointCount(3, 0);
            var score = _tennis.Score();
            Assert.AreEqual("Forty Love", score);
        }

        [TestMethod]
        public void Forty_Thirty()
        {
            _tennis.SetPointCount(3, 2);
            var score = _tennis.Score();
            Assert.AreEqual("Forty Thirty", score);
        }

        [TestMethod]
        public void Love_All()
        {
            _tennis.SetPointCount(0, 0);
            var score = _tennis.Score();
            Assert.AreEqual("Love All", score);
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            _tennis.SetPointCount(0, 1);
            var score = _tennis.Score();
            Assert.AreEqual("Love Fifteen", score);
        }

        [TestMethod]
        public void Love_Forty()
        {
            _tennis.SetPointCount(0, 3);
            var score = _tennis.Score();
            Assert.AreEqual("Love Forty", score);
        }

        [TestMethod]
        public void Love_Thirty()
        {
            _tennis.SetPointCount(0, 2);
            var score = _tennis.Score();
            Assert.AreEqual("Love Thirty", score);
        }

        [TestMethod]
        public void Player1_Adv()
        {
            _tennis.SetPointCount(4, 3);
            var score = _tennis.Score();
            Assert.AreEqual("Sherry Adv", score);
        }

        [TestMethod]
        public void Player1_Win()
        {
            _tennis.SetPointCount(5, 3);
            var score = _tennis.Score();
            Assert.AreEqual("Sherry Win", score);
        }

        [TestMethod]
        public void Player2_Adv()
        {
            _tennis.SetPointCount(3, 4);
            var score = _tennis.Score();
            Assert.AreEqual("April Adv", score);
        }

        [TestMethod]
        public void Player2_Win()
        {
            _tennis.SetPointCount(3, 5);
            var score = _tennis.Score();
            Assert.AreEqual("April Win", score);
        }

        [TestMethod]
        public void Thirty_All()
        {
            _tennis.SetPointCount(2, 2);
            var score = _tennis.Score();
            Assert.AreEqual("Thirty All", score);
        }

        [TestMethod]
        public void Thirty_Fifteen()
        {
            _tennis.SetPointCount(2, 1);
            var score = _tennis.Score();
            Assert.AreEqual("Thirty Fifteen", score);
        }

        [TestMethod]
        public void Thirty_Forty()
        {
            _tennis.SetPointCount(2, 3);
            var score = _tennis.Score();
            Assert.AreEqual("Thirty Forty", score);
        }

        [TestMethod]
        public void Thirty_Love()
        {
            _tennis.SetPointCount(2, 0);
            var score = _tennis.Score();
            Assert.AreEqual("Thirty Love", score);
        }
    }
}