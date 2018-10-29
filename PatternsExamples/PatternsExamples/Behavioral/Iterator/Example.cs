using System;

namespace PatternsExamples.Behavioral.Iterator
{
    class Reader
    {
        public void EnumerateBooks(Library library)
        {
            IBookIterator iterator = library.CreateNumerator();
            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }

    interface IBookIterator
    {
        bool HasNext();

        Book Next();
    }

    interface IBookNumerable
    {
        IBookIterator CreateNumerator();
        int Count { get; }
        Book this[int index] { get; }
    }

    class Book
    {
        public string Name { get; set; }
    }

    class Library : IBookNumerable
    {
        private Book[] _books;

        public Library()
        {
            _books = new Book[]
            {
                new Book { Name="Война и мир" },
                new Book { Name="Отцы и дети" },
                new Book { Name="Вишневый сад" }
            };
        }
        public int Count => _books.Length;

        public Book this[int index] => _books[index];

        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }
    class LibraryNumerator : IBookIterator
    {
        IBookNumerable _aggregate;
        int _index = 0;

        public LibraryNumerator(IBookNumerable a)
        {
            _aggregate = a;
        }

        public bool HasNext()
        {
            return _index < _aggregate.Count;
        }

        public Book Next()
        {
            return _aggregate[_index++];
        }
    }

    class Usage
    {
        public void Run()
        {
            Library library = new Library();
            Reader reader = new Reader();
            reader.EnumerateBooks(library);

            Console.Read();
        }
    }
}
