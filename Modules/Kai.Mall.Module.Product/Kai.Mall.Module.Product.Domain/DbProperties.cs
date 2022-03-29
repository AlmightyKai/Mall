namespace Kai.Mall.Module.Product
{
    public static class DbProperties
    {
        public static string DbTablePrefix { get; set; } = "Product";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Product";
    }
}
