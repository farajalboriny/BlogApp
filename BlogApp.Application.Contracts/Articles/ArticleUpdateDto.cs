using System.ComponentModel.DataAnnotations;
using BlogApp.Application.Contracts.CustomValidators.ArticleValidators;

namespace BlogApp.Application.Contracts.Articles;

public class ArticleUpdateDto
{
    public Guid Id;
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Content is required")]
    [MinLength(1, ErrorMessage = "Content cannot be empty")]
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Views { get; set; }
    
    [AllowedValues(["Draft","Published","Archived"],ErrorMessage = "Status can be Draft,Published or Archived")]
    public string Status { get; set; }

    [TagsRequiredIfPublished("Status")]
    public List<Guid> TagIds { get; set; }
    public List<Guid> CategoryIds { get; set; }
}