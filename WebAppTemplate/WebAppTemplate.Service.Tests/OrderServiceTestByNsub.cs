using System;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebAppTemplate.Repo;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Service.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        private IOrderRepo _NsubRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            _NsubRepo = Substitute.For<IOrderRepo>();
        }

        private OrderService GetSystemUnderTestByNsub()
        {
            return new OrderService(_NsubRepo);
        }

        [TestMethod]
        public void GetAll_取得所有訂單_應30筆_ByNsub()
        {
            //arrange 
            int expected = 30;

            Fixture f = new Fixture();
            var source=f.Build<Orders>().OmitAutoProperties().CreateMany(30).AsQueryable();
            _NsubRepo.GetAll().Returns(source);

            var sut = GetSystemUnderTestByNsub();
            //act
            var actual = sut.GetAll().Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_新增資料_應無例外_byNsub()
        {
            //arrange 
            Fixture f = new Fixture();
            var source = f.Build<Orders>().OmitAutoProperties().Create();
            var sut = GetSystemUnderTestByNsub();
            //act
            Action action = () => sut.Add(source);
            //assert
            action.Should().NotThrow<Exception>();
        }

        [TestMethod]
        public void Add_新增資料_應出現例外_byNsub()
        {
            //arrange
            Orders source = null;
            var sut = GetSystemUnderTestByNsub();
            //act
            Action action = () => sut.Add(source);
            //assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Edit_修改資料_應無例外_byNsub()
        {
            //arrange 
            Fixture f = new Fixture();
            var source = f.Build<Orders>().OmitAutoProperties().Create();
            var sut = GetSystemUnderTestByNsub();
            //act
            Action action = () => sut.Edit(source);
            //assert
            action.Should().NotThrow<Exception>();
        }

        [TestMethod]
        public void Edit_修改資料_應出現例外_byNsub()
        {
            //arrange 
            Orders source = null;
            var sut = GetSystemUnderTestByNsub();
            //act
            Action action = () => sut.Edit(source);
            //assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Delete_修改資料_應無例外_byNsub()
        {
            //arrange 
            Fixture f = new Fixture();
            f.Customizations.Add(new RandomNumericSequenceGenerator(0, int.MaxValue));
            var source = f.Create<int>();
            var sut = GetSystemUnderTestByNsub();
            //act
            Action action = () => sut.Delete(source);
            //assert
            action.Should().NotThrow<Exception>();
        }

        [TestMethod]
        public void Delete_修改資料_應出現例外_byNsub()
        {
            //arrange 
            Fixture f = new Fixture();
            f.Customizations.Add(new RandomNumericSequenceGenerator(int.MinValue, 0));
            var source = f.Create<int>();
            var sut = GetSystemUnderTestByNsub();
            //act
            Action action = () => sut.Delete(source);
            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void GetByID_取得特定資料_應無例外_byNsub()
        {
            //arrange 
            Fixture f = new Fixture();
            f.Customizations.Add(new RandomNumericSequenceGenerator(0, int.MaxValue));
            var source = f.Create<int>();
            var sut = GetSystemUnderTestByNsub();
            //act
            Action action = () => sut.GetByID(source);
            //assert
            action.Should().NotThrow<Exception>();
        }

        [TestMethod]
        public void GetByID_取得特定資料_應出現例外_byNsub()
        {
            //arrange 
            Fixture f = new Fixture();
            f.Customizations.Add(new RandomNumericSequenceGenerator(int.MinValue, 0));
            var source = f.Create<int>();
            var sut = GetSystemUnderTestByNsub();
            //act
            Action action = () => sut.GetByID(source);
            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
