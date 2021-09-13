using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteFuncional_FeriadoAnbima.Fixtures
{
    [CollectionDefinition("Chrome Driver")]
    class CollectionFixture : ICollectionFixture<TestFixtures>
    {
    }
}
