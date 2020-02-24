using System;
using Assignments.BL;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Assignments;

namespace Assignments.Main
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            RegisterTypes();
            SystematesInc inc;
            IMessageService messages;
            using (var Scope = Container.BeginLifetimeScope())
            {
                inc = Container.Resolve<SystematesInc>();
                messages = Container.Resolve<IMessageService>();

            var orderComputer = new Order[] {
                inc.AddOrder(new ComputerOrder("PC")),
                inc.AddOrder(new ComputerOrder("Monitor")),
                inc.AddOrder(new ComputerOrder("Mouse")),
                inc.AddOrder(new ComputerOrder("Keyboard")),
            };

            var orderOffice = new Order[] {
                inc.AddOrder(new OfficeOrder("Pen")),
                inc.AddOrder(new OfficeOrder("Pencil")),
                inc.AddOrder(new OfficeOrder("Paper")),
                inc.AddOrder(new OfficeOrder("Scissors")),
            };
                var computerSuppliers = new Supplier[] {
                inc.AddSupplier(new ComputerSupplier("ComputerRetail", SupplierType.Retail, messages, Container.Resolve<IRepository<Order>>())),
                inc.AddSupplier(new ComputerSupplier("ComputerWholeSale", SupplierType.Wholesale, messages, Container.Resolve<IRepository<Order>>()))};
                var officeSuppliers = new Supplier[]    {
                inc.AddSupplier(new OfficeSupplier("OfficeRetail", SupplierType.Retail, messages, Container.Resolve<IRepository<Order>>())),
                inc.AddSupplier(new OfficeSupplier("OfficeWholeSale", SupplierType.Wholesale, messages, Container.Resolve<IRepository<Order>>()))};


                SystematesInc.Register(computerSuppliers, orderComputer);
                SystematesInc.Register(officeSuppliers, orderOffice);
            }
            inc.IssueOrder("ComputerRetail", "Monitor", 10);
            inc.IssueOrder("ComputerWholeSale", "PC", 2);
            inc.IssueOrder("ComputerRetail", "Mouse", 3);
            inc.IssueOrder("ComputerWholeSale", "Keyboard", 5);

           


            inc.IssueOrder("OfficeRetail", "Pen", 10);
            inc.IssueOrder("OfficeWholeSale", "Pencil", 2);
            inc.IssueOrder("OfficeRetail", "Paper", 3);
            inc.IssueOrder("OfficeWholeSale", "Scissors", 5);

            inc.IssueOrder("ComputerWholeSale", "Pencil", 2);
            inc.IssueOrder("OfficeWholeSale", "Mouse", 5);

            inc.IssueOrder("ErrorSupplier", "Pencil", 2);
            inc.IssueOrder("OfficeWholeSale", "ErrorProduct", 5);


            messages.GetAllMessages().ToList().ForEach(m => {
                Console.WriteLine(m);
                Console.WriteLine();
            });

            Console.ReadKey();
        }


       
        private static void RegisterTypes()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType(typeof(Repository<Order>))
                .As(typeof(IRepository<Order>))
                .InstancePerDependency();
            containerBuilder.RegisterType(typeof(Repository<Supplier>))
                .As(typeof(IRepository<Supplier>))
                .InstancePerDependency();
            containerBuilder.RegisterType<MessageService>()
                .As(typeof(IMessageService))
                .SingleInstance();
            containerBuilder.RegisterType<SystematesInc>()
                .As(typeof(SystematesInc))
                .SingleInstance();

            Container = containerBuilder.Build();
        }

    }
}
