using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Domain.Common.Errors;

    public static partial class Errors
    {
        public static class User{

        public static Error DuplicateEmail => Error.Conflict(
            code: "Duplicate.Email",
            description:"Email is already in use" );
            }
    }
