using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCurrencyConverterV2.Models;

namespace CurrencyConverter.Tests
{
    [TestFixture]
    public class CurrencyAPITests
    {

        [Test]
        public void GetAllListTest()
        {
            //Arrange
            var list =  APIModel.GetList();


            //Act


            //Assert
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);


        }

        [Test]
        public void GetResultAsyncTest()
        {
            //Arrange
            string from = "AZE";
            string to = "EUR";
            double amount = 100;

            //Act
            var currecy = APIModel.GetResult(from, to, amount);

            //Assert
            Assert.IsNotNull(currecy);

        }

        [Test]
        public void GetFalseResultTest()
        {
            //Arrange
            string from = "";
            string to = "";
            double amount = 0;

            //Act
            var currecy = APIModel.GetResult(from, to, amount);


            //Assert
            Assert.IsNull(currecy);
        }
    }
}
