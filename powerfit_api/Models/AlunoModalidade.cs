using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace powerfit_api.Models;

public partial class AlunoModalidade
{
    public int AlunoModalidadeId { get; set; }

    public int AlunoId { get; set; }

    public int ModalidadeId { get; set; }

    public DateOnly AlunoModalidadeDataInscricao { get; set; }

    // Navegação: N AlunosModalidades -> 1 Aluno
    [JsonIgnore]
    public virtual Aluno Aluno { get; set; } = null!;

    // Navegação: N AlunosModalidades -> 1 Modalidade
    [JsonIgnore]
    public virtual Modalidade Modalidade { get; set; } = null!;
}