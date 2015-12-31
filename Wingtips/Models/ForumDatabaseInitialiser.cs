using System.Collections.Generic;
using System.Data.Entity;

namespace Gathering.Models
{
    public class ForumDatabaseInitialiser : DropCreateDatabaseIfModelChanges<MemberContext>
    {
        protected override void Seed(MemberContext context)
        {
            GetPlatforms().ForEach(c => context.Platforms.Add(c));
            GetMembers().ForEach(p => context.Members.Add(p));
        }

        private static List<Platform> GetPlatforms()
        {
            var Platforms = new List<Platform> {
                new Platform
                {
                    PlatformID = 1,
                    Device = "Desktop"
                },
                new Platform
                {
                    PlatformID = 2,
                    Device = "Laptop"
                },
                new Platform
                {
                    PlatformID = 3,
                    Device = "Mobile"
                },
            };

            return Platforms;
        }

        private static List<Member> GetMembers()
        {
            var Members = new List<Member> {
                new Member
                {
                    Device = "Desktop",
                    PlatformID = 1
               },
                new Member 
                {
                    Device = "Laptop",
                    PlatformID = 1
               },
                new Member
                {
                    Device = "Mobile",
                    PlatformID = 1
                },
               
            };

            return Members;
        }
    }
}