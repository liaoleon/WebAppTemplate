using System;
using System.Linq;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebAppTemplate.Repo;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Service.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        private IOrderRepo _repo;

        [TestInitialize]
        public void TestInitialize()
        {
            //_repo = new IMockOrderRepo();
            _repo = Substitute.For<IOrderRepo>();
        }


        private OrderService GetSystemUnderTest()
        {
            return new OrderService(_repo);
        }

        [TestMethod]
        public void GetAll_取得所有訂單_應30筆()
        {
            //arrange 
            int expected = 30;
            var sut = GetSystemUnderTest();
            //act
            var actual = sut.GetAll().Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAll_取得所有訂單_應30筆_ByNsub()
        {
            //arrange 
            int expected = 30;

            Fixture f = new Fixture();
            var source=f.Build<Orders>().OmitAutoProperties().CreateMany(30).AsQueryable();
            _repo.GetAll().Returns(source);

            var sut = GetSystemUnderTest();
            //act
            var actual = sut.GetAll().Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
