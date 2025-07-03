using BookStore.Models;
using Xunit;

namespace BookStore.Tests.Setup;

[CollectionDefinition("Test Collection")]
public class SharedTestCollection : ICollectionFixture<IntegrationTestFactory<Program>>
{

}