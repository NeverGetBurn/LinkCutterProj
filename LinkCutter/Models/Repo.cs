using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter.Models
{
    public class Repo //CRUD и еще немного
    {
        private readonly Context context;
        public Repo(Context context)
        {
            this.context = context;
        }

        public IEnumerable<Link> GetLinks()
        {
            return context.Links.OrderBy(x => x.Id); // можно изменить метод сортировки, по хорошему просто получить список
        }
        public Link FindLink(Guid id)
        {
            return context.Links.Single(x => x.Id == id);
        }
        public Guid SaveLink(Link link)
        {
            if (link.Id == default)
                context.Entry(link).State = EntityState.Added;
            else
                context.Entry(link).State = EntityState.Modified;
            context.SaveChanges();

            return link.Id;
        }
        public void DeleteLink(Link link)
        {
            context.Links.Remove(link);
            context.SaveChanges();
        }

        public bool AlreadyInBD(Link link) // хотел добавить проверку через кастомный атрибут для свойств модели, но не справился с внедрением зависимостей
        {
            var linkName = context.Links
                        .Where(n => n.LongName == link.LongName)
                        .FirstOrDefault();
            if (linkName != default)
            {
                return true;
            }
            else return false;
        }
    }
}
