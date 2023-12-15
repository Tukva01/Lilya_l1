using Lilya.Models;
public interface IProcessService
{
    IEnumerable<Process> GetAllProcesses();
    IEnumerable<Process> FindProcessesByName(string name);
    void AddProcess(Process process);
    void UpdateProcess(Process process);
}

public class ProcessService : IProcessService
{
    private readonly IProcessRepository _processRepository;

    public ProcessService(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public IEnumerable<Process> GetAllProcesses()
    {
        return _processRepository.GetAllProcesses();
    }

    public IEnumerable<Process> FindProcessesByName(string name)
    {
        return _processRepository.FindProcessesByName(name);
    }

    public void AddProcess(Process process)
    {
        _processRepository.AddProcess(process);
    }
    public void UpdateProcess(Process process)
    {
        _processRepository.UpdateProcess(process);
    }
}
