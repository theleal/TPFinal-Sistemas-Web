using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForm.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public Boolean Status { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Nome}"; // ou qualquer outra informação que você queira exibir na ListBox
        }
    }
}
