using Baby_goods.Common.Interfaces;

namespace Baby_goods.DAL.Memory
{
    public class HomeRepository : IHomeRepository
    {
        private static readonly Category[] _categories = new[]
        {
            new Category("testCategory", Guid.NewGuid())
        };

        private static readonly Product[] _products = new[]
        {
            new Product(_categories[0], "1testTitle", "testSummary", "", 500, Guid.Parse("FC6C2F52-17A9-493A-A975-3C321A6B4A2C")),
            new Product(_categories[0], "2testTitle", "testSummary", "", 300, Guid.Parse("2F66C7E9-ED85-4B80-A1EC-D54EF514AF40")),
            new Product(_categories[0], "3testTitle", "testSummary", "", 200, Guid.Parse("BD6BF8C6-56FB-433B-A64C-C1664B197FE0")),
            new Product(_categories[0], "4testTitle", "testSummary", "", 570, Guid.Parse("D308D275-0A85-40F7-9DDD-48F239DCB16B")),
            new Product(_categories[0], "5testTitle", "testSummary", "", 100, Guid.Parse("77FDCB2C-9F51-458B-B23B-5858129EE0B8")),
        };

        public async Task<List<Product>> Get()
        {
            var result = _products.ToList();

            return result;
        }
    }
}