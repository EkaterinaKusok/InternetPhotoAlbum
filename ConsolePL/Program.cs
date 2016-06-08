using System;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BLL.Interfacies.Services;
using DependencyResolver;
using Ninject;
using ORM;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        static void Main(string[] args)
        {
            var service = resolver.Get<IUserService>();
            var list = service.GetAllUserEntities().ToList();
            foreach (var user in list)
            {
                Console.Write(user.UserName + " " + user.UserPassword 
                    +" "+ service.GetUserRole(user.Id).Name+":");
                foreach (var photo in service.GetUserPhotos(user.Id))
                {
                    Console.Write(" "+photo.PhotoName);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}