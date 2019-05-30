using Nethereum.StandardTokenEIP20;
using Nethereum.Web3;
using System;
using System.Threading.Tasks;

namespace TokenTok
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestGettingTokBalanceAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static async Task TestGettingTokBalanceAsync()
        {
            // Ethereum network to connect to            
            var ethereumNetworkUrl = "https://rinkeby.infura.io/";

            // There is a ERC20 token called TOK deployed on Rinkeby here:
            // https://rinkeby.etherscan.io/address/0xb3c021fefdfddc53cedbcbb34659a40f759fdd72#contracts
            var erc20TokenContractAddress = "0xb3c021fefdfddc53cedbcbb34659a40f759fdd72";
            var accountWithSomeTokTokens = "0x043F19855cC8B31941f72d4728A4D32c0476A70d";

            // Setup web3 and token service, to allow us to interact with ERC20 contract
            var web3 = new Web3(ethereumNetworkUrl);
            var tokenService = new StandardTokenService(web3, erc20TokenContractAddress);

            // Check an address balance
            var symbol = await tokenService.SymbolQueryAsync();
            var tokens = await tokenService.BalanceOfQueryAsync(accountWithSomeTokTokens);
            Console.WriteLine($"Address: {accountWithSomeTokTokens} holds: {tokens} {symbol}");
        }
    }
}
