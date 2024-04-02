using Academia.Models;
using Academia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Academia.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            // Obtém o contexto do serviço fornecido.
            using (var context = new Context(
                serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                // Aplica as migrações pendentes para garantir que o banco de dados esteja atualizado.
                context.Database.Migrate();

                // Se não houver alunos no banco de dados, insere dados iniciais.
                if (!context.Alunos.Any())
                {
                    context.Alunos.AddRange(
                        new Aluno
                        {
                            Nome = "Maria",
                            DataNascimento = new DateTime(1990, 1, 15),
                            Email = "maria@example.com",
                            Instagram = "maria_insta",
                            Telefone = "987654321",
                            PersonalId = 1,
                            Observacoes = "Aluna dedicada e comprometida"
                        },
                        new Aluno
                        {
                            Nome = "Carlos",
                            DataNascimento = new DateTime(1985, 5, 20),
                            Email = "carlos@example.com",
                            Instagram = "carlos_insta",
                            Telefone = "123456789",
                            PersonalId = 2,
                            Observacoes = "Aluno esforçado e motivado"
                        },
                        new Aluno
                        {
                            Nome = "Ana",
                            DataNascimento = new DateTime(1992, 8, 10),
                            Email = "ana@example.com",
                            Instagram = "ana_insta",
                            Telefone = "999888777",
                            PersonalId = 1,
                            Observacoes = "Aluna em busca de condicionamento físico"
                        },
                        new Aluno
                        {
                            Nome = "Lucas",
                            DataNascimento = new DateTime(1986, 12, 5),
                            Email = "lucas@example.com",
                            Instagram = "lucas_insta",
                            Telefone = "444555666",
                            PersonalId = 2,
                            Observacoes = "Aluno focado em ganho de massa muscular"
                        },
                        new Aluno
                        {
                            Nome = "Fernanda",
                            DataNascimento = new DateTime(1990, 3, 25),
                            Email = "fernanda@example.com",
                            Instagram = "fernanda_insta",
                            Telefone = "111222333",
                            PersonalId = 1,
                            Observacoes = "Aluna determinada a perder peso"
                        }
                    );
                }

                // Se não houver pessoais no banco de dados, insere dados iniciais.
                if (!context.Personais.Any())
                {
                    context.Personais.AddRange(
                        new Personal { Nome = "Fernando", Especialidade = "Musculação" },
                        new Personal { Nome = "Juliana", Especialidade = "Funcional" }
                    );
                }

                // Se não houver exercícios no banco de dados, insere dados iniciais.
                if (!context.Exercicios.Any())
                {
                    context.Exercicios.AddRange(
                        new Exercicio { Nome = "Flexão de Braço", Categoria = "Peitoral", Descricao = "Exercício para o peitoral e tríceps" },
                        new Exercicio { Nome = "Leg Press", Categoria = "Pernas", Descricao = "Exercício para os quadríceps e glúteos" }
                        // Adicione mais exercícios conforme necessário
                    );
                }

                // Se não houver treinos no banco de dados, insere dados iniciais.
                if (!context.Treinos.Any())
                {
                    context.Treinos.AddRange(
                        new Treino { PersonalId = 1, AlunoId = 1, Data = new DateTime(2024, 4, 1, 12, 24, 44)}
                    );
                }

                // Salva as alterações no banco de dados.
                context.SaveChanges();
            }
        }
    }
}