using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eddy.x12.DomainModels.Transportation.v4010;
using Eddy.x12.Mapping;
using Xunit;

namespace Eddy.Tests;

public class DomainMapCacheConcurrencyTests
{
    // DomainMapCache/MapCache are process-wide statics, so this only exercises a cold
    // cache if it is the first thing in the run to touch these types. Distinct types per
    // xUnit run keep it honest enough to have caught the original bug.
    [Fact]
    public void MapToSegments_IsSafeWhenCalledConcurrentlyOnAColdCache()
    {
        var exceptions = new List<Exception>();

        Parallel.For(0, 64, _ =>
        {
            try
            {
                new DomainMapper().MapToSegments(new Edi204_MotorCarrierLoadTender());
            }
            catch (Exception ex)
            {
                lock (exceptions) exceptions.Add(ex);
            }
        });

        Assert.True(exceptions.Count == 0,
            $"{exceptions.Count}/64 concurrent maps threw. First: {exceptions.FirstOrDefault()}");
    }
}
