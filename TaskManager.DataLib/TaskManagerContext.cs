using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using TaskManager.Entities;

namespace TaskManager.DataLib
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base("name=TaskManagerConn")
        {

        }
        public DbSet<Task> Tasks { get; set; }
    }
}
