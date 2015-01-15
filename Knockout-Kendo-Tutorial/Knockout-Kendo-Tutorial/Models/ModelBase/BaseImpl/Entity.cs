using Knockout_Kendo_Tutorial.Models.ModelBase.IBase;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout_Kendo_Tutorial.Models.ModelBase.BaseImpl
{
    public abstract class Entity
    {
    }

    public abstract class BaseEntity<T> : Entity, IEntity<T>
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public virtual T Id { get; set; }
    }
}