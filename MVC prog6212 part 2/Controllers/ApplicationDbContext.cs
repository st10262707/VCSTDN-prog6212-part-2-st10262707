

namespace MvcProg6212Part2.Controllers
{
    public class ApplicationDbContext
    {
        public object Claims { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}