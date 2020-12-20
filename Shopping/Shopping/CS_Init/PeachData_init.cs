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
                ,PhoneNumber="18596584590",Name="甄萱",Sex="女",Birthday=new DateTime(2000,1,20),MailBox="6549823@qq.com",TType="卖家",Sign="123"},

                new User { Password="123456",IdCard="33010119201214603X"
                ,PhoneNumber="18936025655",Name="卫进平",Sex="男",Birthday=new DateTime(2000,1,20),MailBox="55772727@qq.com",TType="卖家",Sign="123"},

                new User { Password="123456",IdCard="430101192012148899"
                ,PhoneNumber="15205239542",Name="荀蓓琛",Sex="男",Birthday=new DateTime(2000,1,20),MailBox="44321856@qq.com",TType="卖家",Sign="123"}
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
                new DeliveryAddress{Province="河南",City="开封",Street="龙亭",Address="无",Name="张飒",PhoneNumber="18622521042",UserId=1},
                new DeliveryAddress{Province="北京",City="北京",Street="天安",Address="无",Name="当当",PhoneNumber="15663123725",UserId=2},
                new DeliveryAddress{Province="湖南",City="长沙",Street="天心",Address="无",Name="蒋罡",PhoneNumber="18116891131",UserId=3},
                new DeliveryAddress{Province="福建",City="厦门",Street="思明",Address="无",Name="莘鹏功",PhoneNumber="17576966030",UserId=4},
                new DeliveryAddress{Province="吉林",City="长春",Street="南关",Address="无",Name="奚士聪",PhoneNumber="13151291019",UserId=5},
                new DeliveryAddress{Province="山东",City="烟台",Street="福山",Address="无",Name="邵海",PhoneNumber="13333346645",UserId=5}
            };

            var com =new List<Commodity>
            { 
                
            };

            var fav = new List<Favorites>
            { 
            };

            var ord = new List<Order>
            {

            };

            var shop = new List<Shop>
            { 

            };

            //每条信息均录入
            us.ForEach(v => context.User.Add(v));
            context.SaveChanges();
            bank.ForEach(v => context.Bankcard.Add(v));
            address.ForEach(v => context.DeliveryAddress.Add(v));
            //com.ForEach(v => context.Commodity.Add(v));
            //fav.ForEach(v => context.Favorites.Add(v));
            //ord.ForEach(v => context.Order.Add(v));
            //shop.ForEach(v => context.Shop.Add(v));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}