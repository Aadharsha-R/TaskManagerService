using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using NUnit.Framework;
using TaskManager.API;
using TaskManager.Entities;

namespace TaskManager.Tests.API
{
    [TestFixture]
    public class TestTaskManagerAPI
    {
        static int id = 0;
        [Test]
        public void Test_A_Get()
        {
            TaskController obj = new TaskController();
            IHttpActionResult actionresult = obj.Get();
            var contentResult = actionresult as OkNegotiatedContentResult<List<Task>>;
            Assert.IsNotNull(contentResult);
            id = contentResult.Content[0].TaskId;
            Assert.Greater(contentResult.Content.Count, 0); ;
        }

        [Test]
        public void Test_B_Search()
        {
            TaskController obj = new TaskController();
            var contentResult = obj.Search(id) as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.TaskId, id);
        }

        [Test]
        public void Test_C_Post()
        {
            Task item = new Task() { TaskId = 100, TaskName = "TestTask", ParentTask = "Task11", Priority = 2, SDate = DateTime.Now, EDate = DateTime.Now, TaskEndFlag = true };
            TaskController obj = new TaskController();
            var contentResult = obj.Post(item) as OkResult;
            Assert.IsNotNull(contentResult);
        }

        [Test]
        public void Test_D_Edit()
        {
            Task item = new Task() { TaskId = 4027, TaskName = "TestTaskUpdated", ParentTask = "Task11", Priority = 2, SDate = DateTime.Now, EDate = DateTime.Now, TaskEndFlag = true };
            TaskController obj = new TaskController();
            var contentResult = obj.Edit(item) as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.Content.ToString(),"Updated!!!");
        }

        [Test]
        public void Test_E_Remove()
        {
            TaskController obj = new TaskController();
            var contentResult1 = obj.Remove(4029) as OkResult;
            Assert.IsNotNull(contentResult1);
            var contentResult2 = obj.Search(4029) as OkNegotiatedContentResult<Task>;
            Assert.IsNull(contentResult2.Content);
        }


    }
}
