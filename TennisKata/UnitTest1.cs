using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    public class Tennis
    {
        private string _player1Name;
        private int _player1Score;
        private string _player2Name;
        private int _player2Score;
        private string _score1;
        private string _score2;

        public string Player1Name => _player1Name;
        public string Player2Name => _player2Name;

        public string Score1
        {
            get
            {
                switch (_player1Score)
                {
                    case 0:
                        _score1 = "Love";
                        break;

                    case 15:
                        _score1 = "Fifteen";
                        break;

                    case 30:
                        _score1 = "Thirty";
                        break;

                    case 40:
                        _score1 = "Forty";
                        break;
                }

                if (_player1Score == 40 && _player1Score == _player2Score)
                {
                    _score1 = "";
                }

                return _score1;
            }
        }

        public string Score2
        {
            get
            {
                if (_player1Score == _player2Score)
                {
                    if (_player2Score != 40)
                    {
                        _score2 = "All";
                    }
                    else
                    {
                        _score2 = "Deuce";
                    }
                }
                else switch (_player2Score)
                    {
                        case 15:
                            _score2 = "Fifteen";
                            break;

                        case 40:
                            _score2 = "Forty";
                            break;

                        case 0:
                            _score2 = "Love";
                            break;
                    }

                return _score2;
            }
        }

        public string GetPlayerName()
        {
            var playerName = "";
            playerName = _player1Score > _player2Score ? Player1Name : Player2Name;

            return playerName;
        }

        public string Score()
        {
            if (Score2.Equals("Deuce"))
            {
                return $"{Score2}";
            }

            if (_player1Score == 41 || _player2Score == 41)
            {
                return $"{GetPlayerName()} Adv";
            }

            if (_player1Score == 42 || _player2Score == 42)
            {
                return $"{GetPlayerName()} Win";
            }
            return $"{Score1} {Score2}";
        }

        public void SetPlayer(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void SetScore(int player1Score, int player2Score)
        {
            _player1Score = player1Score;
            _player2Score = player2Score;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        private readonly Tennis _tennis = new Tennis();
        private string _score;

        [TestMethod]
        public void Fifteen_All()
        {
            _tennis.SetScore(15, 15);
            _score = _tennis.Score();
            Assert.AreEqual("Fifteen All", _score);
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            _tennis.SetScore(15, 0);
            _score = _tennis.Score();
            Assert.AreEqual("Fifteen Love", _score);
        }

        [TestMethod]
        public void Forty_All()
        {
            _tennis.SetScore(40, 40);
            _score = _tennis.Score();
            Assert.AreEqual("Deuce", _score);
        }

        [TestMethod]
        public void Forty_Fifteen()
        {
            _tennis.SetScore(40, 15);
            _score = _tennis.Score();
            Assert.AreEqual("Forty Fifteen", _score);
        }

        [TestMethod]
        public void Love_All()
        {
            _tennis.SetScore(0, 0);
            _score = _tennis.Score();

            Assert.AreEqual("Love All", _score);
        }

        [TestMethod]
        public void Player_Adv()
        {
            _tennis.SetPlayer("Sherry", "April");
            _tennis.SetScore(41, 40);
            _score = _tennis.Score();

            Assert.AreEqual("Sherry Adv", _score);
        }

        [TestMethod]
        public void Player_Win()
        {
            _tennis.SetPlayer("Sherry", "April");
            _tennis.SetScore(42, 40);
            _score = _tennis.Score();

            Assert.AreEqual("Sherry Win", _score);
        }

        [TestMethod]
        public void Thirty_All()
        {
            _tennis.SetScore(30, 30);
            _score = _tennis.Score();
            Assert.AreEqual("Thirty All", _score);
        }

        [TestMethod]
        public void Thirty_Fifteen()
        {
            _tennis.SetScore(30, 15);
            _score = _tennis.Score();
            Assert.AreEqual("Thirty Fifteen", _score);
        }

        [TestMethod]
        public void Thirty_Love()
        {
            _tennis.SetScore(30, 0);
            _score = _tennis.Score();
            Assert.AreEqual("Thirty Love", _score);
        }
    }
}