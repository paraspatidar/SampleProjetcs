using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaxyLibrary;
using GalaxyLibrary.Helpers;
using FluentAssertions;
using LanguageProcessor;
using GalaxyLibrary.Unity;
using Unity;

namespace Galaxy.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void RomanToDecimalTest()
        {
            var Decimal_I = RomanProcessor.Instance.ConvertRomanToDecimal("I");
            var Decimal_V = RomanProcessor.Instance.ConvertRomanToDecimal("V");
            var Decimal_X = RomanProcessor.Instance.ConvertRomanToDecimal("X");
            var Decimal_L = RomanProcessor.Instance.ConvertRomanToDecimal("L");
            var Decimal_C = RomanProcessor.Instance.ConvertRomanToDecimal("C");
            var Decimal_D = RomanProcessor.Instance.ConvertRomanToDecimal("D");
            var Decimal_M = RomanProcessor.Instance.ConvertRomanToDecimal("M");

            Assert.AreEqual(1, Decimal_I);
            Assert.AreEqual(5, Decimal_V);
            Assert.AreEqual(10, Decimal_X);
            Assert.AreEqual(50, Decimal_L);
            Assert.AreEqual(100, Decimal_C);
            Assert.AreEqual(500, Decimal_D);
            Assert.AreEqual(1000, Decimal_M);
        }

        [TestMethod]
        public void GetQueryRegExTest()
        {
            var Queries = ConfigHelper.Instance.GetQueryRegEx();
            Queries.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void GetQueryConfiguration()
        {
            var Queries = ConfigHelper.Instance.GetQueryConfiguration();
            Queries.Count.Should().BeGreaterThan(0);
            Queries.TrueForAll(x => x.Length != 0);
        }

        [TestMethod]
        public void QueryParserTest_Declaritive()
        {
            string query = "A is I";
            string expectedResult = Constants.Querytype.DECLARATIONQUERY;

            var container = DependencyResolver.DependencyRegiration();
            var oConcreteQueryFactory = container.Resolve<ConcreteQueryFactory>();
            var parsed_query = oConcreteQueryFactory.ParseQuery(query);

            parsed_query.QueryName.Should().Be(expectedResult);

        }



        [TestMethod]
        public void QueryParserTest_Credit()
        {
            string query = "how many Credits is F H S Silver ?";
            string expectedResult = Constants.Querytype.CREDITQUERY;
            var container = DependencyResolver.DependencyRegiration();
            var oConcreteQueryFactory = container.Resolve<ConcreteQueryFactory>();
            var parsed_query = oConcreteQueryFactory.ParseQuery(query);

            parsed_query.QueryName.Should().Be(expectedResult);

        }



        [TestMethod]
        public void QueryParserTest_Quantitive()
        {
            string query = "how much is E F G H I J K L ?";
            string expectedResult = Constants.Querytype.QUNATITIVEQUERY;
            var container = DependencyResolver.DependencyRegiration();
            var oConcreteQueryFactory = container.Resolve<ConcreteQueryFactory>();
            var parsed_query = oConcreteQueryFactory.ParseQuery(query);

            parsed_query.QueryName.Should().Be(expectedResult);

        }

        [TestMethod]
        public void QueryParserTest_CalculativeDeclaritive()
        {
            string query = "C D F Iron is 100 Credits";
            string expectedResult = Constants.Querytype.CALCULATIVEDECLARATIVEQUERY;
            var container = DependencyResolver.DependencyRegiration();
            var oConcreteQueryFactory = container.Resolve<ConcreteQueryFactory>();
            var parsed_query = oConcreteQueryFactory.ParseQuery(query);

            parsed_query.QueryName.Should().Be(expectedResult);

        }


        [TestMethod]
        public void QueryProcessorTest__Declaritive()
        {
            RomanNumber  romanNum;
            QueryProcessor queryProcessor = new QueryProcessor();

            queryProcessor.ProcessQuery("A is I");
            queryProcessor.oConcreteQueryFactory
              .dataMappingHolder.RomanConstantsTable
              .Keys.Should().Contain("A");

            queryProcessor.oConcreteQueryFactory.dataMappingHolder.RomanConstantsTable.TryGetValue("A", out romanNum);
            romanNum.DecimalValue.Should().Be(1);
        }

        [TestMethod]
        public void QueryProcessorTest_CalculativeDeclaritive()
        {
            double _decimal;
            QueryProcessor queryProcessor = new QueryProcessor();

            queryProcessor.ProcessQuery("A is X");
            queryProcessor.ProcessQuery("B is I");
            queryProcessor.ProcessQuery("C is V");
            queryProcessor.ProcessQuery("A B C Silver is 28 Credits");

            queryProcessor.oConcreteQueryFactory
              .dataMappingHolder.DeclarativeCalculationTable
              .Keys.Should().Contain("Silver");

            queryProcessor.oConcreteQueryFactory.dataMappingHolder.DeclarativeCalculationTable.TryGetValue("Silver", out _decimal);
            _decimal.Should().Be(2);
        }

        [TestMethod]
        public void QueryProcessorTest_Quantitive()
        {
            
            QueryProcessor queryProcessor = new QueryProcessor();

            queryProcessor.ProcessQuery("A is X");
            queryProcessor.ProcessQuery("B is I");
            queryProcessor.ProcessQuery("C is V");
            queryProcessor.ProcessQuery("D is I");
            var result=queryProcessor.ProcessQuery("how much is A B C ?");
            result.Should().Contain("14");
            result = queryProcessor.ProcessQuery("how much is A B C D ?");
            result.Should().EndWith("15"); 
        }

        [TestMethod]
        public void QueryProcessorTest_Credit()
        {
            
            QueryProcessor queryProcessor = new QueryProcessor();

            queryProcessor.ProcessQuery("A is X");
            queryProcessor.ProcessQuery("B is I");
            queryProcessor.ProcessQuery("C is V");
            queryProcessor.ProcessQuery("A B C Silver is 28 Credits");

            var result = queryProcessor.ProcessQuery("how many Credits is B A Silver ?");
            result.Should().Contain("18");
            result = queryProcessor.ProcessQuery("how many Credits is B C Silver ?");
            result.Should().EndWith("8 Credits");
        }

        [TestMethod]
        public void QueryProcessorTest_Invalid()
        {

            QueryProcessor queryProcessor = new QueryProcessor();

            var result = queryProcessor.ProcessQuery("how are you ?");
            result.Should().Contain("I have no idea what you are talking about");
        }
    }
}
