using ToDoList.Models;

namespace ToDoList.IRepository
{
    public interface INewToDoItemRepository
    {
         void Delete(int id);
         void Update(ListItem item);
         List<ListItem> ReadAll();
         ListItem ReadById(int id);
         void Create(ListItem item);
        
    }
}
