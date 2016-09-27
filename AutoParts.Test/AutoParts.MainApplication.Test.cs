using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoParts.MainApplication.Services;
using AutoParts.Model;
using Moq;
using NUnit.Framework;

namespace AutoParts.Test
{
    [TestFixture]
    public class AutoParts
    {
        [OneTimeSetUp]
        public void CreateDependencies()
        {
            
        }

        [Test]
        public void ShouldLoadAllCoffees()
        {
            //Arrange
            ObservableCollection<Parts> parts = null;
            var mock = new Mock<IDataAccessService>(MockBehavior.Loose);
            var expectedParts = coffeeDataService.GetAllCoffees();

            //act
            var viewModel = GetViewModel();
            coffees = viewModel.Coffees;

            //assert
            CollectionAssert.AreEqual(expectedCoffees, coffees);
        }
    }
}
