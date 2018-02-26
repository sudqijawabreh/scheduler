using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ViewModelFactory
    {
        public static TaskModel createTaskModel(Entity task)
        {
            return new TaskModel
            {
                Id = task.Id,
                Topic = task.GetAttributeValue<string>("subject"),
                Description = task.GetAttributeValue<string>("description"),
                StartTime = task.GetAttributeValue<DateTime>("actualstart"),
                EndTime = task.GetAttributeValue<DateTime>("actualend"),
                ProjectId = task.GetAttributeValue<EntityReference>("schedule_projectid").Id,
                UserId = task.GetAttributeValue<EntityReference>("schedule_userid").Id



            };

        }

        public static UserModel createUserModel(Entity user)
        {
            return new UserModel
            {
                text = user.GetAttributeValue<string>("fullname"),
                value = user.Id,
            };
        }
        public static ProjectModel createProjectModel(Entity project)
        {
            return new ProjectModel
            {
                text = project.GetAttributeValue<string>("schedule_name"),
                value = project.Id
            };
        }

        public static Entity ParseTask(TaskModel value)
        {
            Entity task = new Entity("task");
            task.Id = value.Id;
            task["subject"] = value.Topic;
            task["actualstart"] = value.StartTime;
            task["actualend"] = value.EndTime;
            task["schedule_userid"] = new EntityReference() { LogicalName = "systemuser", Id = value.UserId };
            task["schedule_projectid"] = new EntityReference() { LogicalName = "schedule_project", Id = value.ProjectId };
            task["description"] = value.Description;
            return task;
        }
        
    }
}