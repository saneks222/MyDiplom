using StudentControl.Data.Repositories.IRepositories;
using StudentControl.Models;

namespace StudentControl.Data.Repositories
{
    public class GroupRepository : IGrupRepository
    {
        private readonly ApplicationDbContext _Db;

        public GroupRepository(ApplicationDbContext dbContext) 
        {
            _Db=dbContext;
        }

        public Guid Add(Group group)
        {
            if(group==null)
                throw new Exception("Не возможно добавить пустой обьект");

            var addedGroup = _Db.Groups.Add(group);
            _Db.SaveChanges();

            return addedGroup.Entity.Id;
        }

        public string AddRange(IEnumerable<Group> groups)
        {
            if (groups == null)
                throw new Exception("Не возможно добавить коллекцию пустых обьектов");

            _Db.Groups.AddRange(groups);
            _Db.SaveChanges();

            return "200";
        }

        public IEnumerable<Group> GetAll()
        {
            var groups = _Db.Groups.ToList();
            if(groups==null)
                throw new Exception("Ни одной группы не найденно");

            return groups;
        }

        public Group GetById(Guid id)
        {
            if(id==Guid.Empty)
                throw new Exception("Пустой гуид");

            var group = _Db.Groups.FirstOrDefault(x => x.Id == id);
            if(group==null)
                throw new Exception("группа не найдена");

            return group;
        }

        public string Remove(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Пустой гуид");

            var group = _Db.Groups.FirstOrDefault(x => x.Id == id);
            if (group == null)
                throw new Exception("группа не найдена");

            _Db.Groups.Remove(group);
            _Db.SaveChanges();

            return "200";
        }

        public Group UpdateById(Guid id, Group group)
        {
            if (id == Guid.Empty)
                throw new Exception("Пустой гуид");
            if(group == null)
                throw new Exception("Данные для обновления отсутствуют");

            var currentGroup = _Db.Groups.FirstOrDefault(x => x.Id == id);
            if (currentGroup == null)
                throw new Exception("группа не найдена");

            currentGroup.ModifiedOn=DateTime.Now;
            currentGroup.Name= group.Name!=null ?group.Name: currentGroup.Name;

            var addeGroup = _Db.Groups.Update(currentGroup);
            _Db.SaveChanges();

            return addeGroup.Entity;
        }
    }
}
