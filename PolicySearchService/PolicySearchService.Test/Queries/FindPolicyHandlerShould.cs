using System.Collections.Generic;
using System.Threading.Tasks;
using PolicySearchService.Api.Queries;
using PolicySearchService.Domain;
using PolicySearchService.Queries;
using Xunit;

namespace PolicySearchService.Test.Queries;

public class FindPolicyHandlerShould
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ReturnNoResultsForEmptySearch(string query)
    {
        var repository = new FakePolicyRepository();
        var result = await new FindPolicyHandler(repository)
            .Handle(new FindPolicyQuery { QueryText = query }, default);

        Assert.Empty(result.Policies);
        Assert.Equal(0, repository.FindCalls);
    }

    private sealed class FakePolicyRepository : IPolicyRepository
    {
        public int FindCalls { get; private set; }

        public Task Add(Policy policy) => Task.CompletedTask;

        public Task<List<Policy>> Find(string queryText)
        {
            FindCalls++;
            return Task.FromResult(new List<Policy>());
        }
    }
}
