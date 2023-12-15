using Lilya.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lilya.Models;

public class ProcessAssignmentService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly Random _random = new Random();

    public ProcessAssignmentService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var processService = scope.ServiceProvider.GetRequiredService<IProcessService>();
                var authorService = scope.ServiceProvider.GetRequiredService<IAuthorService>();

                // Получение всех авторов
                var authors = authorService.GetAllAuthors().ToList();
                if (authors.Any())
                {
                    // Получение всех процессов
                    var processes = processService.GetAllProcesses();

                    foreach (var process in processes)
                    {
                        // Пропускаем уже назначенные процессы
                        if (process.AuthorId != null) continue;

                        // Назначение случайного автора
                        var randomAuthor = authors[_random.Next(authors.Count)];
                        process.AuthorId = randomAuthor.Id;

                        // Заполнение описания метрики
                        process.MetricDescription = $"Описание процесса #{process.Id}";

                        // Обновление процесса
                        processService.UpdateProcess(process);
                    }
                }
            }

            // Пауза на 3 секунды перед следующей итерацией
            await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
        }
    }
}
