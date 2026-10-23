using Microsoft.EntityFrameworkCore.Design;

namespace powerfit_api.Design;

public class PortuguesePluralizer : IPluralizer
{
    public string Singularize(string identifier)
    {
        return identifier.ToLower() switch
        {
            "planos" => "Plano",
            "instrutores" => "Instrutor",
            "modalidades" => "Modalidade",
            "alunos" => "Aluno",

            // O EF pode entregar "AlunosModalidades"
            // em vez do nome original "alunos_modalidades".
            "alunosmodalidades" => "AlunoModalidade",
            "alunos_modalidades" => "AlunoModalidade",

            _ => identifier
        };
    }

    public string Pluralize(string identifier)
    {
        return identifier switch
        {
            "Plano" => "Planos",
            "Instrutor" => "Instrutores",
            "Modalidade" => "Modalidades",
            "Aluno" => "Alunos",
            "AlunoModalidade" => "AlunosModalidades",

            _ => identifier
        };
    }
}