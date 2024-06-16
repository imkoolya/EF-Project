public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int Genre { get; set; }
    public int Author {  get; set; }

}