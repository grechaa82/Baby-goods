﻿using Baby_goods.Common.Interfaces;

namespace Baby_goods.DAL.Memory
{
    public class HomeRepository : IHomeRepository
    {
        public static readonly Category[] _categories = new[]
        {
            new Category("testCategory", Guid.NewGuid())
        };

        public static readonly Product[] _products = new[]
        {
            new Product(
                _categories[0], 
                "Коляска Verdi 3 в 1", 
                "Verdi Sonic plus – модульная коляска 3 в 1, пришедшая на смену модели Verdi Sonic. Данная версия отличается усовершенствованным дизайном люльки и колес. Также она получила новую сумку для мамы и матрасик для люльки."
                , "", 
                40_840, 
                Guid.Parse("FC6C2F52-17A9-493A-A975-3C321A6B4A2C"),
                "#00000001"),

            new Product(
                _categories[0], 
                "Коляска My Baby 2 в 1", 
                "Коляска-трансформер 3 в 1 Luxmom V9 предназначена для детей от рождения до 3 лет. В данной модели люлька легко трансформируется в прогулочное сиденье. Блок имеет реверсивную установку на раму, что позволяет вести ребенка лицом к себе или от себя. В комплект входит детская автолюлька.", 
                "", 
                13_990, 
                Guid.Parse("2F66C7E9-ED85-4B80-A1EC-D54EF514AF40"),
                "#00000002"),

            new Product(
                _categories[0],
                "Детская кроватка-колыбель",
                "Детская кровать-колыбель Мой малыш отличается мобильными габаритами, классическим дизайном и хорошей функциональностью. Она имеет 2 устойчивые ножки, 4 колесика и маятниковый механизм поперечного качания. Когда раскачивание не требуется (ребенок бодрствует) – кроватку можно установить на специальный фиксатор.", 
                "", 7_800, 
                Guid.Parse("BD6BF8C6-56FB-433B-A64C-C1664B197FE0"),
                "#00000003"),

            new Product(
                _categories[0],
                "Шарики для сухого бассейна",
                "Шарики для сухого бассейна, детских игровых центров, палаток и надувных батутов. Набор из цветных пластмассовых шариков Intex 49602. Упаковывается в прозрачную сумку с ручками.", 
                "",
                990, 
                Guid.Parse("D308D275-0A85-40F7-9DDD-48F239DCB16B"),
                "#00000004"),

            new Product(
                _categories[0],
                "Беговел EcoBalance Baby",
                "Детский беговел для малышей от 1 до 3 лет. Он имеет 4 пластиковых прорезиненных колеса, а также устойчивую и безопасную конструкцию. Мягкое сидение высотой 23 см от пола, выполнено из искусственной кожи. Руль оснащен имеет ограничитель угла поворота.", 
                "",
                2_190, 
                Guid.Parse("77FDCB2C-9F51-458B-B23B-5858129EE0B8"),
                "#00000005"),
        };

        public async Task<List<Product>> Get(int pageIndex, int pageSize)
        {
            var result = _products
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return result;
        }
    }
}