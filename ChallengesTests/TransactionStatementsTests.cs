using HackerrankChallenges.ChallengesSolutions;
using System.Threading.Tasks;
using Xunit;

namespace ChallengesTests
{
    public class TransactionStatementsTests
    {
        [Fact]
        public async Task TransactionTest()
        {
            var locationId = 999;
            var transactionType = "testinho";

            var teste = await TransactionStatements.totalTransactions(locationId, transactionType);
        }
    }
}
