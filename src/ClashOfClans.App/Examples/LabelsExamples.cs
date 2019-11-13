using ClashOfClans.Models;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.App.Examples
{
    public class LabelsExamples
    {
        private readonly string token;

        public LabelsExamples(string token)
        {
            this.token = token;
        }

        /// <summary>
        /// List clan labels
        /// </summary>
        public async Task ListClanLabels()
        {
            var coc = new ClashOfClansApi(token);
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
            var coc = new ClashOfClansApi(token);
            var labels = (LabelList)await coc.Labels.GetPlayerLabelsAsync();

            foreach (var label in labels)
            {
                Console.WriteLine($"Id: {label.Id}, Name: {label.Name}");
            }
        }
    }
}
