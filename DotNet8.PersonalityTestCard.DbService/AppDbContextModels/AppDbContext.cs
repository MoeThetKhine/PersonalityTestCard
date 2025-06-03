using Microsoft.EntityFrameworkCore;

namespace DotNet8.PersonalityTestCard.DbService.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCard> TblCards { get; set; }

    public virtual DbSet<TblElement> TblElements { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserCard> TblUserCards { get; set; }

    public virtual DbSet<TblUserElementScore> TblUserElementScores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=PersonalityTestCard;User Id=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCard>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK__Tbl_Card__55FECDAE5060606C");

            entity.ToTable("Tbl_Card");

            entity.Property(e => e.CardName).HasMaxLength(100);

            entity.HasOne(d => d.Element).WithMany(p => p.TblCards)
                .HasForeignKey(d => d.ElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tbl_Card__Elemen__398D8EEE");
        });

        modelBuilder.Entity<TblElement>(entity =>
        {
            entity.HasKey(e => e.ElementId).HasName("PK__Tbl_Elem__A429721ADF8C41CB");

            entity.ToTable("Tbl_Element");

            entity.Property(e => e.ElementName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Tbl_User__1788CC4CA48AC4B0");

            entity.ToTable("Tbl_User");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<TblUserCard>(entity =>
        {
            entity.HasKey(e => e.UserCardId).HasName("PK__Tbl_User__57FB3A3AD872B7DB");

            entity.ToTable("Tbl_UserCard");

            entity.HasOne(d => d.Card).WithMany(p => p.TblUserCards)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tbl_UserC__CardI__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserCards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tbl_UserC__UserI__3F466844");
        });

        modelBuilder.Entity<TblUserElementScore>(entity =>
        {
            entity.HasKey(e => e.UserElementId).HasName("PK__Tbl_User__7714DDB1CCB71C04");

            entity.ToTable("Tbl_User_Element_Score");

            entity.HasOne(d => d.Element).WithMany(p => p.TblUserElementScores)
                .HasForeignKey(d => d.ElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tbl_User___Eleme__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserElementScores)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tbl_User___UserI__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
