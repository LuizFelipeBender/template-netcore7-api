using Data;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class TemplateService
    {
        private readonly Contextdb context;

        public TemplateService(Contextdb _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Template>> GetAllTemplate()
        {
            return await context.Templates.ToListAsync();
        }

        //Get/{id}
        public async Task<Template> GetByIdTemplate(int? id)
        {
            return await context.Templates.FindAsync(id);
        }

        //Post
        public async Task<Template> PostTemplate(Template data)
        {
            context.Templates.Add(data);
            await context.SaveChangesAsync();
            return data;
        }

        //Put
        public async Task<Template> PutTemplate(Template data)
        {
            context.Entry(data).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return data;
        }

        //Delete
        public async Task<Template> DeleteTemplate(int? id)
        {
            var data = await context.Templates.FindAsync(id);
            context.Remove(data);
            await context.SaveChangesAsync();
            return data;
        }
    }
}
