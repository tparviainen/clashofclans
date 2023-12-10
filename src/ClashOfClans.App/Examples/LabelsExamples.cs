using ClashOfClans.Models;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples;

public class LabelsExamples
{
    private readonly string _token;

    public LabelsExamples(string token)
    {
        _token = token;
    }

    /// <summary>
    /// List clan labels
    /// </summary>
    public async Task ListClanLabels()
    {
        var coc = new ClashOfClansClient(_token);
        var labels = (LabelList)await coc.Labels.GetClanLabelsAsync();

        foreach (var label in labels)
        {
            Console.WriteLine($"Id: {label.Id}, Name: {label.Name}");
        }
    }

    /// <summary>
    /// List player labels
    /// </summary>
    public async Task ListPlayerLabels()
    {
        var coc = new ClashOfClansClient(_token);
        var labels = (LabelList)await coc.Labels.GetPlayerLabelsAsync();

        foreach (var label in labels)
        {
            Console.WriteLine($"Id: {label.Id}, Name: {label.Name}");
        }
    }
}
