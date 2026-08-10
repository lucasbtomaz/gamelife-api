using GameLife.Domain.Biblioteca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLife.Infrastructure.Persistencia.Configuracoes;

public sealed class ItemBibliotecaConfiguracao : IEntityTypeConfiguration<ItemBiblioteca>
{
    public void Configure(EntityTypeBuilder<ItemBiblioteca> builder)
    {
        builder.ToTable("ItensBiblioteca");
        builder.HasKey(item => item.Id);

        builder.Property(item => item.Plataforma)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(item => item.AdicionadoEmUtc)
            .HasPrecision(0)
            .IsRequired();

        builder.HasOne(item => item.Jogo)
            .WithMany()
            .HasForeignKey(item => item.JogoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(item => new { item.JogoId, item.Plataforma })
            .IsUnique();
    }
}
