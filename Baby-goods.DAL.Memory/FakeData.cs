using Baby_goods.Common.Models;

namespace Baby_goods.DAL.Memory
{
    internal class FakeData
    {
        public static readonly List<Category> category = new()
        {
            new Category("Передвижение", Guid.Parse("DFB8E7B8-B7AE-47D0-8F18-B321CCF0AE67"), null),
            new Category("Остальное", Guid.Parse("E3D02EBD-D171-46C3-BFD5-1986991B74E1"), null),
            new Category("Коляска", Guid.Parse("5FF7065F-9711-49A0-A669-F54C43A135CF"), Guid.Parse("DFB8E7B8-B7AE-47D0-8F18-B321CCF0AE67")),
            new Category("Велики", Guid.Parse("42A7EF40-2C55-48A0-90C8-0265E9FFDEE7"), Guid.Parse("DFB8E7B8-B7AE-47D0-8F18-B321CCF0AE67")),
        };

        public static readonly List<Product> product = new()
        {
            new Product(
                category[2],
                "Коляска Verdi 3 в 1",
                "Verdi Sonic plus – модульная коляска 3 в 1, пришедшая на смену модели Verdi Sonic. Данная версия отличается усовершенствованным дизайном люльки и колес. Также она получила новую сумку для мамы и матрасик для люльки.", 
                "",
                40_840,
                Guid.Parse("FC6C2F52-17A9-493A-A975-3C321A6B4A2C"),
                "#00000001"),

            new Product(
                category[2],
                "Коляска My Baby 2 в 1",
                "Коляска-трансформер 3 в 1 Luxmom V9 предназначена для детей от рождения до 3 лет. В данной модели люлька легко трансформируется в прогулочное сиденье. Блок имеет реверсивную установку на раму, что позволяет вести ребенка лицом к себе или от себя. В комплект входит детская автолюлька.",
                "",
                13_990,
                Guid.Parse("2F66C7E9-ED85-4B80-A1EC-D54EF514AF40"),
                "#00000002"),

            new Product(
                category[1],
                "Детская кроватка-колыбель",
                "Детская кровать-колыбель Мой малыш отличается мобильными габаритами, классическим дизайном и хорошей функциональностью. Она имеет 2 устойчивые ножки, 4 колесика и маятниковый механизм поперечного качания. Когда раскачивание не требуется (ребенок бодрствует) – кроватку можно установить на специальный фиксатор.",
                "", 7_800,
                Guid.Parse("BD6BF8C6-56FB-433B-A64C-C1664B197FE0"),
                "#00000003"),

            new Product(
                category[1],
                "Шарики для сухого бассейна",
                "Шарики для сухого бассейна, детских игровых центров, палаток и надувных батутов. Набор из цветных пластмассовых шариков Intex 49602. Упаковывается в прозрачную сумку с ручками.",
                "",
                990,
                Guid.Parse("D308D275-0A85-40F7-9DDD-48F239DCB16B"),
                "#00000004"),

            new Product(
                category[2],
                "Беговел EcoBalance Baby",
                "Детский беговел для малышей от 1 до 3 лет. Он имеет 4 пластиковых прорезиненных колеса, а также устойчивую и безопасную конструкцию. Мягкое сидение высотой 23 см от пола, выполнено из искусственной кожи. Руль оснащен имеет ограничитель угла поворота.",
                "",
                2_190,
                Guid.Parse("77FDCB2C-9F51-458B-B23B-5858129EE0B8"),
                "#00000005"),
        };

        public static readonly List<User> user = new()
        {
            new User("Антонyc", "anton@gmail.com", "password", "Антон", "Назаров", "79998887766", Role.Customer, Guid.Parse("15A4937C-076D-4A30-9B3A-B745B87F68E0"))
        };

        public static readonly List<ShoppingCartItem> shoppingCartItem = new()
        {
            new ShoppingCartItem(user[0].Id, product[0], Guid.Parse("5E9F171E-0374-40D1-90CA-A240D974973E"), 2),
            new ShoppingCartItem(user[0].Id, product[1], Guid.Parse("FC2DC133-D902-4257-866B-6D6B47C2084D"))
        };
    }
}
