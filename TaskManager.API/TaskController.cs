using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLib;
using TaskManager.Entities;

namespace TaskManager.API
{
    //[RoutePrefix("api/Task")]
    public class TaskController : ApiController
    {
        //[Route("GetAll")]
        //[HttpGet]
        public IHttpActionResult Get()
        {
            TaskBL obj = new TaskBL();
            return Ok(obj.GetAll());
        }
        //[Route("AddTask")]
        public IHttpActionResult Post(Task item)
        {
            TaskBL obj = new TaskBL();
            obj.AddTask(item);
            return Ok();
        }
        [Route("UpdateTask")]
        [HttpPut]
        public IHttpActionResult Edit(Task item)
        {
            TaskBL obj = new TaskBL();
            obj.UpdateTask(item);
            return Ok("Updated!!!");
        }
        [Route("Delete")]
        public IHttpActionResult Remove(int Id)
        {
            TaskBL obj = new TaskBL();
            obj.DeleteTask(Id); 
            return Ok();
        }

        
        [HttpGet]
        public IHttpActionResult Search(int Id)
        {
            TaskBL obj = new TaskBL();
            return Ok(obj.GetById(Id));
        }

    }
}
