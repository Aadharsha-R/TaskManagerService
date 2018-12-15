using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TaskManager.BusinessLib;
using TaskManager.Entities;

namespace TaskManager.Tests.BusinessLib
{
    [TestFixture]
    public class TestTaskManagerBL 
    {
        static int id = 0;
        static int TaskCount = 0;
        static int AddDelTestId = 0;
        static string Name = string.Empty;


       
        [Test]
        public void Test_A_GetAll()
        {
            TaskBL obj = new TaskBL();
            var TestTasks = obj.GetAll();
            TaskCount = TestTasks.Count;
            if (TaskCount > 0)
            {
                id = TestTasks[0].TaskId;
                Name = TestTasks[0].TaskName;
            }
            Assert.NotZero(TaskCount);
        }

        [Test]
        public void Test_B_GetByName()
        {
            TaskBL obj = new TaskBL();
            var TestTask = obj.GetByName(Name);
            Assert.AreEqual(TestTask.TaskName, Name);
        }

        [Test]
        public void Test_C_GetById()
        {
            //int id = 3;
            TaskBL obj = new TaskBL();
            var TestTask = obj.GetById(id);
            Assert.AreEqual(TestTask.TaskId, id);
        }

        [Test]
        public void Test_D_AddTask()
        {
            Task item = new Task() { TaskId = 100,TaskName = "TestTask", ParentTask = "Task11", Priority = 2, SDate = DateTime.Now, EDate = DateTime.Now, TaskEndFlag = true };
            TaskBL obj = new TaskBL();
            obj.AddTask(item);
            var res = obj.GetByName("TestTask");
            if (res != null)
                AddDelTestId = res.TaskId;
            Assert.IsNotNull(res);
        }

        [Test]
        public void Test_E_UpdateTask()
        {
            Task item = new Task() { TaskId = AddDelTestId, TaskName = "TestTaskUpdated", ParentTask = "Task11", Priority = 2, SDate = DateTime.Now, EDate = DateTime.Now, TaskEndFlag = true };
            TaskBL obj = new TaskBL();
            obj.UpdateTask(item);
            var res = obj.GetByName("TestTaskUpdated");
            Assert.IsNotNull(res);
        }

        [Test]
        public void Test_F_DeleteTask()
        {
            TaskBL obj = new TaskBL();
            obj.DeleteTask(AddDelTestId);
            Assert.IsNull(obj.GetById(AddDelTestId));
        }
    }
}
