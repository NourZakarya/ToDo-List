using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.IRepository;
using ToDoList.Models;
using ToDoList.Repository;
using ToDoList.ViewModel;

namespace ToDoList.Controllers
{
    public class NewTodoItemController : Controller
    {
       // NewToDoItemRepository NewToDoItemRepository=new NewToDoItemRepository();
        INewToDoItemRepository NewToDoItemRepository;
        public NewTodoItemController(INewToDoItemRepository repository)
        {
            this.NewToDoItemRepository = repository;
        }

        public IActionResult Index()
        {
            var result = NewToDoItemRepository.ReadAll();
            return View(result);
        }

        public IActionResult addName()
        {
            return View();
        }

        public IActionResult Create()
        {
            var list1 = new ListItemViewModel();
           return View(list1);
        }

        public IActionResult CreateNew(ListItem listItem)
        {
            if(ModelState.IsValid)
            {
                NewToDoItemRepository.Create(listItem);

                return RedirectToAction("Index");
            }
            return View("Create",listItem);
        }

        public IActionResult Edit(int id)
        {
            ListItem? listItem = NewToDoItemRepository.ReadById(id);
            if(listItem == null)
            {
                return RedirectToAction("index");
            }
            return View(listItem);
        }

        public IActionResult SaveEdit(ListItem listItem)
        {
            if (listItem == null)
            {
                return View("Edit",listItem);
            }
          
            NewToDoItemRepository.Update(listItem);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            NewToDoItemRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
