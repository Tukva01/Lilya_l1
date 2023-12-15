using Lilya.Models;
using Microsoft.EntityFrameworkCore;

public interface IProcessRepository
{
    IEnumerable<Process> GetAllProcesses();
    IEnumerable<Process> FindProcessesByName(string name);
    void AddProcess(Process process);
    void UpdateProcess(Process process);
}

public class ProcessRepository : IProcessRepository
{
    private readonly MainDbContext _context;

    public ProcessRepository(MainDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Process> GetAllProcesses()
    {
        return _context.Processes
                       .Include(p => p.Author)
                       .ToList();
    }

    public IEnumerable<Process> FindProcessesByName(string name)
    {
        return _context.Processes
                       .Include(p => p.Author)
                       .Where(p => p.Name.Contains(name))
                       .ToList();
    }

    public void AddProcess(Process process)
    {
        _context.Processes.Add(process);
        _context.SaveChanges();
    }
    public void UpdateProcess(Process process)
    {
        _context.Processes.Update(process);
        _context.SaveChanges();
    }
}
