using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    /// <summary>
    /// LINQ有2種語法可供選擇:
    /// 1. 方法語法(Fluent Syntax)
    /// 2. 查詢語法(Query Expression)
    /// </summary>
    [TestClass]
    public class LinqDemo
    {
        IEnumerable<Product> products;
        [TestInitialize]
        public void TestInitialize()
        {
            products = new List<Product>()
            {
                new Product
                {
                    Name = "adidas",
                    Category = "鞋子",
                    Number = 500
                },
                new Product
                {
                    Name = "Nike",
                    Category = "鞋子",
                    Number = 1000
                },
                new Product
                {
                    Name = "手打麵",
                    Category = "食品",
                    Number = 1500
                },
                new Product {
                    Name = "康師父",
                    Category = "食品",
                    Number = 2000
                },
                new Product
                {
                    Name = "鮪魚罐頭",
                    Category = "食品",
                    Number = 600
                },
                new Product { 
                    Name = "可樂",
                    Category = "飲料",
                    Number = 5000
                },
                new Product
                {
                    Name = "雪碧",
                    Category = "飲料",
                    Number = 3600
                },
                new Product{ 
                    Name = "Mountain Dew",
                    Category = "飲料",
                    Number = 4250
                }
            };
                
        }

        /// <summary>
        /// 查詢類別式飲料的產品
        /// </summary>
        [TestMethod]
        public void Demo01()
        {
            // linq表達式僅定義一個查詢，但並未執行
            // 執行時間: 當通過foreach或者for循環執行linq時，才真正執行linq表達式
            
            // p表示list1裡面的每個元素，p代表的就是每一個product物件
            // from, where, select三個子句構成linq表達式
            
            // var res = from p in products
            //     where p.Category == "飲料"
            //     select new {p.Name, p.Number};

            var res = products.Where(p => p.Category == "飲料")
                                                .Select(p => p);
            

            foreach (var item in res)
            {
                Console.WriteLine($"飲品名稱: {item.Name}, 數量: {item.Number}");
            }
        }

        /// <summary>
        /// 查詢飲料產品並且數量在4000以上的產品資訊
        /// 分組group 以主體進行分主 by 分組的關鍵字
        /// </summary>
        [TestMethod]
        public void Demo02()
        {
            // var res = from p in products
            //     group p by p.Category;

            var res = products.Where(p => p.Number > 4000)
                                                     .GroupBy(p => p.Category);

            foreach (var item in res)
            {
                Console.WriteLine($"產品分類: {item.Key}, 此類產品有{item.Count()}個");

                foreach (var e in item)
                {
                    Console.WriteLine($"產品名稱: {e.Name}, 產品數量: {e.Number}");
                }
                Console.WriteLine("=============分界線=============");
            }
        }

        /// <summary>
        /// 查詢各個分類的名稱與品項的數量
        /// 每個分類結果僅包含分類名稱與數量
        /// </summary>
        [TestMethod]
        public void Demo03()
        {
            // var res = from p in products
            //     group p by p.Category
            //     into g
            //     select new { Title = g.Key, Num = g.Count() };
            // var res = products.GroupBy(p => p.Category, (category, p) => new
            // {
            //     Title = category,
            //     Num = p.Count()
            // });

            var res = 
                products.GroupBy(p => p.Category)
                        .Select(g => new
                        {
                            Title = g.Key,
                            Num = g.Count()
                        });

            foreach (var item in res)
            {
                Console.WriteLine($"品項: {item.Title}, 數量: {item.Num}");
            }
        }

        /// <summary>
        /// orderby 排序關鍵字 (空白或者ascending表示升序/descending表示降序)
        /// </summary>
        [TestMethod]
        public void Demo04()
        {
            // var res = from p in products
            //     orderby p.Number descending 
            //     select p;

            var res = products.OrderByDescending(p => p.Category);
            
            foreach (var product in res)
            {
                Console.WriteLine($"產品名稱: {product.Name}, 產品數量: {product.Number}");
            }
        }

        /// <summary>
        /// 拓展方法練習
        /// </summary>
        [TestMethod]
        public void Demo05()
        {
            Product product = new Product
            {
                Name = "鵲巢檸檬紅茶",
                Category = "飲品",
                Number = 5000
            };
            product.Display(product);
        }

    }
}
