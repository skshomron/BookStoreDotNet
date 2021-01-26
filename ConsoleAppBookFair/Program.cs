using System;
using System.ServiceModel;
using BookFairIoc;
namespace ConsoleAppBookFair
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new BookFairKernel();
            
            //var users = kernel.GetService();
            //var ret = users.Connect("shomron", "phenix_6");

            using (var host = new ServiceHost(kernel.GetService()))
            {
                host.Open();
                Console.WriteLine("Service started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
            //using (var context = new BookFairContext())
            //{


            //    var user = new User
            //    {
            //        Avatar = @"testavatar",
            //        Birthday = new DateTime(2018, 06, 25),
            //        Email = @"sks.phenix@hotmail.com",
            //        FirstName = "Shomron",
            //        LastName = "Sougang Kamgang",
            //        HasReadTermsConditions = true,
            //        IsMale = true,
            //        Login = "shomron",
            //        Password = "phenix_6",
            //        Phone = "1545685421"
            //    };
            //    context.Users.Add(user);
            //    context.SaveChanges();
            //}
        }


    }
}
