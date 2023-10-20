namespace CartServiceTest
{
    [TestClass]
    public class CategoryServiceTests : TestBase
    {
        [TestMethod]
        public async Task GetCategories()
        {
            var category = await catalogController.GetCategories();

            Assert.IsNotNull(category);
        }

        [TestMethod]
        public async Task GetItems()
        {
            int categoryId = 1;

            var items = await catalogController.GetItems(categoryId);

            Assert.IsNotNull(items);
        }

    }
}