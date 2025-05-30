using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public class BooksRepository
    {
        private readonly BooksDbContext booksDbContext;


        public BooksRepository(BooksDbContext booksDbContext)
        {
            booksDbContext = booksDbContext;
        }
    }
}
