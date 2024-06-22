using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetTask.Server.Domain.Entities;

namespace DotNetTask.Server.Persistance
{
    public class DotNetTaskServerContext : DbContext
    {
        public DotNetTaskServerContext (DbContextOptions<DotNetTaskServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultContainer("FormPrograms");


            // Configure FormAnswers entity
            builder.Entity<FormAnswers>(entity =>
            {
                entity.HasPartitionKey(c => c.Id);

                entity.ToContainer(nameof(FormAnswers));
                entity.HasNoDiscriminator();

                entity.HasOne(x => x.Question);

                entity.Property(x => x.Answer);

                entity.Property(x => x.CreatedBy);
                entity.Property(x => x.CreatedOn);
                entity.Property(x => x.LastUpdatedBy);
                entity.Property(x => x.UpdatedOn);
            });

            // Configure Form entity
            builder.Entity<Form>(entity =>
            {
                entity.HasPartitionKey(c => c.Id);
                entity.HasMany(x => x.Questions);
                entity.HasOne(x => x.FormProgram);

                entity.ToContainer(nameof(Form));
                entity.HasNoDiscriminator();

                entity.Property(x => x.CreatedBy);
                entity.Property(x => x.CreatedOn);
                entity.Property(x => x.LastUpdatedBy);
                entity.Property(x => x.UpdatedOn);
            });

            // Configure FormProgram entity
            builder.Entity<FormProgram>(entity =>
            {
                entity.HasPartitionKey(c => c.Id);

                entity.Property(x => x.Title).IsRequired();
                entity.Property(x => x.Description).IsRequired();

                entity.ToContainer(nameof(FormProgram));
                entity.HasNoDiscriminator();

                entity.Property(x => x.CreatedBy);
                entity.Property(x => x.CreatedOn);
                entity.Property(x => x.LastUpdatedBy);
                entity.Property(x => x.UpdatedOn);
            });

            // Configure FormQuestion entity
            builder.Entity<FormQuestion>(entity =>
            {
                entity.HasPartitionKey(c => c.Id);
                entity.HasOne(x => x.Form);

                entity.ToContainer(nameof(FormQuestion));
                entity.HasNoDiscriminator();

                entity.Property(x => x.Question).IsRequired();
                entity.Property(x => x.Answers).IsRequired();
                entity.Property(x => x.QuestionType).IsRequired();
                entity.Property(x => x.IsRequired);

                entity.Property(x => x.CreatedBy);
                entity.Property(x => x.CreatedOn);
                entity.Property(x => x.LastUpdatedBy);
                entity.Property(x => x.UpdatedOn);
            });
        }


        public DbSet<FormProgram> FormPrograms { get; set; } = default!;
        public DbSet<Form> Forms { get; set; } = default!;
        public DbSet<FormAnswers> FormAnswers { get; set; } = default!;
        public DbSet<FormQuestion> FormQuestions { get; set; } = default!;
    }
}
