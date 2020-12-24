using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Shopping.Models;

namespace Shopping.CS_Init
{
    //初始化策略 继承于  ：始终删除
    public class PeachData_init:DropCreateDatabaseAlways<PeachMd>
    {
        /*
           作者：                zmx
           创建时间：            2020/12/14
           函数功能：            重写Seed方法，用于初始化数据库
           入口参数：            数据库上下文类
         */
        //重写Seed初始化方法
        protected override void Seed(PeachMd context)
        {
            var us = new List<User>
            {
                new User { Password="123456",IdCard="410101192012146574"
                ,PhoneNumber="19887423527",Name="超宇",Sex="男",Birthday=new DateTime(2000,1,20),MailBox="198874235@qq.com",TType="买家",Sign="123"},

                new User { Password="123456",IdCard="410101192012147833"
                ,PhoneNumber="13922575079",Name="龙荷珍",Sex="女",Birthday=new DateTime(1990,1,20),MailBox="139225750@qq.com",TType="买家",Sign="123"},

                new User { Password="123456",IdCard="150101192012149114"
                ,PhoneNumber="17196874537",Name="吉旭伯",Sex="男",Birthday=new DateTime(1989,1,20),MailBox="171968745@qq.com",TType="买家",Sign="123"},

                new User { Password="123456",IdCard="410101192012146574"
                ,PhoneNumber="18795687097",Name="闻腾河",Sex="男",Birthday=new DateTime(1965,1,20),MailBox="187956870@qq.com",TType="买家",Sign="123"},

                new User { Password="123456",IdCard="150101192012149915"
                ,PhoneNumber="15287209943",Name="叶贞",Sex="女",Birthday=new DateTime(1963,1,20),MailBox="265698733@qq.com",TType="买家",Sign="123"},

                new User { Password="123456",IdCard="21010119201214933X"
                ,PhoneNumber="13306538832",Name="公羊江强",Sex="男",Birthday=new DateTime(2000,1,20),MailBox="84659712@qq.com",TType="买家",Sign="123"},

                new User { Password="123456",IdCard="330101192012149257"
                ,PhoneNumber="18596584590",Name="甄萱",Sex="女",Birthday=new DateTime(2000,1,20),MailBox="6549823@qq.com",TType="商家",Sign="123"},

                new User { Password="123456",IdCard="33010119201214603X"
                ,PhoneNumber="18936025655",Name="卫进平",Sex="男",Birthday=new DateTime(2000,1,20),MailBox="55772727@qq.com",TType="商家",Sign="123"},

                new User { Password="123456",IdCard="430101192012148899"
                ,PhoneNumber="15205239542",Name="荀蓓琛",Sex="男",Birthday=new DateTime(2000,1,20),MailBox="44321856@qq.com",TType="商家",Sign="123"}
            };

            var bank = new List<Bankcard>
            {
                new Bankcard{UserID=1,BankAcount="4934279590163120",BankPassword="123456",Money=8562.56},
                new Bankcard{UserID=2,BankAcount="5254989257352217",BankPassword="123456",Money=985},
                new Bankcard{UserID=3,BankAcount="5309803479125878",BankPassword="123456",Money=85},
                new Bankcard{UserID=4,BankAcount="4934276729529635",BankPassword="123456",Money=96352},
                new Bankcard{UserID=5,BankAcount="4063652864176023",BankPassword="123456",Money=123465},
                new Bankcard{UserID=6,BankAcount="5588946001567059",BankPassword="123456",Money=0.52},
                new Bankcard{UserID=7,BankAcount="6223479862745662",BankPassword="123456",Money=62.56},
                new Bankcard{UserID=8,BankAcount="6227507393093768",BankPassword="123456",Money=8992.56},
                new Bankcard{UserID=9,BankAcount="4270646286583633",BankPassword="123456",Money=99962.56},
                new Bankcard{UserID=5,BankAcount="4580602598410325",BankPassword="123456",Money=6462.56},
                new Bankcard{UserID=3,BankAcount="6223499391590819",BankPassword="123456",Money=65562.56},
            };

            var address = new List<DeliveryAddress>
            {
                new DeliveryAddress{Province="河南省",City="开封市",Street="龙亭区",Address="河南大学金明校区",Name="张飒",PhoneNumber="18622521042",UserId=1},
                new DeliveryAddress{Province="北京省",City="北京市",Street="天安区",Address="北京大学雁鸣湖",Name="当当",PhoneNumber="15663123725",UserId=1},
                new DeliveryAddress{Province="湖南省",City="长沙市",Street="天心区",Address="天心广场五楼",Name="蒋罡",PhoneNumber="18116891131",UserId=1},
                new DeliveryAddress{Province="北京省",City="北京市",Street="天安区",Address="北京大学雁鸣湖",Name="当当",PhoneNumber="15663123725",UserId=2},
                new DeliveryAddress{Province="湖南省",City="长沙市",Street="天心区",Address="天心广场五楼",Name="蒋罡",PhoneNumber="18116891131",UserId=3},
                new DeliveryAddress{Province="福建省",City="厦门市",Street="思明区",Address="商品大厦一楼",Name="莘鹏功",PhoneNumber="17576966030",UserId=4},
                new DeliveryAddress{Province="吉林省",City="长春市",Street="南关区",Address="暖向社区居委会",Name="奚士聪",PhoneNumber="13151291019",UserId=5},
                new DeliveryAddress{Province="山东省",City="烟台市",Street="福山区",Address="你好小区17单元",Name="邵海",PhoneNumber="13333346645",UserId=5}
            };

            var com =new List<Commodity>
            { 
                new Commodity{Name="连衣裙",Type="女装",Price=53,Number=100,Introduction="这是一个物品。",Image="null"},
                new Commodity{Name="毛衣",Type="女装",Price=89,Number=100,Introduction="这是一个物品。",Image="null"},
                new Commodity{Name="西服一套",Type="男装",Price=213,Number=100,Introduction="这是一个物品。",Image="null"},
                new Commodity{Name="T恤",Type="男装",Price=26,Number=100,Introduction="这是一个物品。",Image="null"}
            };

            var fav = new List<Favorites>
            { 
                new Favorites{UserId=1,Link="null",number=1},
                new Favorites{UserId=1,Link="null",number=1},
                new Favorites{UserId=1,Link="null",number=1},
                new Favorites{UserId=2,Link="null",number=1},
                new Favorites{UserId=2,Link="null",number=1},
                new Favorites{UserId=2,Link="null",number=1}
            };
            int tmp = 1;
            Random rm = new Random();
            foreach (var item in fav)
            {
                item.imagepath = "/Images/Shoppingcart/cart0" + tmp.ToString()+".jpg";
                item.price = rm.Next(100, 1000) / 10.0;
                int ww = rm.Next(0, 4);
                item.type = com[ww].Type;
                item.name = com[ww].Name;
                tmp++;
            }

            var ord = new List<Order>
            {
                //外键这里设置为空了
                new Order{Id=1,State="进行中",Logistics="运输中",StartTime=new DateTime(2020,12,20),CustomerID=1,SellerID=7,CommodityID=1},
                new Order{Id=2,State="已完成",Logistics="已签收",StartTime=new DateTime(2020,12,20),CustomerID=1,SellerID=7,CommodityID=2},
                new Order{Id=3,State="退货中",Logistics="运输中",StartTime=new DateTime(2020,12,20),CustomerID=1,SellerID=7,CommodityID=3},
                new Order{Id=4,State="进行中",Logistics="运输中",StartTime=new DateTime(2020,12,20),CustomerID=1,SellerID=7,CommodityID=4},
                new Order{Id=5,State="进行中",Logistics="运输中",StartTime=new DateTime(2020,12,20),CustomerID=1,SellerID=7,CommodityID=3},
                new Order{Id=6,State="进行中",Logistics="运输中",StartTime=new DateTime(2020,12,20),CustomerID=1,SellerID=7,CommodityID=4},
            };
            tmp = 1;
            foreach (var item in ord)
            {
                item.imagepath = "/Images/Shoppingcart/cart0" + tmp.ToString() + ".jpg";
                item.price = rm.Next(100, 1000) / 10.0;
                int ww = rm.Next(1, 5);
                item.username = us[item.CustomerID==null?0:(int)item.CustomerID-1].Name;
                item.number = ww;
                item.comname = com[item.CommodityID == null ? 0 : (int)item.CommodityID - 1].Name;
                tmp++;
            }

            //7、8、9是卖家
            var shop = new List<Shop>
            { 
                new Shop{Image="null",Name="Shop71",SellerId=7,Score=9,Address="河南省开封市XXXX",CreatTime=new DateTime(2009,1,25)
                ,LicenseId="123456789",FansNumber=12345},

                new Shop{Image="null",Name="Shop81",SellerId=8,Score=9,Address="河南省开封市XXXX",CreatTime=new DateTime(2009,1,25)
                ,LicenseId="123456789",FansNumber=12345},

                new Shop{Image="null",Name="Shop91",SellerId=9,Score=9,Address="河南省开封市XXXX",CreatTime=new DateTime(2009,1,25)
                ,LicenseId="123456789",FansNumber=12345},

                new Shop{Image="null",Name="Shop72",SellerId=7,Score=9,Address="河南省开封市XXXX",CreatTime=new DateTime(2009,1,25)
                ,LicenseId="123456789",FansNumber=12345},

                new Shop{Image="null",Name="Shop73",SellerId=7,Score=9,Address="河南省开封市XXXX",CreatTime=new DateTime(2009,1,25)
                ,LicenseId="123456789",FansNumber=12345},

            };

            //每条信息均录入
            us.ForEach(v => context.User.Add(v));
            context.SaveChanges();
            bank.ForEach(v => context.Bankcard.Add(v));
            address.ForEach(v => context.DeliveryAddress.Add(v));
            com.ForEach(v => context.Commodity.Add(v));
            context.SaveChanges();
            fav.ForEach(v => context.Favorites.Add(v));
            ord.ForEach(v => context.Order.Add(v));
            shop.ForEach(v => context.Shop.Add(v));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}