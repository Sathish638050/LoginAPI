using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LoginAuthenticationAPI.Model
{
    public partial class ELearnApplicationContext : DbContext
    {
        public ELearnApplicationContext()
        {
        }

        public ELearnApplicationContext(DbContextOptions<ELearnApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseEnroll> CourseEnrolls { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<NewStaff> NewStaffs { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:elearn123.database.windows.net,1433;Initial Catalog=ELearnApplication;Persist Security Info=False;User ID=Team5;Password=T@1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.Answer1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("Answer");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answer__Question__35BCFE0A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answer__UserId__36B12243");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("Class_id");

                entity.Property(e => e.CLink)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_Link");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__Course_id__403A8C7D");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Contact__D830D477BD8608AE");

                entity.ToTable("Contact");

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__UserId__534D60F1");
            });

            modelBuilder.Entity<CourseEnroll>(entity =>
            {
                entity.HasKey(e => new { e.EnrollId, e.UserId, e.CourseId })
                    .HasName("PK__CourseEn__ABBE2B5C1B93ABE7");

                entity.ToTable("CourseEnroll");

                entity.Property(e => e.EnrollId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Enroll_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseEnrolls)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseEnr__Cours__52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseEnrolls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseEnr__UserI__5165187F");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fees__Course_id__32E0915F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fees__UserId__31EC6D26");
            });

            modelBuilder.Entity<NewStaff>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__NewStaff__CA1E5D78E9AFBCC1");

                entity.ToTable("NewStaff");

                entity.Property(e => e.College)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Experience)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.High)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.UserImage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("Question");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Question__UserId__2B3F6F97");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.TopicId).HasColumnName("Topic_id");

                entity.Property(e => e.CourseId).HasColumnName("Course_id");

                entity.Property(e => e.MaterialPath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Material_path");

                entity.Property(e => e.TopicDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Topic_Desc");

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Topic_Name");

                entity.Property(e => e.VideoPath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Video_path");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Topics__Course_i__5CD6CB2B");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserAcco__1788CC4C67E83220");

                entity.ToTable("UserAccount");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserImage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
