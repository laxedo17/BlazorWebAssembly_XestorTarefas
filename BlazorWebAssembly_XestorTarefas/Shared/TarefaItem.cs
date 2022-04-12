using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssembly_XestorTarefas.Shared
{
    public class TarefaItem
    {
        public int TarefaItemId { get; set; }
        public string TarefaNome { get; set; }
        public bool IsCompleta { get; set; }
    }
}
