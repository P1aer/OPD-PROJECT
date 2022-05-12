using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectX.DAL.Entities;
using ProjectX.DAL.Repositories;
using ProjectX.Logic.DTO;

namespace ProjectX.Logic.Service
{
    public class HomeworkService
    {
       HomeWorkRepository repository { get; set; }

        public HomeworkService(HomeWorkRepository context)
        {
            repository = context;
        }
        public Homework? GetOne(int id)
        {
            return repository.GetOne(id);
        }
        public List<Homework> GetAll()
        {
            return repository.GetAll().ToList();
        }
        public void Create(HomeworkDTO homework)
        {
            Homework std = new Homework
            {
                ID = homework.ID,
                Task = homework.Task,
            };
            repository.Create(std);
            repository.Save();
        }
        public void Update(HomeworkDTO homework)
        {
            Homework std = new Homework
            {
                ID = homework.ID,
                Task = homework.Task,
            };
            repository.Update(std);
            repository.Save();
        }
        public void Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
        }
    }
}
