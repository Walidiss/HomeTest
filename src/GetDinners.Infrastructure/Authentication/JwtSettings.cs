﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Infrastructure.Authentication
{
    public class JwtSettings
    {

        public const string SectionName = "JwtSettings";
        public string Secret { get; init; } = null!;
        public string Issuer { get; init; } = null!;

        public string Audience { get; init; } = null!;

        public int ExpirationTimeInMinutes { get; init; } = 60;

    }
}
