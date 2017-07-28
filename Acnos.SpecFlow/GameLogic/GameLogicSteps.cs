using Acnos.GameLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Acnos.SpecFlow.GameLogic
{
    [Binding]
    public sealed class GameLogicSteps
    {
        [Given(@"(?i)the current game phase is (.*)")]
        public void GivenTheCurrentGamePhaseIs(GamePhase phase)
        {
            ScenarioContext.Current["GamePhase"] = phase;
        }

        [Given(@"(?i)the current game board is the following")]
        public void GivenTheCurrentGameBoardIsTheFollowing(Table table)
        {
            var rows = table.CreateSet<GameBoardRow>().ToArray();
            Assert.AreEqual(8, rows.Length, "Game board definition must have eight rows.");
            Assert.IsFalse(rows.Where((r, i) => i + r.Row != 8).Any(), 
                "Game board definition must list rows in reverse order from 8 to 1.");
            ScenarioContext.Current["GameBoard"] = rows;
        }

        [When(@"(?i)I retrieve available actions")]
        public void WhenIRetrieveAvailableActions()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"(?i)the available actions are the following")]
        public void ThenTheAvailableActionsAreTheFollowing(Table table)
        {
            if (!ScenarioContext.Current.ContainsKey("AvailableActions"))
                Assert.Fail("Cannot compare available actions before available actions are retrieved.");
            var expected = new HashSet<string>(table.CreateSet(tr => tr.GetString("Action")));
            var actual = new HashSet<string>(ScenarioContext.Current["AvailableActions"] as IEnumerable<string> ?? new string[] { });
            var expectedNotFound = expected.Except(actual).ToArray();
            var unexpected = actual.Except(expected).ToArray();
            var sb = new StringBuilder();
            if (expectedNotFound.Length > 0)
            {
                sb.Append("Expected actions were not found: ");
                sb.Append(string.Join(", ", expectedNotFound));
                if (unexpected.Length > 0)
                    sb.Append("; ");
            }
            if (unexpected.Length > 0)
            {
                sb.Append("Unexpected actions were found: ");
                sb.Append(string.Join(", ", unexpected));
            }
            Assert.AreEqual(0, expectedNotFound.Length + unexpected.Length, sb.ToString());
        }

        [Given(@"(?i)player one's next piece is (.*)")]
        public void GivenPlayerOneSNextPieceIs(Shape shape)
        {
            ScenarioContext.Current["PLayer1Next"] = shape;
        }

        [Given(@"(?i)player two's next piece is (.*)")]
        public void GivenPlayerTwoSNextPieceIs(Shape shape)
        {
            ScenarioContext.Current["Player2Next"] = shape;
        }

        [Given(@"(?i)player one's piece bag contains:(.*)")]
        public void GivenPlayerOneSPieceBagContains(string bag)
        {
            ScenarioContext.Current["Player1Bag"] = bag;
        }

        [Given(@"(?i)player two's piece bag contains:(.*)")]
        public void GivenPlayerTwoSPieceBagContains(string bag)
        {
            ScenarioContext.Current["Player2Bag"] = bag;
        }
    }
}
