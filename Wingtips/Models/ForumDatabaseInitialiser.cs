using System.Collections.Generic;
using System.Data.Entity;

namespace Wingtips.Models
{
    public class ForumDatabaseInitialiser : DropCreateDatabaseIfModelChanges<ForumContext>
    {
        protected override void Seed(MemberContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetMembers().ForEach(p => context.Members.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Cars"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Planes"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Trucks"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Boats"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Rockets"
                },
            };

            return categories;
        }

        private static List<Member> GetMembers()
        {
            var Members = new List<Member> {
                new Member
                {
                    User_Name = 1,
                    First_Name = "Convertible Car",
                    Description = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." + 
                                  "Power it up and let it go!", 
                    ImagePath="carconvert.png",
                    UnitPrice = 22.50,
                    CategoryID = 1
               },
                new Member 
                {
                    User_Name = 2,
                    First_Name = "Old-time Car",
                    Description = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.",
                    ImagePath="carearly.png",
                    UnitPrice = 15.95,
                     CategoryID = 1
               },
                new Member
                {
                    User_Name = 3,
                    First_Name = "Fast Car",
                    Description = "Yes this car is fast, but it also floats in water.",
                    ImagePath="carfast.png",
                    UnitPrice = 32.99,
                    CategoryID = 1
                },
                new Member
                {
                    User_Name = 4,
                    First_Name = "Super Fast Car",
                    Description = "Use this super fast car to entertain guests. Lights and doors work!",
                    ImagePath="carfaster.png",
                    UnitPrice = 8.95,
                    CategoryID = 1
                },
                new Member
                {
                    User_Name = 5,
                    First_Name = "Old Style Racer",
                    Description = "This old style racer can fly (with user assistance). Gravity controls flight duration." + 
                                  "No batteries required.",
                    ImagePath="carracer.png",
                    UnitPrice = 34.95,
                    CategoryID = 1
                },
                new Member
                {
                    User_Name = 6,
                    First_Name = "Ace Plane",
                    Description = "Authentic airplane toy. Features realistic color and details.",
                    ImagePath="planeace.png",
                    UnitPrice = 95.00,
                    CategoryID = 2
                },
                new Member
                {
                    User_Name = 7,
                    First_Name = "Glider",
                    Description = "This fun glider is made from real balsa wood. Some assembly required.",
                    ImagePath="planeglider.png",
                    UnitPrice = 4.95,
                    CategoryID = 2
                },
                new Member
                {
                    User_Name = 8,
                    First_Name = "Paper Plane",
                    Description = "This paper plane is like no other paper plane. Some folding required.",
                    ImagePath="planepaper.png",
                    UnitPrice = 2.95,
                    CategoryID = 2
                },
                new Member
                {
                    User_Name = 9,
                    First_Name = "Propeller Plane",
                    Description = "Rubber band powered plane features two wheels.",
                    ImagePath="planeprop.png",
                    UnitPrice = 32.95,
                    CategoryID = 2
                },
                new Member
                {
                    User_Name = 10,
                    First_Name = "Early Truck",
                    Description = "This toy truck has a real gas powered engine. Requires regular tune ups.",
                    ImagePath="truckearly.png",
                    UnitPrice = 15.00,
                    CategoryID = 3
                },
                new Member
                {
                    User_Name = 11,
                    First_Name = "Fire Truck",
                    Description = "You will have endless fun with this one quarter sized fire truck.",
                    ImagePath="truckfire.png",
                    UnitPrice = 26.00,
                    CategoryID = 3
                },
                new Member
                {
                    User_Name = 12,
                    First_Name = "Big Truck",
                    Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                    ImagePath="truckbig.png",
                    UnitPrice = 29.00,
                    CategoryID = 3
                },
                new Member
                {
                    User_Name = 13,
                    First_Name = "Big Ship",
                    Description = "Is it a boat or a ship. Let this floating vehicle decide by using its " + 
                                  "artifically intelligent computer brain!",
                    ImagePath="boatbig.png",
                    UnitPrice = 95.00,
                    CategoryID = 4
                },
                new Member
                {
                    User_Name = 14,
                    First_Name = "Paper Boat",
                    Description = "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!" + 
                                  "Some folding required.",
                    ImagePath="boatpaper.png",
                    UnitPrice = 4.95,
                    CategoryID = 4
                },
                new Member
                {
                    User_Name = 15,
                    First_Name = "Sail Boat",
                    Description = "Put this fun toy sail boat in the water and let it go!",
                    ImagePath="boatsail.png",
                    UnitPrice = 42.95,
                    CategoryID = 4
                },
                new Member
                {
                    User_Name = 16,
                    First_Name = "Rocket",
                    Description = "This fun rocket will travel up to a height of 200 feet.",
                    ImagePath="rocket.png",
                    UnitPrice = 122.95,
                    CategoryID = 5
                }
            };

            return Members;
        }
    }
}