using System.ComponentModel.DataAnnotations;
using BlogApp.Domain.Articles;

namespace BlogApp.Domain.Categories;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}