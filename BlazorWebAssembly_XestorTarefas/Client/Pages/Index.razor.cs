using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using BlazorWebAssembly_XestorTarefas.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAssembly_XestorTarefas.Client.Pages
{
    public partial class Index
    {
        [Inject] public HttpClient Http { get; set; }
        private IList<TarefaItem> tarefas;
        private string error;

        private string novaTarefa;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                string requestUri = "TarefaItems";
                tarefas = await
                    Http.GetFromJsonAsync<IList<TarefaItem>>
                   (requestUri);
            }
            catch (Exception)
            {
                error = "Hai un erro";
            };
        }

        /// <summary>
        /// Utiliza o metodo PutAsJsonAsync para actualizar a clase TarefaItem
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        private async Task CheckboxChecked(TarefaItem tarefa)
        {
            tarefa.IsCompleta = !tarefa.IsCompleta;

            string peticionUri = $"TarefaItems/{tarefa.TarefaItemId}";
            var resposta = await Http.PutAsJsonAsync<TarefaItem>(peticionUri, tarefa);
            if (!resposta.IsSuccessStatusCode)
            {
                error = resposta.ReasonPhrase;
            }
        }

        private async Task DeleteTarefa(TarefaItem tarefaItem)
        {
            tarefas.Remove(tarefaItem);
            string peticionUri = $"TarefaItems/{tarefaItem.TarefaItemId}";
            var resposta = await Http.DeleteAsync(peticionUri);

            if (!resposta.IsSuccessStatusCode)
            {
                error = resposta.ReasonPhrase;
            }
        }

        /// <summary>
        /// Usa o metodo PostAsJsonAsync para crear unha nova clase TarefaItem. A clase TarefaItem deserializase na variable tarefa.
        /// </summary>
        /// <returns></returns>
        private async Task AddTarefa()
        {
            if (!string.IsNullOrWhiteSpace(novaTarefa))
            {
                TarefaItem novaTarefaItem = new TarefaItem
                {
                    TarefaNome = novaTarefa,
                    IsCompleta = false
                };
                tarefas.Add(novaTarefaItem);
                string peticionUri = "TarefaItems";
                var resposta = await Http.PostAsJsonAsync(peticionUri, novaTarefaItem);
                if (resposta.IsSuccessStatusCode)
                {
                    novaTarefa = string.Empty;
                    var tarefa = await resposta.Content.ReadFromJsonAsync<TarefaItem>();
                }
                else
                {
                    error = resposta.ReasonPhrase;
                }
            }
        }
    }
}
