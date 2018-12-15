using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using TaskManager.Entities;
using TaskManager.DataLib;

namespace TaskManager.BusinessLib
{
    public class TaskBL
    {

        public void AddTask(Task item)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                db.Tasks.Add(item);
                db.SaveChanges();
            }
        }

        public void UpdateTask(Task item)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                var Tsk = db.Tasks.First(i => i.TaskId == item.TaskId);
                //var Tsk = GetById(item.TaskId);
                if (Tsk != null)
                {
                    Tsk.TaskName = item.TaskName;
                    Tsk.ParentTask = item.ParentTask;
                    Tsk.Priority = item.Priority;
                    Tsk.SDate = item.SDate;
                    Tsk.EDate = item.EDate;
                    Tsk.TaskEndFlag = item.TaskEndFlag;
                    db.Entry(Tsk).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //db.Entry(Tsk).CurrentValues.SetValues(item);
                //db.Tasks.AddOrUpdate(item);
                
            }
        }

        public void DeleteTask(int Id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                var Tsk = db.Tasks.First(i => i.TaskId == Id);
                //var Tsk = GetById(item.TaskId);
                if (Tsk != null)
                {
                    db.Entry(Tsk).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public List<Task> GetAll()
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return db.Tasks.ToList();
            }
        }

        public Task GetById(int Id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return db.Tasks.SingleOrDefault(k => k.TaskId == Id);
            }

        }

        public Task GetByName(string Name)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return db.Tasks.SingleOrDefault(k => k.TaskName == Name);
            }

        }
    }
}
