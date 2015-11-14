using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoefficientLib.Test
{
    [TestClass]
    public class CoefficientLibTest
    {
        public const string TEST_DATA_FILEPATH = "CoefficientData.json";

        /// <summary>
        /// 初始化数据文件
        /// </summary>
        [TestInitialize]	
        public void Setup()
        {
            CoefficientDataService.InitDataFile(TEST_DATA_FILEPATH);
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Arrange 准备测试数据
            CoefficientDataService coefficientDataService = new CoefficientDataService(TEST_DATA_FILEPATH);

            var testData1 = new { Province = "广西", City = "柳州", Season = "夏季", ExpectCoefficient = 0.3M };
            var testData2 = new { Province = "广西", City = "柳州", Season = "春季", ExpectCoefficient = 0.35M };
            var testData3 = new { Province = "广西", City = "柳州", Season = "冬季", ExpectCoefficient = 0.9M };
            var testData4 = new { Province = "湖南", City = "湘潭", Season = "冬季", ExpectCoefficient = 0.9M };
            var testData5 = new { Province = "湖南", City = "湘潭", Season = "春季", ExpectCoefficient = 0.35M };
            var testData6 = new { Province = "湖南", City = "湘潭", Season = "夏季", ExpectCoefficient = 0.55M };
            var testData7 = new { Province = "湖南", City = "湘潭", Season = "秋季", ExpectCoefficient = 0.6M };
            var testData8 = new { Province = "湖北", City = "武汉", Season = "春季", ExpectCoefficient = 0.35M };
            var testData9 = new { Province = "湖北", City = "武汉", Season = "夏季", ExpectCoefficient = 0.6M };
            var testData10 = new { Province = "湖北", City = "武汉", Season = "秋季", ExpectCoefficient = 0.48M };
            var testData11 = new { Province = "湖北", City = "武汉", Season = "冬季", ExpectCoefficient = 0.9M }; 
 
            //Act 执行测试

            decimal coefficientValue1 = coefficientDataService.GetCoefficient(testData1.Province, testData1.City,testData1.Season);
            decimal coefficientValue2 = coefficientDataService.GetCoefficient(testData2.Province, testData2.City, testData2.Season);
            decimal coefficientValue3 = coefficientDataService.GetCoefficient(testData3.Province, testData3.City, testData3.Season);
            decimal coefficientValue4 = coefficientDataService.GetCoefficient(testData4.Province, testData4.City, testData4.Season);
            decimal coefficientValue5 = coefficientDataService.GetCoefficient(testData5.Province, testData5.City, testData5.Season);
            decimal coefficientValue6 = coefficientDataService.GetCoefficient(testData6.Province, testData6.City, testData6.Season);
            decimal coefficientValue7 = coefficientDataService.GetCoefficient(testData7.Province, testData7.City, testData7.Season);
            decimal coefficientValue8 = coefficientDataService.GetCoefficient(testData8.Province, testData8.City, testData8.Season);
            decimal coefficientValue9 = coefficientDataService.GetCoefficient(testData9.Province, testData9.City, testData9.Season);
            decimal coefficientValue10 = coefficientDataService.GetCoefficient(testData10.Province, testData10.City, testData10.Season);
            decimal coefficientValue11 = coefficientDataService.GetCoefficient(testData11.Province, testData11.City, testData11.Season);

            //Assert 验证结果

            Assert.AreEqual(testData1.ExpectCoefficient, coefficientValue1, testData1.Province + "-" + testData1.City + "-" + testData1.Season);
            Assert.AreEqual(testData2.ExpectCoefficient, coefficientValue2, testData2.Province + "-" + testData2.City + "-" + testData2.Season);
            Assert.AreEqual(testData3.ExpectCoefficient, coefficientValue3, testData3.Province + "-" + testData3.City + "-" + testData3.Season);
            Assert.AreEqual(testData4.ExpectCoefficient, coefficientValue4, testData4.Province + "-" + testData4.City + "-" + testData4.Season);
            Assert.AreEqual(testData5.ExpectCoefficient, coefficientValue5, testData5.Province + "-" + testData5.City + "-" + testData5.Season);
            Assert.AreEqual(testData6.ExpectCoefficient, coefficientValue6, testData6.Province + "-" + testData6.City + "-" + testData6.Season);
            Assert.AreEqual(testData7.ExpectCoefficient, coefficientValue7, testData7.Province + "-" + testData7.City + "-" + testData7.Season);
            Assert.AreEqual(testData8.ExpectCoefficient, coefficientValue8, testData8.Province + "-" + testData8.City + "-" + testData8.Season);
            Assert.AreEqual(testData9.ExpectCoefficient, coefficientValue9, testData9.Province + "-" + testData9.City + "-" + testData9.Season);
            Assert.AreEqual(testData10.ExpectCoefficient, coefficientValue10, testData10.Province + "-" + testData10.City + "-" + testData10.Season);
            Assert.AreEqual(testData11.ExpectCoefficient, coefficientValue11, testData11.Province + "-" + testData11.City + "-" + testData11.Season);
        }
    }
}
