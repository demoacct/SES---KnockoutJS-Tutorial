using Knockout_Kendo_Tutorial.Models.Database;
using Knockout_Kendo_Tutorial.Models.Entities;
using Knockout_Kendo_Tutorial.Models.Repositories.IRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout_Kendo_Tutorial.Models.Repositories.RepositoryImpl
{
    public class StudentRepository : IStudentRepository
    {
        private MongowDatabase database;
        private MongoCollection<Estudyante> estudyanteCollection;

        public StudentRepository()
        {
            this.database = new MongowDatabase();
            this.estudyanteCollection = this.database.Database.GetCollection<Estudyante>("estudyantes");
        }

        public async System.Threading.Tasks.Task<bool> Create(Entities.Estudyante value)
        {
            try
            {
                value.CreatedOn = DateTime.UtcNow;
                value.UpdatedOn = DateTime.UtcNow;

                return this.estudyanteCollection.Save(value).Ok;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async System.Threading.Tasks.Task<List<Entities.Estudyante>> RetrieveAll()
        {
            try
            {
                var all = this.estudyanteCollection.FindAll();

                return all.Select(a =>
                {
                    return a;
                }).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public System.Threading.Tasks.Task<Entities.Estudyante> Retrieve(object id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Update(Entities.Estudyante value)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}