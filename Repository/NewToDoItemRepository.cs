using ToDoList.Data;
using ToDoList.IRepository;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class NewToDoItemRepository: INewToDoItemRepository
    {
        ApplicationDbContext context=new ApplicationDbContext();
       
        public void Delete(int id)
        {
            var item = context.ListItems.Find(id);
            if(item != null)
            {
                context.ListItems.Remove(item);
                context.SaveChanges();
            }
            
        }
        public void Update(ListItem item)
        {
            var newItem =context.ListItems.Find(item.Id);
            if(newItem != null)
            {
                newItem.Id = item.Id;
                newItem.Title = item.Title;
                newItem.Description = item.Description;
                newItem.DeadLine = item.DeadLine;
                context.SaveChanges();
            }
            
        }
        public List<ListItem> ReadAll()
        {
            return context.ListItems.ToList();
        }

        public ListItem ReadById(int id)
        {
            return context.ListItems.Find(id);
        }

        public void Create(ListItem item)
        {
            context.ListItems.Add(item);
           context.SaveChanges();
              

        }
        
    }
}
