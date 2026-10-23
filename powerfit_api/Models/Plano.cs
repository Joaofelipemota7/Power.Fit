using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace powerfit_api.Models;

public partial class Plano
{
    public int PlanoId { get; set; }

    public string PlanoNome { get; set; } = null!;

    public decimal PlanoValor { get; set; }

    public int PlanoDuracaoMeses { get; set; }

    // Navegação: 1 Plano -> N Alunos
    [JsonIgnore]
    public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
}