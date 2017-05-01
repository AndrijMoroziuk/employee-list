using EmployeeList.Domain.Entities.Infrastructure;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.Domain.Entities.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int Rate { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployerId { get; set; }
    }
}
