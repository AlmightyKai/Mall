﻿namespace Almighty.Mall.Module.Search;

public static class SearchDbProperties
{
    public static string DbTablePrefix { get; set; } = "Search";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Search";
}
