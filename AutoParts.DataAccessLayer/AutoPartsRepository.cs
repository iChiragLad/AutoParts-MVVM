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
            parts.Remove(part);
        }
        public List<Parts> GetAllParts()
        {
            return parts;
        }

        public Parts GetPartByID(int id)
        {
            return parts.Find(x => x.ID == id);
        }

        public void UpdatePart(Parts part)
        {
            var matchingPart = parts.FirstOrDefault(x => x.ID == part.ID);
            matchingPart.ID = part.ID;
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
                    ID = 1,
                    Description = "First Description",
                    Quantity = 10,
                    Price = 100
                },
                new Parts()
                {
                    ID = 2,
                    Description = "Second Description",
                    Quantity = 8,
                    Price = 150
                },
                new Parts()
                {
                    ID = 3,
                    Description = "Third Description",
                    Quantity = 16,
                    Price = 700
                },
                new Parts()
                {
                    ID = 4,
                    Description = "Fourth Description",
                    Quantity = 18,
                    Price = 800
                },
                new Parts()
                {
                    ID = 5,
                    Description = "Fifth Description",
                    Quantity = 2,
                    Price = 450
                },
                new Parts()
                {
                    ID = 6,
                    Description = "Sixth Description",
                    Quantity = 9,
                    Price = 1500
                }
            };
        }
    }
}
