namespace KetabBaz.Core.Interfaces;

public interface IAuthorService
{
    Task<AuthorDto> GetAuthorAsync(int authorId);
}
