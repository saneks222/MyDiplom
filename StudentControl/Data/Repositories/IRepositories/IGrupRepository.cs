using StudentControl.Models;

namespace StudentControl.Data.Repositories.IRepositories
{
    public interface IGrupRepository
    {
        public Group GetById(Guid id);

        public IEnumerable<Group> GetAll();

        public IEnumerable<Group> GetFilterRange(string param);

        public string Remove(Guid id);

        public Group UpdateById(Guid id, Group group);

        public Guid Add(Group group);

        public string AddRange(IEnumerable<Group> groups);
    }
}
