using GameLife.Domain.Jogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLife.Infrastructure.Persistencia.Configuracoes;

public sealed class JogoConfiguracao : IEntityTypeConfiguration<Jogo>
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.ToTable("Jogos");
        builder.HasKey(jogo => jogo.Id);

        builder.Property(jogo => jogo.Titulo)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(jogo => jogo.TituloNormalizado)
            .HasMaxLength(300)
            .IsRequired();

        builder.HasIndex(jogo => jogo.TituloNormalizado)
            .IsUnique();
    }
}
