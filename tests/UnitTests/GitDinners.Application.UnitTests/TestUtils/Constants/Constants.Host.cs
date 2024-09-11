using GetDinners.Domain.Hosts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitDinners.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Host
        {
            public static readonly HostId Id = HostId.Create(Guid.NewGuid());
        }
    }
}
