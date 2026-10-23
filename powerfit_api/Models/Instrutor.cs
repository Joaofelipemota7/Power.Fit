using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace powerfit_api.Models;

public partial class Instrutor
{
    public int InstrutorId { get; set; }

    public string InstrutorNome { get; set; } = null!;

    public string InstrutorEspecialidade { get; set; } = null!;

    public string InstrutorCref { get; set; } = null!;

    public string InstrutorTelefone { get; set; } = null!;

    // Navegação: 1 Instrutor -> N Modalidades
    [JsonIgnore]
    public virtual ICollection<Modalidade> Modalidades { get; set; } = new List<Modalidade>();
}