using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoefficientLib.Utils;
using Newtonsoft.Json;

namespace CoefficientLib
{
    public class CoefficientDataService
    {
        private List<CoefficientData> datas;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filePath">数据文件地址</param>
        public CoefficientDataService(string filePath)
        {
            datas = JsonConvert.DeserializeObject<List<CoefficientData>>(File.ReadAllText(filePath));
        }

        /// <summary>
        /// 初始化数据到文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void InitDataFile(string filePath)
        {
            if(File.Exists(filePath))
                File.Delete(filePath);
            string dataJson = GenerateData();
            File.WriteAllText(filePath, dataJson);
        }
 
        public decimal GetCoefficient(string province, string city, string season)
        {
            string queryProvince = province.TrimOrEmpty();
            string queryCity = city.TrimOrEmpty();
            string querySeason = season.TrimOrEmpty();

            #region 按照季节查找

            //先查找省市季节都匹配的数据
            CoefficientData coefficientData = QueryCoefficient(queryProvince, queryCity, querySeason);

            if (coefficientData != null)
                return coefficientData.Coefficient;

            //查不到按照全国季节查找
            coefficientData = QueryCoefficient("", "", querySeason);

            if (coefficientData != null)
                return coefficientData.Coefficient;

            //查不到按照本省季节查找
            coefficientData = QueryCoefficient(queryProvince, "", querySeason);

            if (coefficientData != null)
                return coefficientData.Coefficient;

            #endregion

            #region 季节为空按照地区查找

            //查不到按照季节为空，省市查找
            coefficientData = QueryCoefficient(queryProvince, queryCity, "");

            if (coefficientData != null)
                return coefficientData.Coefficient;

            //查不到按照季节为空，省查找
            coefficientData = QueryCoefficient(queryProvince, "", "");

            if (coefficientData != null)
                return coefficientData.Coefficient;

            //查不到按照全国默认
            coefficientData = QueryCoefficient("", "", "");

            if (coefficientData != null)
                return coefficientData.Coefficient;

            #endregion


            //在没有返回默认值，暂为0
            return 0;
        }

        /// <summary>
        /// 查询系数
        /// </summary>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <param name="season"></param>
        /// <returns></returns>
        private CoefficientData QueryCoefficient(string province, string city, string season)
        {
            CoefficientData coefficientData = datas.FirstOrDefault(
                                                p =>(
                                                    p.Province.TrimOrEmpty().Equals(province)
                                                    && p.City.TrimOrEmpty().Equals(city)
                                                    && p.Season.TrimOrEmpty().Equals(season)));

           return coefficientData;
        }

        /// <summary>
        /// 获取初始化配置
        /// </summary>
        /// <returns></returns>
        private static string GenerateData()
        {
            //  全国 = 0.3
            //  全国(春季) = 0.35
            //  全国(冬季) = 0.9
            //  湖南 = 0.6
            //  湖南(夏季) = 0.55
            //  湖南/长沙 = 0.2
            //  湖南/长沙(冬季) = 0.2
            //  湖北(秋季) = 0.48
            //  湖北/武汉 = 0.6
            //  Province City 为空代表全国
            List<CoefficientData> coefficientDatas = new List<CoefficientData>();
            coefficientDatas.Add(new CoefficientData() { Province = "", City = "", Season = "", Coefficient = 0.3M });
            coefficientDatas.Add(new CoefficientData() { Province = "", City = "", Season = "春季", Coefficient = 0.35M });
            coefficientDatas.Add(new CoefficientData() { Province = "", City = "", Season = "冬季", Coefficient = 0.9M });
            coefficientDatas.Add(new CoefficientData() { Province = "湖南", City = "", Season = "", Coefficient = 0.6M });
            coefficientDatas.Add(new CoefficientData() { Province = "湖南", City = "", Season = "夏季", Coefficient = 0.55M });
            coefficientDatas.Add(new CoefficientData() { Province = "湖南", City = "长沙", Season = "", Coefficient = 0.2M });
            coefficientDatas.Add(new CoefficientData() { Province = "湖南", City = "长沙", Season = "冬季", Coefficient = 0.2M });
            coefficientDatas.Add(new CoefficientData() { Province = "湖北", City = "", Season = "秋季", Coefficient = 0.48M });
            coefficientDatas.Add(new CoefficientData() { Province = "湖北", City = "武汉", Season = "", Coefficient = 0.6M });
            return JsonConvert.SerializeObject(coefficientDatas);
        }
    }
}
