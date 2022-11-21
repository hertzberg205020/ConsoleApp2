using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp2
{
    [TestClass]
    public class LinqDemo02
    {
        List<Student> _studentList;

        [TestInitialize]
        public void TestInitialize()
        {
            _studentList = new List<Student>
            {
                new Student { Name = "張三", Gender = '男', Age = 23, Scores = new List<int> { 98, 76, 89, 54 } },
                new Student { Name = "李四", Gender = '男', Age = 33, Scores = new List<int> { 89, 76, 89, 45 } },
                new Student { Name = "王五", Gender = '男', Age = 43, Scores = new List<int> { 98, 76, 89, 55 } },
                new Student { Name = "劉一", Gender = '男', Age = 23, Scores = new List<int> { 67, 76, 89, 33 } },
                new Student { Name = "夏天", Gender = '女', Age = 13, Scores = new List<int> { 89, 76, 89, 56 } },
                new Student { Name = "微微", Gender = '女', Age = 23, Scores = new List<int> { 47, 76, 89, 67 } },
                new Student { Name = "星空", Gender = '女', Age = 24, Scores = new List<int> { 36, 76, 89, 48 } },
                new Student { Name = "三更", Gender = '男', Age = 15, Scores = new List<int> { 89, 76, 89, 69 } },
            };
        }

        /// <summary>
        /// 統計班級男女人數
        /// </summary>
        [TestMethod]
        public void Demo01()
        {
            var res = _studentList.GroupBy(s => s.Gender,
                (gender, students) => new
                {
                    Gender = gender,
                    Num = students.Count()
                });

            foreach (var item in res)
            {
                Console.WriteLine($"{item.Gender}: {item.Num}員");
            }
        }

        /// <summary>
        /// 計算所有男同學的總分和平均分
        /// </summary>
        [TestMethod]
        public void Demo02()
        {
            var res = _studentList.Where(s => s.Gender == '男')
                                                            .Select(s => new
                                                            {
                                                                Name = s.Name,
                                                                AvgScore = s.Scores.Average(),
                                                                Total = s.Scores.Sum()
                                                            });
            foreach (var item in res)
            {
                Console.WriteLine($"{item.Name}: 平均: {item.AvgScore}, 加總: {item.Total}");
            }
        }

        /// <summary>
        /// 查找年紀30歲以上的男生五次考試中的最高分，並對最高分進行降序排序
        /// </summary>
        [TestMethod]
        public void Demo03()
        {
            // res僅保存此次查詢的方法，但查詢的結果並未產生。當通過foreach或for循環對res進行遍歷時，才生成查詢結果，此為延遲加載機制
            // 若希望res處不要延遲加載，查詢時可以使用ToList()或者ToArray()
            var res = _studentList.Where(s => s.Gender == '男' && s.Age >= 30)
                .OrderByDescending(s => s.Scores.Max())
                .Select(s => new {name = s.Name, maxScore = s.Scores.Max()});
            foreach (var item in res)
            {
                Console.WriteLine($"{item.name}: {item.maxScore}");
            }
        }
        
        
        /// <summary>
        /// ToList             : 將集合轉換為List<T>
        /// ToArray            : 將集合轉換為陣列
        /// ToDictionary       : 依據鍵選擇器函數將元素放入Dictionary<TKey, TValue>中
        /// ToLookUp           : 依據鍵選擇器函數將元素放入Lookup<TKey, TElement>中
        /// AsEnumerable       : 將一個序列轉換為IEnumerable<T>集合
        /// AsQueryable        : 將IEnumerable<T>轉換為IQueryable<T>
        /// Cast               : 將集合的元素強制轉換為指定類型
        /// OfType             : 依據值強制轉換為指定類型的能力篩選
        /// </summary>
        [TestMethod]
        public void Demo04() {}
    }
}