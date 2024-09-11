using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitDinners.Application.UnitTests.TestUtils.Constants
{
    public static partial class Constants
    {

        public static class Menu
        {
            public const string Name = "Menu Name";
            public const string Description = "Menu Description";
            public const string SectionName = "Menu SectionName";
            public const string SectionDescription = "Menu SectionDescription";
            public const string ItemName = "Menu ItemName";
            public const string ItemDescription = "Menu ItemDescription";

            public static string SectionNameFromIndex(int index) 
                => $"{SectionName}{index}";
            
            public static string SectionDescritpionFromIndex(int index)
                => $"{SectionDescription}{index}";

            public static string ItemNameFromIndex(int index) 
                =>$"{ItemName} {index}";

            public static string ItemDescriptionFromIndex (int index)
                => $"{ItemName}{index}";

        }
    }
}
