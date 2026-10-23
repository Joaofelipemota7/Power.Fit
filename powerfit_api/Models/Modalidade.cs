using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace powerfit_api.Models;

public partial class Modalidade
{
    public int ModalidadeId { get; set; }

    public int InstrutorId { get; set; }

    public string ModalidadeNome { get; set; } = null!;

    public string ModalidadeHorario { get; set; } = null!;

    // Navegação: N Modalidades -> 1 Instrutor
    [JsonIgnore]
    public virtual Instrutor Instrutor { get; set; } = null!;

    // Navegação: 1 Modalidade -> N AlunosModalidades
    [JsonIgnore]
    public virtual ICollection<AlunoModalidade> AlunosModalidades { get; set; }
        = new List<AlunoModalidade>();
}