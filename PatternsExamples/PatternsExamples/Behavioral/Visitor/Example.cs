using System;
using System.Collections.Generic;

namespace PatternsExamples.Behavioral.Visitor
{
    interface IVisitor
    {
        void VisitPersonAcc(Person acc);

        void VisitCompanyAc(Company acc);
    }

    class HtmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            Console.WriteLine(result);
        }

        public void VisitCompanyAc(Company acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>RegNumber<td><td>" + acc.RegNumber + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            Console.WriteLine(result);
        }
    }

    class XmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = "<Person><Name>" + acc.Name + "</Name>" + "<Number>" + acc.Number + "</Number><Person>";
            Console.WriteLine(result);
        }

        public void VisitCompanyAc(Company acc)
        {
            string result = "<Company><Name>" + acc.Name + "</Name>" +
                "<RegNumber>" + acc.RegNumber + "</RegNumber>" +
                "<Number>" + acc.Number + "</Number><Company>";
            Console.WriteLine(result);
        }
    }

    class Bank
    {
        List<IAccount> _accounts = new List<IAccount>();

        public void Add(IAccount acc)
        {
            _accounts.Add(acc);
        }

        public void Remove(IAccount acc)
        {
            _accounts.Remove(acc);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (IAccount acc in _accounts)
                acc.Accept(visitor);
        }
    }

    interface IAccount
    {
        void Accept(IVisitor visitor);
    }

    class Person : IAccount
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitPersonAcc(this);
        }
    }

    class Company : IAccount
    {
        public string Name { get; set; }

        public string RegNumber { get; set; }

        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompanyAc(this);
        }
    }

    class Usage
    {
        public void Run()
        {
            Bank structure = new Bank();
            structure.Add(new Person { Name = "Иван Алексеев", Number = "82184931" });
            structure.Add(new Company { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445" });
            structure.Accept(new HtmlVisitor());
            structure.Accept(new XmlVisitor());

            Console.Read();
        }
    }
}
