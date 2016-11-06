using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FileManagmentSystem.Models;
using FileManagmentSystem.DataAccess;

namespace FileManagmentSystem.App.Attributes
{
    public class UniqueAttribute : ValidationAttribute
    {
        private string entityTypeName;
        private string memberName;
        private int objectId;

        public UniqueAttribute(string entityTypeName)
        {
            this.entityTypeName = entityTypeName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            this.memberName = validationContext.MemberName;
            this.objectId = (int)validationContext.ObjectType.GetProperty("Id").GetValue(validationContext.ObjectInstance, null);

            return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            Type entityType =
                Assembly.GetAssembly(typeof(BaseEntity)).GetType(entityTypeName);
            var repo = CreateRepo(entityType);

            MethodInfo mi = repo.GetType().GetMethod("GetAll", new Type[] { });
            PropertyInfo pi = entityType.GetProperties().FirstOrDefault(p => p.Name == memberName);

            IEnumerable<object> items = (IEnumerable<object>)mi.Invoke(repo, new object[] { });

            if (value == null)
            {
                value = "";
            }

            foreach (BaseEntity item in items)
            {
                if (this.objectId == item.Id || item.IsDeleted == true)
                {
                    continue;
                }
                if (pi.GetValue(item).ToString() == value.ToString())
                {
                    this.ErrorMessage = "This " + pi.Name + " already exists";
                    return false;
                }
            }

            return true;
        }

        private object CreateRepo(Type entityType)
        {
            if (entityType.Name == typeof(User).Name)
            {
                return new UserRepository();
            }
            else if (entityType.Name == typeof(File).Name)
            {
                return new FileRepository();
            }
           
            return null;

        }
    }
}
