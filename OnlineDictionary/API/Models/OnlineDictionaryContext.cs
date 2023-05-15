using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineDictionary.API.Models;

public partial class OnlineDictionaryContext : DbContext
{
    public OnlineDictionaryContext()
    {
    }

    public OnlineDictionaryContext(DbContextOptions<OnlineDictionaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dict> Dicts { get; set; }

    public virtual DbSet<DictsTranslate> DictsTranslates { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Translate> Translates { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=onlineDictionary;Username=postgres;Password=22698534418");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_dicts");

            entity.ToTable("dicts");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Info)
                .HasMaxLength(250)
                .HasColumnName("info");
            entity.Property(e => e.Language1Id).HasColumnName("language1_id");
            entity.Property(e => e.Language2Id).HasColumnName("language2_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Language1).WithMany(p => p.DictLanguage1s)
                .HasForeignKey(d => d.Language1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dicts_languages1");

            entity.HasOne(d => d.Language2).WithMany(p => p.DictLanguage2s)
                .HasForeignKey(d => d.Language2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dicts_languages2");
        });

        modelBuilder.Entity<DictsTranslate>(entity =>
        {
            entity.HasKey(e => new { e.DictId, e.TranslateId }).HasName("pk_dicts_translates");

            entity.ToTable("dicts_translates");

            entity.Property(e => e.DictId).HasColumnName("dict_id");
            entity.Property(e => e.TranslateId).HasColumnName("translate_id");

            entity.HasOne(d => d.Dict).WithMany(p => p.DictsTranslates)
                .HasForeignKey(d => d.DictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dicts_translates_dicts");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_languages");

            entity.ToTable("languages");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Info)
                .HasMaxLength(250)
                .HasColumnName("info");
            entity.Property(e => e.Name)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Translate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_translates");

            entity.ToTable("translates");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Example)
                .HasMaxLength(250)
                .HasColumnName("example");
            entity.Property(e => e.Word1Id).HasColumnName("word1_id");
            entity.Property(e => e.Word2Id).HasColumnName("word2_id");

            entity.HasOne(d => d.Word1).WithMany(p => p.TranslateWord1s)
                .HasForeignKey(d => d.Word1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_translates_words1");

            entity.HasOne(d => d.Word2).WithMany(p => p.TranslateWord2s)
                .HasForeignKey(d => d.Word2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_translates_words2");
        });

        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_words");

            entity.ToTable("words");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Info)
                .HasMaxLength(150)
                .HasColumnName("info");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .HasColumnName("value");

            entity.HasOne(d => d.Language).WithMany(p => p.Words)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_words_languages");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
