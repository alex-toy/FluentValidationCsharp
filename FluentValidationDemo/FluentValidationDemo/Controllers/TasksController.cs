using FluentValidationDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {

        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Post")]
        public TaskItem Post(TaskItem taskItem)
        {
            return taskItem;
        }
    }
}