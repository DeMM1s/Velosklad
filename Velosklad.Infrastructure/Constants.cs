namespace Velosklad.Infrastructure
{
    public static class Constants
    {
        public const string ConnectionName = "OrderDbConnection";

        public static class ErrorMessage
        {
            public static class Product
            {
                public const string ProductNotFoundError = "Продукт с указанным id не найден";
            }
        }
    }
}