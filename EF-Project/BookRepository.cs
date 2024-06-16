using Microsoft.EntityFrameworkCore;

public class BookRepository
{
    private AppContext context;

    public BookRepository()
    {
        context = new AppContext();
    }

    public Book GetBookById(int bookId)
    {
        return context.Books.FirstOrDefault(b => b.Id == bookId);
    }

    public IQueryable<Book> GetAllBooks()
    {
        return context.Books;
    }

    public void AddBook(Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();
    }

    public void DeleteBook(int bookId)
    {
        var book = context.Books.FirstOrDefault(b => b.Id == bookId);
        if (book != null)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }
    }

    public void UpdateBookYear(int bookId, int newYear)
    {
        var book = context.Books.FirstOrDefault(b => b.Id == bookId);
        if (book != null)
        {
            book.ReleaseYear = newYear;
            context.SaveChanges();
        }
    }

    public IEnumerable<Book> BooksByGenreAndYearRange(int genreId, int startYear, int endYear)
    {
        return context.Books.Where(b => b.Genre == genreId && b.ReleaseYear >= startYear && b.ReleaseYear <= endYear).ToList();
    }

    public int BookByAuthor(int authorId)
    {
        return context.Books.Count(b => b.Author == authorId);
    }

    public int BookByGenre(int genreId)
    {
        return context.Books.Count(b => b.Genre == genreId);
    }

    public bool IsBookByAuthorAndTitleExists(int authorId, string title)
    {
        return context.Books.Any(b => b.Author == authorId && b.Title == title);
    }
    public bool IsBookExistsByUser(int bookId, int userId)
    {
        return context.Books.Any(b => b.Id == bookId && b.UserId == userId);
    }

    public int BookCountByUser(int userId)
    {
        return context.Books.Count(b => b.UserId == userId);
    }

    public Book GetLatestBook()
    {
        return context.Books.OrderByDescending(b => b.ReleaseYear).FirstOrDefault();
    }

    public IEnumerable<Book> AllBooksSortedByName()
    {
        return context.Books.OrderBy(b => b.Title).ToList();
    }

    public IEnumerable<Book> AllBooksSortedByYearDescending()
    {
        return context.Books.OrderByDescending(b => b.ReleaseYear).ToList();
    }
}