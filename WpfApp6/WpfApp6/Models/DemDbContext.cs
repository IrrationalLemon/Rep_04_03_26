using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp6.Models;

public partial class DemDbContext : DbContext
{
    public DemDbContext()
    {
    }

    public DemDbContext(DbContextOptions<DemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Заказ> Заказs { get; set; }

    public virtual DbSet<Пользователь> Пользовательs { get; set; }

    public virtual DbSet<ПунктВыдачи> ПунктВыдачиs { get; set; }

    public virtual DbSet<Товар> Товарs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Dem_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Заказ>(entity =>
        {
            entity.HasKey(e => e.Код);

            entity.ToTable("Заказ");

            entity.Property(e => e.Код)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.АртикулТовара)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Артикул_товара");
            entity.Property(e => e.ДатаДоставки).HasColumnName("Дата_доставки");
            entity.Property(e => e.КодПолучения).HasColumnName("Код_получения");
            entity.Property(e => e.КодПользователя).HasColumnName("Код_пользователя");
            entity.Property(e => e.КодПунктаВыдачи).HasColumnName("Код_пункта_выдачи");
            entity.Property(e => e.Статус)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.АртикулТовараNavigation).WithMany(p => p.Заказs)
                .HasForeignKey(d => d.АртикулТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказ_Товар");

            entity.HasOne(d => d.КодПользователяNavigation).WithMany(p => p.Заказs)
                .HasForeignKey(d => d.КодПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказ_Пользователь");

            entity.HasOne(d => d.КодПунктаВыдачиNavigation).WithMany(p => p.Заказs)
                .HasForeignKey(d => d.КодПунктаВыдачи)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Заказ_Пункт_выдачи");
        });

        modelBuilder.Entity<Пользователь>(entity =>
        {
            entity.HasKey(e => e.Код);

            entity.ToTable("Пользователь");

            entity.Property(e => e.Код).ValueGeneratedNever();
            entity.Property(e => e.Логин)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Пароль)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Роль)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ПунктВыдачи>(entity =>
        {
            entity.HasKey(e => e.Код);

            entity.ToTable("Пункт_выдачи");

            entity.Property(e => e.Код).ValueGeneratedNever();
            entity.Property(e => e.Адрес)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Товар>(entity =>
        {
            entity.HasKey(e => e.Артикул);

            entity.ToTable("Товар");

            entity.Property(e => e.Артикул)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ДействующаяСкидка)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Действующая_скидка");
            entity.Property(e => e.ЕдиницаИзмерения)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Единица_измерения");
            entity.Property(e => e.КатегорияТовара)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Категория_товара");
            entity.Property(e => e.Количество)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.НаименованиеТовара)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование_товара");
            entity.Property(e => e.Описание)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Поставщик)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Производитель)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Фото)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Цена)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
