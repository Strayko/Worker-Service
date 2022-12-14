using ConsoleApp34.Model;

namespace ConsoleApp34.Data;

public class ItemService : IItemService
{
    public List<Item> GetItems()
    {
        return new List<Item>()
        {
            new Item()
            {
                Id = 1,
                Name = "Task One",
                IsCompleted = true
            },
            new Item()
            {
                Id = 2,
                Name = "Task Two",
                IsCompleted = true
            }
        };
    }
}