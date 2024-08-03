﻿namespace BlogApp.Application.Contracts.Articles;

public class GetArticleInput
{
    public int Page { get; set; }
    public  int PageSize { get; set; }
    public string SortBy { get; set; }
    public bool Ascending { get; set; }
}