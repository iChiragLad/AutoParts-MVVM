using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoParts.Model;

namespace AutoParts.DataAccessLayer
{
    public class AutoPartsRepository : IAutoPartsRepository
    {
        List<Parts> parts;

        public AutoPartsRepository()
        {
            LoadParts();
        }
        public void DeletePart(Parts part)
        {
            parts.RemoveAll(x => x.Name == part.Name);
        }
        public List<Parts> GetAllParts()
        {
            return parts;
        }

        public Parts GetPartByID(int id)
        {
            return parts.Find(x => x.Id == id);
        }

        public void UpdatePart(Parts part)
        {
            var matchingPart = parts.FirstOrDefault(x => x.Name == part.Name);
            matchingPart.Name = part.Name;
            matchingPart.Price = part.Price;
            matchingPart.Quantity = part.Quantity;
            matchingPart.Description = part.Description;
        }

        private void LoadParts()
        {
            parts = new List<Parts>
            {
                new Parts()
                {
                    Id = 1,
                    Name = "Bolt",
                    Description = "First Description",
                    Quantity = 10,
                    Price = 100,
                    Dop = new DateTime(2015, 5, 26)
                },
                new Parts()
                {
                    Id = 2,
                    Name = "Screw",
                    Description = "Second Description",
                    Quantity = 8,
                    Price = 150,
                    Dop = new DateTime(2013, 8, 19)
                },
                new Parts()
                {
                    Id = 3,
                    Name = "Nut",
                    Description = "Third Description",
                    Quantity = 16,
                    Price = 700,
                    Dop = new DateTime(2015, 12, 30)
                },
                new Parts()
                {
                    Id = 4,
                    Name = "Oil",
                    Description = "Fourth Description",
                    Quantity = 18,
                    Price = 800,
                    Dop = new DateTime(2014, 8, 2)
                },
                new Parts()
                {
                    Id = 5,
                    Name = "Grease",
                    Description = "Fifth Description",
                    Quantity = 2,
                    Price = 450,
                    Dop = new DateTime(2011, 3, 11)
                },
                new Parts()
                {
                    Id = 6,
                    Name = "Cloth",
                    Description = "Sixth Description",
                    Quantity = 9,
                    Price = 1500,
                    Dop = new DateTime(2009, 10, 25)
                }
            };
        }
    }
}
