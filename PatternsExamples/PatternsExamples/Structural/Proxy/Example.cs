using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PatternsExamples.Structural.Proxy
{
    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }

    class PageContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
    }

    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }

    class BookStore : IBook
    {
        PageContext _db;

        public BookStore()
        {
            _db = new PageContext();
        }

        public Page GetPage(int number)
        {
            return _db.Pages.FirstOrDefault(p => p.Number == number);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }

    class BookStoreProxy : IBook
    {
        List<Page> _pages;
        BookStore _bookStore;

        public BookStoreProxy()
        {
            _pages = new List<Page>();
        }

        public Page GetPage(int number)
        {
            Page page = _pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (_bookStore == null)
                    _bookStore = new BookStore();
                page = _bookStore.GetPage(number);
                _pages.Add(page);
            }
            return page;
        }

        public void Dispose()
        {
            _bookStore?.Dispose();
        }
    }

    class Usage
    {
        public void Run()
        {
            using (IBook book = new BookStoreProxy())
            {
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);

                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);
 
                page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
            }

            Console.Read();
        }
    }
}
