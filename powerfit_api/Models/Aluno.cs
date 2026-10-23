using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace powerfit_api.Models;

public partial class Aluno
{
    public int AlunoId { get; set; }

    public int PlanoId { get; set; }

    public string AlunoNome { get; set; } = null!;

    public DateOnly AlunoDataNascimento { get; set; }

    public string AlunoEmail { get; set; } = null!;

    public string AlunoTelefone { get; set; } = null!;

    // Navegação: N Alunos -> 1 Plano
    [JsonIgnore]
    public virtual Plano Plano { get; set; } = null!;

    // Navegação: 1 Aluno -> N AlunosModalidades
    [JsonIgnore]
    public virtual ICollection<AlunoModalidade> AlunosModalidades { get; set; }
        = new List<AlunoModalidade>();
}